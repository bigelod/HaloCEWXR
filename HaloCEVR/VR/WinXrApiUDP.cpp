#include "WinXrApiUDP.h"
#include "../Game.h"
#include "../Logger.h"
#include <Winsock2.h>
#include <iostream>
#include <thread>
#include <cstring>
#include <io.h>
#include <mutex>
#include <condition_variable>
#include <sstream>
#include <vector>

WinXrApiUDP::WinXrApiUDP()
{
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
		Logger::log << "Error starting UDP receiver: " << e.what() << std::endl;
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

				//Logger::log << "UDP DATA " + returnData << std::endl;

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
			Logger::log << "Error receiving UDP data: " << e.what() << std::endl;
		}
	}
}

void WinXrApiUDP::KillReceiver()
{
	try
	{
		udpReadThread.~thread();
		udpReadThread = std::thread();
		_close(udpSocket);
	}
	catch (const std::exception& e)
	{
		Logger::log << "Error killing UDP receiver: " << e.what() << std::endl;
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