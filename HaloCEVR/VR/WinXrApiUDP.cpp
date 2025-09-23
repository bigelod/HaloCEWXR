#include "WinXrApiUDP.h"
#include "../Game.h"
#include "../Logger.h"
#include <Winsock2.h>
#include <ws2tcpip.h>
#include <iostream>
#include <thread>
#include <cstring>
#include <io.h>
#include <mutex>
#include <condition_variable>
#include <sstream>
#include <vector>
#include <locale>

WinXrApiUDP::WinXrApiUDP()
{
	WSADATA wsaData;
	WSAStartup(MAKEWORD(2, 2), &wsaData);

	Logger::log << "[WinXrUDP] Starting UDP receiver thread..." << std::endl;
	udpReadThread = std::thread(&WinXrApiUDP::ReceiveData, this);
	udpReadThread.detach();
}

void WinXrApiUDP::ReceiveData()
{
	udpSocket = socket(AF_INET, SOCK_DGRAM, 0);
	struct sockaddr_in serverAddr, clientAddr;
	memset(&serverAddr, 0, sizeof(serverAddr));
	serverAddr.sin_family = AF_INET;
	serverAddr.sin_addr.s_addr = INADDR_ANY;
	serverAddr.sin_port = htons(udpPort);

	try {
		bind(udpSocket, (struct sockaddr*)&serverAddr, sizeof(serverAddr));
	}
	catch (const std::exception& e) {
		Logger::log << "[WinXrUDP] Error starting UDP receiver: " << e.what() << std::endl;
	}	

	while (true)
	{
		try
		{
			char buffer[1024];
			int addrLen = sizeof(clientAddr);
			ptrdiff_t bytesReceived = recvfrom(udpSocket, buffer, sizeof(buffer), 0, (struct sockaddr*)&clientAddr, &addrLen);

			if (bytesReceived > 0 && bytesReceived < 1024)
			{
				buffer[bytesReceived] = '\0';
				std::string returnData(buffer);

				std::istringstream iss(returnData);
				std::string client;
				std::vector<float> floats(28);
				int openXRFrameID;

				std::locale c_locale("C");
				iss.imbue(c_locale);

				iss >> client;
				for (auto& f : floats) {
					iss >> f;
				}
				iss >> openXRFrameID;

				if (Game::instance.OpenXRFrameID == openXRFrameID) {
					Game::instance.OpenXRFrameWait = 1;
					continue;
				}
				else {
					Game::instance.OpenXRFrameWait = 0;
				}

				//Logger::log << "[WinXrUDP] UDP DATA " + returnData << std::endl;

				{
					std::lock_guard<std::mutex> lock(mtx);
					retData = returnData;
				}
				cv.notify_all();

				// if (posData != nullptr)
				// {
				//     posData->ReceiveData(returnData);
				// }
			}
		}
		catch (const std::exception& e)
		{
			Logger::log << "[WinXrUDP] Error receiving UDP data: " << e.what() << std::endl;
		}
	}
}

void WinXrApiUDP::SendData(std::string sendData)
{
	try
	{
		/*WSADATA wsaData;
		if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) {
			Logger::log << "[WinXrUDP] WSAStartup failed with error " << WSAGetLastError() << std::endl;
			return;
		}*/

		struct sockaddr_in targetAddress;
		udpSendSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
		if (udpSendSocket == INVALID_SOCKET) {
			Logger::log << "[WinXrUDP] Error sending UDP data: socket creation failed" << std::endl;
			return;
		}

		targetAddress.sin_family = AF_INET;
		targetAddress.sin_port = htons(udpSendPort);
		inet_pton(AF_INET, "127.0.0.1", &targetAddress.sin_addr);

		int result = sendto(udpSendSocket, sendData.c_str(), sendData.length(), 0, (struct sockaddr*)&targetAddress, sizeof(targetAddress));
		if (result == SOCKET_ERROR) {
			Logger::log << "[WinXrUDP] sendto failed with error " << WSAGetLastError() << std::endl;
		}

		closesocket(udpSendSocket);
		//WSACleanup();
	}
	catch (const std::exception& e)
	{
		Logger::log << "[WinXrUDP] Error sending UDP data: " << e.what() << std::endl;
	}	
}

void WinXrApiUDP::KillReceiver()
{
	Logger::log << "[WinXrUDP] Shutting down UDP receiver..." << std::endl;

	try
	{
		udpReadThread.~thread();
		udpReadThread = std::thread();
		closesocket(udpSocket);
		WSACleanup();
	}
	catch (const std::exception& e)
	{
		Logger::log << "[WinXrUDP] Error killing UDP receiver: " << e.what() << std::endl;
	}
}

std::string WinXrApiUDP::GetRetData() {
	std::unique_lock<std::mutex> lock(mtx);
	cv.wait(lock, [this] { return !retData.empty(); });
	return retData;
}

WinXrApiUDP::~WinXrApiUDP()
{
	KillReceiver();
}