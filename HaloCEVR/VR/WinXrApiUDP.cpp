#include "WinXrApiUDP.h"
#include "../Logger.h"
#include <Winsock2.h>
#include <iostream>
#include <thread>
#include <cstring>
#include <io.h>
#include <mutex>
#include <condition_variable>

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

	bind(udpSocket, (struct sockaddr*)&serverAddr, sizeof(serverAddr));

	while (true)
	{
		try
		{
			char buffer[1024];
			int addrLen = sizeof(clientAddr);
			ptrdiff_t bytesReceived = recvfrom(udpSocket, buffer, sizeof(buffer), 0, (struct sockaddr*)&clientAddr, &addrLen);

			if (bytesReceived > 0)
			{
				buffer[bytesReceived] = '\0';
				std::string returnData(buffer);

				Logger::log << "UDP DATA " + returnData << std::endl;

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
			// Handle exception
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
		// Handle exception
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