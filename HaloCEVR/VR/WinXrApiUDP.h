#pragma once
#pragma comment(lib, "ws2_32.lib")
#include <Winsock2.h>
#include <iostream>
#include <thread>
#include <cstring>
#include <io.h>
#include <mutex>
#include <condition_variable>
#include <cstddef>

class WinXrApiUDP
{
public:
	WinXrApiUDP();
	void Init();
	void ReceiveData();
	void KillReceiver();
	void SendData(std::string sendData);

	std::string GetRetData();
	~WinXrApiUDP();

private:
	int udpPort = 7872;
	int udpSocket;
	int udpSendPort = 7278;
	int udpSendSocket;
	std::thread udpReadThread;
	std::string retData;
	std::mutex mtx;
	std::condition_variable cv;
};

