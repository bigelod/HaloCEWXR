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

	std::string GetRetData();
	~WinXrApiUDP();

private:
	int udpPort = 7872;
	int udpSocket;
	std::thread udpReadThread;
	std::string retData;
	std::mutex mtx;
	std::condition_variable cv;
};

