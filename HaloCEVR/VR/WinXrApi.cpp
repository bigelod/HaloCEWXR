#include "WinXrApiUDP.h"
#include <d3d9.h>
#include "WinXrApi.h"
#include "../Helpers/DX9.h"
#include "../Helpers/RenderTarget.h"
#include "../Helpers/Camera.h"
#include "../Helpers/Renderer.h"
#include "../Helpers/Cutscene.h"
#include "../Helpers/Menus.h"
#include "../Logger.h"
#include "../DirectXWrappers/IDirect3DDevice9ExWrapper.h"
#include "../Game.h"
#include <filesystem>
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <locale>

template<typename T, std::size_t N>
constexpr std::size_t arraySize(T(&)[N]) {
	return N;
}

LRESULT CALLBACK WindowProcXrApi(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_DESTROY:
	{
		PostQuitMessage(0);
		return 0;
	} break;
	}

	return DefWindowProc(hWnd, message, wParam, lParam);
}

void WinXrApi::Init()
{
	IPDVal = 64.0f;

	LHandQuat = Vector4(0, 0, 0, 0);
	LHandPos = Vector3(0, 0, 0);
	LThumbstick = Vector2(0, 0);

	RHandQuat = Vector4(0, 0, 0, 0);
	RHandPos = Vector3(0, 0, 0);
	RThumbstick = Vector2(0, 0);

	HMDQuat = Vector4(0, 0, 0, 0);
	HMDPos = Vector3(0, 0, 0);
	lastHMDPos = Vector3(0, 0, 0);
	hmdVirtualOffset = Vector3(0, 0, 0);
	playerCoords = Vector3(0, 0, 0);
	lastPlayerCoords = Vector3(0, 0, 0);
	lastCenterGameCoords = Vector3(0, 0, 0);

	hmdCenterPos = Vector3(0, 0, 0);
	usingVirtualLocomotion = false;
	movingBody = false;

	prevLHandPos[0] = Vector3(0, 0, 0);
	prevLHandPos[1] = Vector3(0, 0, 0);
	prevLHandPos[2] = Vector3(0, 0, 0);
	prevLHandPos[3] = Vector3(0, 0, 0);
	prevLHandPos[4] = Vector3(0, 0, 0);

	prevRHandPos[0] = Vector3(0, 0, 0);
	prevRHandPos[1] = Vector3(0, 0, 0);
	prevRHandPos[2] = Vector3(0, 0, 0);
	prevRHandPos[3] = Vector3(0, 0, 0);
	prevRHandPos[4] = Vector3(0, 0, 0);
	lastPosFrame = 0;

	//Kiosk mode
	std::filesystem::path saveResetCheck = std::filesystem::current_path() / "VR" / "istr.txt";
	std::filesystem::path replaceSave = std::filesystem::current_path() / "VR" / "New001";
	std::filesystem::path docsSaveDir;

	if (std::filesystem::exists(saveResetCheck) && std::filesystem::is_regular_file(saveResetCheck)) {
		try {
			std::ifstream savegamesPath(saveResetCheck);

			if (savegamesPath.is_open()) {
				std::string outpathStr;
				std::getline(savegamesPath, outpathStr);
				savegamesPath.close();

				docsSaveDir = std::filesystem::path(outpathStr);
			}

			if (docsSaveDir.empty()) {

			}
			else if (std::filesystem::exists(docsSaveDir) && std::filesystem::is_directory(docsSaveDir)) {
				if (std::filesystem::exists(replaceSave) && std::filesystem::is_directory(replaceSave)) {
					for (const auto& entry : std::filesystem::directory_iterator(docsSaveDir)) {
						if (entry.is_directory()) {
							std::filesystem::remove_all(entry.path());
						}
					}

					std::filesystem::path newSaveData = docsSaveDir / "New001";
					std::filesystem::create_directories(newSaveData);

					std::filesystem::copy(replaceSave, newSaveData, std::filesystem::copy_options::recursive | std::filesystem::copy_options::overwrite_existing);
				}
			}
		}
		catch (const std::filesystem::filesystem_error& e) {

		}
		catch (const std::exception& e) {

		}
	}

	//Now we initialize VR mode
	Logger::log << "[WinXrApi] Initialising WinlatorXR VR mode..." << std::endl;

	std::filesystem::path tmpPath = "Z:/";
	std::filesystem::path dirPath = "Z:/tmp/xr";
	std::filesystem::path fallbackDir = "D:/xrtemp";
	std::filesystem::path filePath = dirPath / "vr";
	std::filesystem::path fallbackFile = fallbackDir / "vr";

	if (std::filesystem::exists(tmpPath) && std::filesystem::is_directory(tmpPath)) {
		if (std::filesystem::exists(dirPath) && std::filesystem::is_directory(dirPath)) {
			//Nothing to do
		}
		else {
			//Try to create the folder
			try {
				std::filesystem::create_directories(dirPath);
			}
			catch (const std::exception& e) {
				Logger::log << "[WinXrApi] Error creating tmp/xr directory: " << e.what() << std::endl;
			}
		}

		try {
			std::ofstream file(filePath);
			if (file.is_open()) {
				file << "VR";
				file.close();
			}
			else {

			}
		}
		catch (const std::exception& e) {
			Logger::log << "[WinXrApi] Error writing VR file: " << e.what() << std::endl;
		}
	}
	else {
		try {
			std::ofstream file(fallbackFile);
			if (file.is_open()) {
				file << "VR";
				file.close();
			}
			else {

			}
		}
		catch (const std::exception& e) {
			Logger::log << "[WinXrApi] Error writing test VR file: " << e.what() << std::endl;
		}

		dirPath = fallbackDir;
	}

	std::filesystem::path sysinfoPath = dirPath / "system";

	if (std::filesystem::exists(dirPath) && std::filesystem::is_directory(dirPath)) {
		if (std::filesystem::exists(sysinfoPath) && std::filesystem::is_regular_file(sysinfoPath)) {
			try {
				std::ifstream sysInfoFile(sysinfoPath);

				std::string hmdMakeStr;
				std::string hmdModelStr;

				if (sysInfoFile.is_open()) {
					std::getline(sysInfoFile, hmdMakeStr);
					std::getline(sysInfoFile, hmdModelStr);
					sysInfoFile.close();
				}

				hmdMake = hmdMakeStr;
				hmdModel = hmdModelStr;
			}
			catch (const std::filesystem::filesystem_error& e) {

			}
			catch (const std::exception& e) {

			}
		}
	}

	if (hmdMake.empty()) {
		hmdMake = "META";
	}
	else if (hmdMake == "OCULUS") {
		hmdMake = "META";
	}

	if (hmdModel.empty()) {
		hmdModel = "QUEST 3";
	}
	else if (hmdModel == "EUREKA" || hmdModel == "PANTHER") {
		hmdModel = "QUEST 3";
	}
	else if (hmdMake == "META") {
		//SEACLIFF - Quest Pro - Untested, assuming hands upside down
		//HOLLYWOOD - Quest 2 - Works! Hands upside down, performance is OK
		//MONTEREY - Quest 1 - Untested, unsupported
		hmdModel = "QUEST 2";
	}

	Logger::log << "[WinXrApi] starting UDP listener ..." << std::endl;
	udpReader = new WinXrApiUDP();
}

void WinXrApi::OnGameFinishInit()
{
	/*HWND hWnd;
	WNDCLASSEX wc;
	HINSTANCE hInstance = GetModuleHandle(NULL);

	ZeroMemory(&wc, sizeof(WNDCLASSEX));

	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WindowProcXrApi;
	wc.hInstance = hInstance;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)COLOR_WINDOW;
	wc.lpszClassName = L"WindowClass";

	RegisterClassEx(&wc);*/

	//hWnd = CreateWindowEx(NULL, L"WindowClass", L"Mirror Window", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 1200, 600, NULL, NULL, hInstance, NULL);

	//ShowWindow(hWnd, SW_SHOW);

	if (!Helpers::GetDirect3D9())
	{
		Logger::log << "GetDirect3D9 returned null, aborting" << std::endl;
		return;
	}

	IDirect3DSurface9* gameSurface = nullptr;

	Logger::log << "Getting render target" << std::endl;

	Helpers::GetDirect3DDevice9()->GetRenderTarget(0, &gameSurface);

	Logger::log << "Got render target" << std::endl;

	D3DSURFACE_DESC desc;

	gameSurface->GetDesc(&desc);
	gameSurface->Release();
	Logger::log << "Released the gameSurface" << std::endl;

	/*D3DPRESENT_PARAMETERS present;
	ZeroMemory(&present, sizeof(present));
	present.Windowed = TRUE;
	present.SwapEffect = D3DSWAPEFFECT_DISCARD;
	present.hDeviceWindow = hWnd;
	present.BackBufferWidth = 1200;
	present.BackBufferHeight = 600;
	present.BackBufferFormat = desc.Format;
	present.MultiSampleQuality = desc.MultiSampleQuality;
	present.MultiSampleType = desc.MultiSampleType;*/

	/*HRESULT result = S_OK;

	result = Helpers::GetDirect3D9()->CreateDevice(0, D3DDEVTYPE_HAL, hWnd, D3DCREATE_HARDWARE_VERTEXPROCESSING, &present, &mirrorDevice);

	if (FAILED(result))
	{
		Logger::log << "IDirect3DDevice9::CreateDevice failed: " << result << std::endl;
		return;
	}*/

	Logger::log << "Creating Shared Target" << std::endl;

	CreateSharedTarget();

	Logger::log << "Created Shared Target" << std::endl;

	//Logger::log << "Created Mirror D3D window" << std::endl;

}

void WinXrApi::Shutdown()
{
	if (udpReader) {
		udpReader->KillReceiver();
		udpReader = nullptr;
	}

	Logger::log << "[WinXrApi] ending WinlatorXR VR mode..." << std::endl;

	std::filesystem::path dirPath = "Z:/tmp/xr";
	std::filesystem::path fallbackDir = "D:/xrtemp";
	std::filesystem::path filePath = dirPath / "vr";
	std::filesystem::path fallbackFile = fallbackDir / "vr";

	if (std::filesystem::exists(filePath) && std::filesystem::is_regular_file(filePath)) {
		try {
			std::filesystem::remove(filePath);
		}
		catch (const std::exception& e) {
			Logger::log << "Error deleting file: " << e.what() << std::endl;
		}
	}
	else {
		try {
			std::filesystem::remove(fallbackFile);
		}
		catch (const std::exception& e) {
			Logger::log << "Error deleting file: " << e.what() << std::endl;
		}
	}
}

void WinXrApi::SendHapticVibration(float lControllerStrength, float rControllerStrength) {
	bool sendHaptics = Game::instance.c_EnableHaptics->Value();

	if (udpReader && sendHaptics) {
		udpReader->SendData(std::to_string(lControllerStrength) + " " + std::to_string(rControllerStrength));
	}
}

void WinXrApi::UpdatePoses()
{
	if (udpReader) {
		//Logger::log << "[WinXrApi] Getting UDP Data..." << std::endl;

		std::string txt = udpReader->GetRetData();

		//Logger::log << txt << std::endl;	 

		//Example return data:
		//[Game] WinXrApi Getting Data...
		//client0 0.213 0.287 -0.933 0.035 0.0 0.0 -0.008 -0.229 -0.173 0.095 -0.296 0.947 -0.077 0.0 0.0 0.154 -0.240 -0.140 0.146 -0.072 0.048 0.985 0.037 0.006 -0.017 0.0678 99.00 103.40 224 TFFFFFFFFFTTTFFFFFT META

		std::istringstream iss(txt);
		std::string client;
		std::vector<float> floats(28);
		int openXRFrameID;
		std::string buttonString;

		std::locale c_locale("C");
		iss.imbue(c_locale);

		// Parse client string
		iss >> client;

		// Parse float values
		for (auto& f : floats) {
			iss >> f;
		}

		// Parse integer value and last string
		iss >> openXRFrameID >> buttonString; //>> hmdString;

		Game::instance.OpenXRFrameID = openXRFrameID;

		//Logger::log << "Client: " << client << std::endl;
		//Logger::log << "Floats: ";
		//for (float val : floats) {
		//	Logger::log << val << " ";
		//}
		//Logger::log << std::endl;
		//Logger::log << "Open XR FrameID: " << openXRFrameID << std::endl;
		//Logger::log << "Button String: " << buttonString << std::endl;

		std::vector<bool> buttonBools;

		if (buttonString.empty()) {
			buttonString = "FFFFFFFFFFFFFFFFFFF";
		}

		for (char c : buttonString) {
			if (c == 'F') {
				buttonBools.push_back(false);
			}
			else if (c == 'T') {
				buttonBools.push_back(true);
			}
		}

		//FLOATS:
		//Left Hand Quaternion X, Left Hand Quaternion Y, Left Hand Quaternion Z, Left Hand Quaternion W, Left Hand Thumbstick X, Left Hand Thumbstick Y, 
		//Left Hand X Position, Left Hand Y Position, Left Hand Z Position,
		//Right Hand Quaternion X, Right Hand Quaternion Y, Right Hand Quaternion Z, Right Hand Quaternion W, Right Hand Thumbstick X, Right Hand Thumbstick Y, 
		//Right Hand X Position, Right Hand Y Position, Right Hand Z Position,
		//HMD Quaternion X, HMD Quaternion Y, HMD Quaternion Z, HMD Quaternion W, HMD X Position, HMD Y position, HMD Z Position, 
		//Current IPD, Current FOV Horizontal, Current FOV Vertical, XR Frame ID, Button String

		//BUTTONS:
		//L_GRIP, L_MENU, L_THUMBSTICK_PRESS, L_THUMBSTICK_LEFT, L_THUMBSTICK_RIGHT, L_THUMBSTICK_UP, L_THUMBSTICK_DOWN, L_TRIGGER, L_X, L_Y, 
		//R_A, R_B, R_GRIP, R_THUMBSTICK_PRESS, R_THUMBSTICK_LEFT, R_THUMBSTICK_RIGHT, R_THUMBSTICK_UP, R_THUMBSTICK_DOWN, R_TRIGGER

		LHandQuat = Vector4(floats[0], floats[1], floats[2], floats[3]);
		LHandPos = Vector3(floats[6], floats[7], floats[8]);
		LThumbstick = Vector2(floats[4], floats[5]);

		bool disableThumbMove = Game::instance.c_DisableThumbstickMovement->Value();
		if (disableThumbMove) {
			LThumbstick = Vector2(0, 0);

			bool enableNonStationary = Game::instance.c_NonstationaryBoundary->Value();
			if (!enableNonStationary) {
				Game::instance.c_NonstationaryBoundary->SetValue(true); //Must be enabled if we disable thumbstick movement
			}
		}

		if (LThumbstick.x != 0 || LThumbstick.y != 0) {
			usingVirtualLocomotion = true;
		}
		else {
			usingVirtualLocomotion = false;
		}

		RHandQuat = Vector4(floats[9], floats[10], floats[11], floats[12]);
		RHandPos = Vector3(floats[15], floats[16], floats[17]);
		RThumbstick = Vector2(floats[13], floats[14]);

		bool disableThumbRotate = Game::instance.c_DisableThumbstickRotation->Value();
		if (disableThumbRotate) {
			RThumbstick = Vector2(0, 0);
		}

		HMDQuat = Vector4(floats[18], floats[19], floats[20], floats[21]);
		HMDPos = Vector3(floats[22], floats[23], floats[24]);

		IPDVal = floats[25];
		FOVH = floats[26] + 30.0f;
		FOVV = floats[27] - 20.0f;

		FOVTotal = FOVH / FOVV;

		LTrigger = buttonBools[7];
		LGrip = buttonBools[0];
		LClick = buttonBools[2];
		RTrigger = buttonBools[18];
		RGrip = buttonBools[12];
		RClick = buttonBools[13];
		L_X = buttonBools[8];
		L_Y = buttonBools[9];
		R_A = buttonBools[10];
		R_B = buttonBools[11];
		L_Menu = buttonBools[1];
		//L_Menu = false;

		R_ThumbUp = buttonBools[16];
		R_ThumbDown = buttonBools[17];

		bool enableMeleeBtn = Game::instance.c_EnableButtonMelee->Value();
		if (!enableMeleeBtn) {
			R_ThumbDown = false;
		}

		//PICO and Quest 2 are both tested to need the hand orientation flipped, assume the same for Quest Pro for now
		if (hmdMake == "PICO" || hmdModel == "QUEST 2") {
			UpsideDownHandsFix = true;
		}
		else {
			UpsideDownHandsFix = false;
		}

		//Brute force melee gesture logging
		prevLHandPos[lastPosFrame] = LHandPos;
		prevRHandPos[lastPosFrame] = RHandPos;

		lastPosFrame += 1;
		if (lastPosFrame > 4) {
			lastPosFrame = 0;
		}
	}
}

void WinXrApi::UpdateCameraFrustum(CameraFrustum* frustum, int eye)
{
	const float DIST = Game::instance.MetresToWorld(IPDVal / 1000.0f);

	Matrix4 headMatrix = GetHMDTransform(true);

	// Yaw should follow cutscene camera
	CutsceneData* cutscene = Helpers::GetCutsceneData();

	if (cutscene->bInCutscene)
	{
		//float cameraYaw = atan2(frustum->facingDirection.y, frustum->facingDirection.x) * (180.0f / 3.1415926f);
		//headMatrix.rotateZ(cameraYaw);
		//headMatrix = headMatrix * RotationFromDirection(frustum->facingDirection);
		yawOffset = 0.0f;
	}

	Matrix4 viewMatrix = (headMatrix).scale(Game::instance.MetresToWorld(1.0f));
	Matrix3 rotationMatrix = GetRotationMatrix(headMatrix);

	/*Vector3 rightVec = frustum->facingDirection.cross(frustum->upDirection);

	frustum->position += rightVec * DIST * (float)(2 * eye - 1);*/

	frustum->fov = FOVTotal; // 60 degrees normally

	frustum->facingDirection = Vector3(1.0f, 0.0f, 0.0f);
	frustum->upDirection = Vector3(0.0f, 0.0f, -1.0f);

	frustum->facingDirection = (rotationMatrix * frustum->facingDirection).normalize();
	frustum->upDirection = (rotationMatrix * frustum->upDirection).normalize();

	Vector3 newPos = viewMatrix * Vector3(0.0f, 0.0f, 0.0f);

	frustum->position = frustum->position + newPos;
}

Matrix4 WinXrApi::GetControllerTransform(ControllerRole role, bool bRenderPose)
{
	Matrix4 outMatrix;

	float offX = 0;
	float offZ = 0;

	bool unboundedSpace = Game::instance.c_NonstationaryBoundary->Value();

	if (unboundedSpace)
	{
		offX = hmdVirtualOffset.x;
		offZ = hmdVirtualOffset.z;
	}

	Vector3 bonePos = Vector3(LHandPos.x - offX, LHandPos.y, LHandPos.z - offZ);
	Vector4 quat = Vector4(LHandQuat.x, LHandQuat.y, -LHandQuat.z, LHandQuat.w);

	if (role == (Game::instance.bLeftHanded ? ControllerRole::Right : ControllerRole::Left))
	{
		if (!Game::instance.bLeftHanded) {
			bonePos = Vector3(LHandPos.x - offX, LHandPos.y, LHandPos.z - offZ);
			quat = Vector4(LHandQuat.x, LHandQuat.y, -LHandQuat.z, LHandQuat.w);
		}
		else {
			bonePos = Vector3(RHandPos.x - offX, RHandPos.y, RHandPos.z - offZ);
			quat = Vector4(RHandQuat.x, RHandQuat.y, -RHandQuat.z, RHandQuat.w);
		}
	}
	else {
		if (!Game::instance.bLeftHanded) {
			bonePos = Vector3(RHandPos.x - offX, RHandPos.y, RHandPos.z - offZ);
			quat = Vector4(RHandQuat.x, RHandQuat.y, -RHandQuat.z, RHandQuat.w);
		}
		else {
			bonePos = Vector3(LHandPos.x - offX, LHandPos.y, LHandPos.z - offZ);
			quat = Vector4(LHandQuat.x, LHandQuat.y, -LHandQuat.z, LHandQuat.w);
		}
	}

	Vector4 rollInversion = Vector4(0.0f, 0.0f, 1.0f, 0.0f); // Quaternion for 180-degree rotation around Z-axis
	quat = QuaternionMultiply(quat, rollInversion);

	Matrix4 boneMatrix;
	Transform tempTransform;
	Helpers::MakeTransformFromQuat(&quat, &tempTransform);

	for (int x = 0; x < 3; x++)
	{
		for (int y = 0; y < 3; y++)
		{
			// Not sure why get is const, you can directly set the values with setrow/setcolumn anyway
			const_cast<float*>(boneMatrix.get())[x + y * 4] = tempTransform.rotation[x + y * 3];
		}
	}

	boneMatrix.setColumn(3, bonePos);

	Matrix4 boneMatrixGame(
		boneMatrix.get()[2 + 2 * 4], boneMatrix.get()[0 + 2 * 4], -boneMatrix.get()[1 + 2 * 4], 0.0,
		boneMatrix.get()[2 + 0 * 4], boneMatrix.get()[0 + 0 * 4], -boneMatrix.get()[1 + 0 * 4], 0.0,
		-boneMatrix.get()[2 + 1 * 4], -boneMatrix.get()[0 + 1 * 4], boneMatrix.get()[1 + 1 * 4], 0.0,
		-boneMatrix.get()[2 + 3 * 4], -boneMatrix.get()[0 + 3 * 4], boneMatrix.get()[1 + 3 * 4], 1.0f
	);

	Vector3 pos = boneMatrixGame * Vector3(0.0f, 0.0f, 0.0f);
	boneMatrixGame.translate(-pos);
	boneMatrixGame.rotate(180.0f, boneMatrixGame * Vector3(0.0f, 0.0f, 1.0f));
	boneMatrixGame.rotate(180.0f, boneMatrixGame * Vector3(0.0f, 1.0f, 0.0f));
	boneMatrixGame.rotate(180.0f, boneMatrixGame * Vector3(1.0f, 0.0f, 0.0f));
	if (UpsideDownHandsFix) boneMatrixGame.rotate(180.0f, boneMatrixGame * Vector3(1.0f, 0.0f, 0.0f));
	boneMatrixGame.translate(pos).translate(-positionOffset).rotateZ(-yawOffset);;

	outMatrix = outMatrix * boneMatrixGame;

	return outMatrix;
}

Vector4 WinXrApi::QuaternionMultiply(const Vector4& q1, const Vector4& q2) {
	return Vector4(
		q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y,
		q1.w * q2.y - q1.x * q2.z + q1.y * q2.w + q1.z * q2.x,
		q1.w * q2.z + q1.x * q2.y - q1.y * q2.x + q1.z * q2.w,
		q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z
	);
}

Matrix4 WinXrApi::RotationFromDirection(Vector3 direction) {
	direction = direction.normalize();

	Vector3 up = Vector3(0, 1, 0);
	if (fabs(direction.dot(up)) > 0.99f) {

		up = Vector3(1, 0, 0);
	}

	Vector3 right = direction.cross(up).normalize();
	Vector3 newUp = right.cross(direction).normalize();

	Matrix4 rotation(
		right.x, right.y, right.z, 0,
		newUp.x, newUp.y, newUp.z, 0,
		-direction.x, -direction.y, -direction.z, 0,
		0, 0, 0, 1
	);

	return rotation;
}

Matrix4 WinXrApi::GetHMDTransform(bool bRenderPose)
{
	Matrix4 outMatrix;

	bool unboundedSpace = Game::instance.c_NonstationaryBoundary->Value();

	if (!unboundedSpace)
	{
		hmdVirtualOffset = Vector3(0.0f, 0.0f, 0.0f);
	}

	Vector3 bonePos = Vector3(HMDPos.x - hmdVirtualOffset.x, HMDPos.y - hmdVirtualOffset.y, HMDPos.z - hmdVirtualOffset.z);
	Vector4 quat = Vector4(HMDQuat.x, HMDQuat.y, -HMDQuat.z, HMDQuat.w);

	Vector4 rollInversion = Vector4(0.0f, 0.0f, 1.0f, 0.0f); // Quaternion for 180-degree rotation around Z-axis
	quat = QuaternionMultiply(quat, rollInversion);

	Matrix4 boneMatrix;
	Transform tempTransform;
	Helpers::MakeTransformFromQuat(&quat, &tempTransform);

	for (int x = 0; x < 3; x++)
	{
		for (int y = 0; y < 3; y++)
		{
			// Not sure why get is const, you can directly set the values with setrow/setcolumn anyway
			const_cast<float*>(boneMatrix.get())[x + y * 4] = tempTransform.rotation[x + y * 3];
		}
	}

	boneMatrix.setColumn(3, bonePos);

	Matrix4 boneMatrixGame(
		boneMatrix.get()[2 + 2 * 4], boneMatrix.get()[0 + 2 * 4], -boneMatrix.get()[1 + 2 * 4], 0.0,
		boneMatrix.get()[2 + 0 * 4], boneMatrix.get()[0 + 0 * 4], -boneMatrix.get()[1 + 0 * 4], 0.0,
		-boneMatrix.get()[2 + 1 * 4], -boneMatrix.get()[0 + 1 * 4], boneMatrix.get()[1 + 1 * 4], 0.0,
		-boneMatrix.get()[2 + 3 * 4], -boneMatrix.get()[0 + 3 * 4], boneMatrix.get()[1 + 3 * 4], 1.0f
	);

	Vector3 pos = boneMatrixGame * Vector3(0.0f, 0.0f, 0.0f);
	boneMatrixGame.translate(-pos);
	boneMatrixGame.rotate(180.0f, boneMatrixGame * Vector3(0.0f, 0.0f, 1.0f));
	boneMatrixGame.rotate(180.0f, boneMatrixGame * Vector3(0.0f, 1.0f, 0.0f));
	boneMatrixGame.rotate(180.0f, boneMatrixGame * Vector3(1.0f, 0.0f, 0.0f));

	boneMatrixGame.translate(pos).translate(-positionOffset).rotateZ(-yawOffset);

	outMatrix = outMatrix * boneMatrixGame;

	return outMatrix;
}

Matrix4 WinXrApi::GetRawControllerTransform(ControllerRole role, bool bRenderPose)
{
	return GetControllerTransform(role, bRenderPose);
}

Matrix4 WinXrApi::GetControllerBoneTransform(ControllerRole role, int bone, bool bRenderPose)
{
	return GetControllerTransform(role, bRenderPose);
}

Vector3 WinXrApi::GetControllerVelocity(ControllerRole Role, bool bRenderPose)
{
	float swingSpd = 0.0f;

	int newestFrame = lastPosFrame - 1;
	if (newestFrame < 0) newestFrame = 4;

	int oldestFrame = lastPosFrame + 1;
	if (oldestFrame > 4) oldestFrame = 0;

	float sensitivity = Game::instance.c_MeleeSwingVelocitySensitivity->Value();

	if (Role == ControllerRole::Left) {
		//Check left hand controller speed
		Vector3 displacement = prevLHandPos[newestFrame] - prevLHandPos[oldestFrame];
		swingSpd = sqrtf(displacement.x * displacement.x + displacement.y * displacement.y + displacement.z * displacement.z) * sensitivity;
	}
	else
	{
		//Check right hand controller speed
		Vector3 displacement = prevRHandPos[newestFrame] - prevRHandPos[oldestFrame];
		swingSpd = sqrtf(displacement.x * displacement.x + displacement.y * displacement.y + displacement.z * displacement.z) * sensitivity;
	}

	return Vector3(0.0f, 0.0f, swingSpd);
}

bool WinXrApi::TryGetControllerFacing(ControllerRole role, Vector3& outDirection)
{
	return false;
}

IDirect3DSurface9* WinXrApi::GetRenderSurface(int eye)
{
	return eyeSurface_Game[eye][0];
}

IDirect3DTexture9* WinXrApi::GetRenderTexture(int eye)
{
	return eyeTexture_Game[eye][0];
}

IDirect3DSurface9* WinXrApi::GetUISurface()
{
	return uiSurface;
}

IDirect3DSurface9* WinXrApi::GetCrosshairSurface()
{
	return crosshairSurface;
}

IDirect3DSurface9* WinXrApi::GetScopeSurface()
{
	return scopeSurface;
}

IDirect3DTexture9* WinXrApi::GetScopeTexture()
{
	return scopeTexture;
}

void WinXrApi::SetCrosshairTransform(Matrix4& newTransform)
{
	Vector3 pos = (newTransform * Vector3(0.0f, 0.0f, 0.0f)) * Game::instance.MetresToWorld(1.0f) + Helpers::GetCamera().position;
	Matrix3 rot;
	Vector2 size(1.33f, 1.0f);
	size *= Game::instance.MetresToWorld(15.0f);

	newTransform.translate(-pos);
	newTransform.rotate(90.0f, newTransform.getLeftAxis());
	newTransform.rotate(-90.0f, newTransform.getUpAxis());
	newTransform.rotate(-90.0f, newTransform.getLeftAxis());

	for (int i = 0; i < 3; i++)
	{
		rot.setColumn(i, &newTransform.get()[i * 4]);
	}

	Game::instance.inGameRenderer.DrawRenderTarget(crosshairTexture, pos, rot, size, false);
}

void WinXrApi::UpdateInputs()
{
	//BINDINGS:
	//{ "Jump", VK_SPACE },
	//{ "SwitchGrenades", 'G' },
	//{ "Interact", 'E' },
	//{ "SwitchWeapons", VK_TAB },
	//{ "Melee", 'Q' },
	//{ "Flashlight", 'F' },
	//{ "Grenade", VK_RBUTTON },
	//{ "Fire", VK_LBUTTON },
	//{ "MenuBack", 'P' }, // Intentionally weird binding because we don't override this in the same way and it would conflict
	//{ "Crouch", VK_LCONTROL },
	//{ "Zoom", 'Z' },
	//{ "Reload", 'R' },
	//{ "EMU_MoveHandSwap", 'H' }

	//Jump
	bindings[0].bHasChanged = LGrip != bindings[0].bPressed;
	bindings[0].bPressed = LGrip;

	//Switch Grenades
	bindings[1].bHasChanged = L_X != bindings[1].bPressed;
	bindings[1].bPressed = L_X;

	//Interact
	bindings[2].bHasChanged = R_A != bindings[2].bPressed;
	bindings[2].bPressed = R_A;

	//Switch Weapons
	bindings[3].bHasChanged = R_ThumbUp != bindings[3].bPressed;
	bindings[3].bPressed = R_ThumbUp;

	//Melee
	bindings[4].bHasChanged = R_ThumbDown != bindings[4].bPressed;
	bindings[4].bPressed = R_ThumbDown;

	//Flashlight
	bindings[5].bHasChanged = L_Y != bindings[5].bPressed;
	bindings[5].bPressed = L_Y;

	//Grenade
	bindings[6].bHasChanged = RGrip != bindings[6].bPressed;
	bindings[6].bPressed = RGrip;

	//Fire
	bindings[7].bHasChanged = RTrigger != bindings[7].bPressed;
	bindings[7].bPressed = RTrigger;

	//MenuBack
	bindings[8].bHasChanged = L_Menu != bindings[8].bPressed;
	bindings[8].bPressed = L_Menu;

	//Crouch
	bindings[9].bHasChanged = LClick != bindings[9].bPressed;
	bindings[9].bPressed = LClick;

	//Zoom
	bindings[10].bHasChanged = LTrigger != bindings[10].bPressed;
	bindings[10].bPressed = LTrigger;

	//Reload
	bindings[11].bHasChanged = R_B != bindings[11].bPressed;
	bindings[11].bPressed = R_B;

	//Looking
	axes1D[2] = RThumbstick.x;
	axes1D[3] = RThumbstick.y;

	//Movement
	axes1D[0] = LThumbstick.x;
	axes1D[1] = LThumbstick.y;

	//Extra movement tweaks
	if (pastFirstFrame) {
		bool enableNonStationary = Game::instance.c_NonstationaryBoundary->Value();

		bool mouseVisible = Helpers::IsMouseVisible();

		CutsceneData* cutscene = Helpers::GetCutsceneData();

		if (cutscene->bInCutscene)
		{
			//Can't move during a cutscene
			movingBody = false;

			if (enableNonStationary) {
				hmdCenterPos = HMDPos;
				lastCenterGameCoords = Vector3(playerCoords.x, playerCoords.y, playerCoords.z - 0.62f);
			}
		}
		else if (usingVirtualLocomotion) {
			//Movement via thumbstick takes priority always

			if (enableNonStationary) {
				hmdCenterPos = HMDPos;
				lastCenterGameCoords = Vector3(playerCoords.x, playerCoords.y, playerCoords.z - 0.62f);
			}

			movingBody = false;
		}
		else if (enableNonStationary && !mouseVisible) {
			//Try to determine if the player is going to move based on 6DOF head position, and which way they will move	
			float moveX = 0.0f;
			float moveY = 0.0f;

			// Thanks to code by Luboš of TeamBeef and WinlatorXR!
			// https://github.com/lvonasek/xash3d-fwgs/blob/bb7e9445534fca9ddfb58e2fe66a4bc6ed35d5ef/engine/common/host_vr.c#L835	
			float movementScale = 0.225f; //Player moves about 2 to 2.25 units per second according to Google
			float pMoveThreshold = 0.05f;

			if (movingBody) {
				Vector2 playerDiff = Vector2((playerCoords.x - lastPlayerCoords.x) / movementScale, (playerCoords.y - lastPlayerCoords.y) / movementScale);
				float lerp = sqrt(powf(playerDiff.x, 2.0f) + powf(playerDiff.y, 2.0f));
				Vector3 tryOffset = Helpers::Lerp(hmdVirtualOffset, HMDPos, lerp);
				hmdVirtualOffset = Vector3(tryOffset.x, hmdVirtualOffset.y, tryOffset.z);

				centerUpdateCounter += 1;

				int walkScale = 3; //(int)
				float confScale = Game::instance.c_NonstationaryWalkScale->Value();

				walkScale = static_cast<int>(floor(confScale));

				if (centerUpdateCounter > (64 * walkScale)) {
					hmdCenterPos = lastHMDPos;
					lastCenterGameCoords = Vector3(lastPlayerCoords.x, lastPlayerCoords.y, lastPlayerCoords.z - 0.62f);
					centerUpdateCounter -= (64 * walkScale);
				}
			}
			else {
				centerUpdateCounter = 0;
			}

			float realYaw = 0;

			Vector4 q = Vector4(HMDQuat.x, HMDQuat.y, -HMDQuat.z, HMDQuat.w);

			Vector4 rollInversion = Vector4(0.0f, 0.0f, 1.0f, 0.0f); // Quaternion for 180-degree rotation around Z-axis
			q = QuaternionMultiply(q, rollInversion);

			float atanY = 2.0f * (q.w * q.y - q.z * q.x);
			float atanX = 1.0f - 2.0f * (q.y * q.y + q.z * q.z);

			if (atanY != 0 || atanX != 0) {
				realYaw = atan2(atanY, atanX);
			}

			float hm_dx = HMDPos.x - hmdCenterPos.x;
			float hm_dz = HMDPos.z - hmdCenterPos.z;
			float p_dist = 0;

			if (hm_dx * hm_dx + hm_dz * hm_dz != 0) {
				p_dist = sqrt(hm_dx * hm_dx + hm_dz * hm_dz);
			}

			float offsetRight = hm_dx * cos(realYaw) - hm_dz * sin(realYaw);
			float offsetForward = hm_dz * cos(realYaw) + hm_dx * sin(realYaw);

			if (wasUsingVirtualLocomotion || (abs(lastCenterGameCoords.x) < 0.5f && abs(lastCenterGameCoords.y) < 0.5f && abs(lastCenterGameCoords.z < 0.5f))) {
				Recentre();
			}

			if (p_dist > pMoveThreshold) {
				//We're moving the body to catch up to the head
				Vector3 lookHMD = GetHMDTransform().getLeftAxis();
				Vector3 lookGame = Game::instance.bDetectedChimera ? Game::instance.LastLookDir : Helpers::GetCamera().lookDir;
				float yawHMD = atan2(lookHMD.y, lookHMD.x);
				float yawGame = atan2(lookGame.y, lookGame.x);

				float yaw = yawHMD - yawGame;

				float dx = -offsetRight / movementScale; //hm_dx / movementScale;
				float dy = offsetForward / movementScale; //-hm_dz / movementScale;

				moveX = dx * cos(yaw) - dy * sin(yaw);
				moveY = dx * sin(yaw) + dy * cos(yaw);
				moveX *= movementScale;
				moveY *= movementScale;
				movingBody = true;
			}
			else if (movingBody) {
				movingBody = false;
			}

			axes1D[0] = moveX;
			axes1D[1] = moveY;
		}

		wasUsingVirtualLocomotion = usingVirtualLocomotion;
		lastPlayerCoords = playerCoords;
		lastHMDPos = HMDPos;
	}

	pastFirstFrame = true;
}

void WinXrApi::Recentre()
{
	SetLocationOffset(Vector3(0.0f, 0.0f, 0.0f));
	Vector3 hmdPosWithOffset = (GetHMDTransform() * Vector3(0, 0, 0));
	hmdVirtualOffset = HMDPos;
	hmdCenterPos = HMDPos;

	lastCenterGameCoords = Vector3(playerCoords.x + hmdPosWithOffset.x, playerCoords.y + hmdPosWithOffset.z, playerCoords.z - 0.62f);
}

void WinXrApi::SetLocationOffset(Vector3 newOffset)
{
	positionOffset = newOffset;
}

Vector3 WinXrApi::GetLocationOffset()
{
	return positionOffset;
}

void WinXrApi::SetYawOffset(float newOffset)
{
	yawOffset = newOffset;
}

float WinXrApi::GetYawOffset()
{
	return yawOffset;
}

InputBindingID WinXrApi::RegisterBoolInput(std::string set, std::string action)
{
	for (size_t i = 0; i < arraySize(bindings); i++)
	{
		if (bindings[i].bindingName == action)
		{
			return i;
		}
	}
	return 999;
}

InputBindingID WinXrApi::RegisterVector2Input(std::string set, std::string action)
{
	for (size_t i = 0; i < arraySize(axes2D); i++)
	{
		if (axes2D[i].axisName == action)
		{
			return i;
		}
	}
	return 999;
}

bool WinXrApi::GetBoolInput(InputBindingID id)
{
	static bool bDummy = false;
	return GetBoolInput(id, bDummy);
}

bool WinXrApi::GetBoolInput(InputBindingID id, bool& bHasChanged)
{
	if (id < arraySize(bindings))
	{
		bHasChanged = bindings[id].bHasChanged;
		return bindings[id].bPressed;
	}
	return false;
}

Vector2 WinXrApi::GetVector2Input(InputBindingID id)
{
	if (id < arraySize(axes2D))
	{
		return Vector2(axes1D[axes2D[id].indexX], axes1D[axes2D[id].indexY]);
	}
	return Vector2();
}

void WinXrApi::ShowKeyboard(const std::string& textBuffer)
{
	bKeyboardActive = true;
	keyboardBuffer = textBuffer;
}

bool WinXrApi::IsKeyboardVisible()
{
	return bKeyboardActive;
}

void WinXrApi::HideKeyboard()
{
	bKeyboardActive = false;
	keyboardBuffer = "";
}

std::string WinXrApi::GetKeyboardInput()
{
	return keyboardBuffer;
}

std::string WinXrApi::GetDeviceName()
{
	return "WinlatorXR";
}

void WinXrApi::PreDrawFrame(struct Renderer* renderer, float deltaTime)
{
	/*if (!mirrorDevice)
	{
		Logger::log << "No Mirror Device, can't draw" << std::endl;
		return;
	}

	HRESULT result;

	result = mirrorDevice->BeginScene();
	if (FAILED(result))
	{
		Logger::log << "Failed to call mirror begin scene: " << result << std::endl;
	}*/

	auto fixupRotation = [](Matrix4& m, Vector3& pos) {
		m.translate(-pos);
		m.rotate(90.0f, m.getUpAxis());
		m.rotate(-90.0f, m.getLeftAxis());
		m.translate(pos);
		};

	CutsceneData* cutscene = Helpers::GetCutsceneData();

	if (cutscene->bInCutscene || Helpers::IsMouseVisible())
	{
		//Seems a good spot to snapshot playerCoords
		playerCoords = Helpers::GetCamera().position;

		Matrix4 overlayTransform;

		Vector3 targetPos = GetHMDTransform(true).getLeftAxis() * Game::instance.WorldToMetres(8.0f); //GetHMDTransform(true).getAngle().normalize() * Game::instance.WorldToMetres(3.0f);

		Vector3 hmdPos = GetHMDTransform(true) * Vector3(0.0f, 0.0f, 0.0f);

		overlayTransform.translate(targetPos);
		overlayTransform.lookAt(hmdPos, Vector3(0.0f, 0.0f, 1.0f));

		fixupRotation(overlayTransform, targetPos);

		Vector3 pos = (overlayTransform * Vector3(0.0f, 0.0f, 0.0f)) * Game::instance.MetresToWorld(1.0f) + Helpers::GetCamera().position;
		Matrix3 rot;
		Vector2 size(1.33f, 1.0f);
		size *= Game::instance.MetresToWorld(15.0f);

		overlayTransform.translate(-pos);
		overlayTransform.rotate(90.0f, overlayTransform.getLeftAxis());
		overlayTransform.rotate(-90.0f, overlayTransform.getUpAxis());
		overlayTransform.rotate(-90.0f, overlayTransform.getLeftAxis());

		for (int i = 0; i < 3; i++)
		{
			rot.setColumn(i, &overlayTransform.get()[i * 4]);
		}

		Game::instance.inGameRenderer.DrawRenderTarget(uiTexture, pos, rot, size, false);
	}
	else {
		Vector3 camPos = Helpers::GetCamera().position;
		playerCoords = camPos;

		Vector3 pos = Helpers::GetCamera().position + Helpers::GetCamera().lookDir * Game::instance.MetresToWorld(3.0f);

		Matrix3 rot;
		Vector2 size(1.33f, 1.0f);
		size *= Game::instance.MetresToWorld(2.0f);

		Matrix4 overlayTransform;

		overlayTransform.translate(pos);
		overlayTransform.lookAt(camPos, Vector3(0.0f, 0.0f, 1.0f));

		overlayTransform.translate(-pos);
		overlayTransform.rotate(-90.0f, overlayTransform.getLeftAxis());
		overlayTransform.translate(camPos);

		for (int i = 0; i < 3; i++)
		{
			rot.setColumn(i, &overlayTransform.get()[i * 4]);
		}

		Game::instance.inGameRenderer.DrawRenderTarget(uiTexture, pos, rot, size, false);
	}

	//Game::instance.inGameRenderer.DrawCoordinate(pos, rot, 0.05f, false);
}

void WinXrApi::DrawEye(struct Renderer* renderer, float deltaTime, int eye)
{
	//IDirect3DSurface9* mirrorSurface = nullptr;
	//HRESULT result = mirrorDevice->GetBackBuffer(0, 0, D3DBACKBUFFER_TYPE_MONO, &mirrorSurface);

	//if (FAILED(result))
	//{
	//	Logger::log << "Failed to get mirror back buffer: " << result << std::endl;
	//}

	//D3DSURFACE_DESC mirrorDesc;

	//mirrorSurface->GetDesc(&mirrorDesc);

	//UINT halfWidth = mirrorDesc.Width / 2;

	//RECT rcDest;
	//rcDest.left = eye * halfWidth;
	//rcDest.top = 0;
	//rcDest.right = halfWidth + eye * halfWidth;
	//rcDest.bottom = mirrorDesc.Height;

	//// Flip eyes for cross eyed
	//result = mirrorDevice->StretchRect(eyeSurface_VR[1 - eye][0], nullptr, mirrorSurface, &rcDest, D3DTEXF_NONE);

	//if (FAILED(result))
	//{
	//	Logger::log << "Failed to copy from shared texture (" << eye << "): " << result << std::endl;
	//}

	//mirrorSurface->Release();
}

void WinXrApi::PostDrawFrame(struct Renderer* renderer, float deltaTime)
{
	/*IDirect3DQuery9* pEventQuery = nullptr;
	Helpers::GetDirect3DDevice9()->CreateQuery(D3DQUERYTYPE_EVENT, &pEventQuery);
	if (pEventQuery != nullptr)
	{
		pEventQuery->Issue(D3DISSUE_END);
		while (pEventQuery->GetData(nullptr, 0, D3DGETDATA_FLUSH) != S_OK);
		pEventQuery->Release();
	}*/

	//DrawEye(renderer, deltaTime, 0);
	//DrawEye(renderer, deltaTime, 1);

	/*HRESULT result = mirrorDevice->EndScene();
	if (FAILED(result))
	{
		Logger::log << "Failed to end scene: " << result << std::endl;
	}*/

	/*result = mirrorDevice->Present(nullptr, nullptr, nullptr, nullptr);
	if (FAILED(result))
	{
		Logger::log << "Failed to present mirror view: " << result << std::endl;
	}*/
}

void WinXrApi::CreateSharedTarget()
{
	D3DSURFACE_DESC desc;

	Helpers::GetRenderTargets()[0].renderSurface->GetDesc(&desc);

	D3DSURFACE_DESC desc2;

	Helpers::GetRenderTargets()[1].renderSurface->GetDesc(&desc2);

	const UINT width = GetViewWidth();
	const UINT height = GetViewHeight();

	CreateTexAndSurface(0, width, height, desc.Usage, desc.Format);
	CreateTexAndSurface(1, width, height, desc.Usage, desc.Format);

	HRESULT res = Helpers::GetDirect3DDevice9()->CreateTexture(Game::instance.overlayWidth, Game::instance.overlayHeight, 1, desc2.Usage, desc2.Format, D3DPOOL_DEFAULT, &uiTexture, NULL);

	if (FAILED(res))
	{
		Logger::log << "Couldn't create UI texture: " << res << std::endl;
	}

	res = uiTexture->GetSurfaceLevel(0, &uiSurface);

	if (FAILED(res))
	{
		Logger::log << "Couldn't create UI render target: " << res << std::endl;
	}

	res = Helpers::GetDirect3DDevice9()->CreateTexture(Game::instance.overlayWidth, Game::instance.overlayHeight, 1, desc2.Usage, desc2.Format, D3DPOOL_DEFAULT, &crosshairTexture, NULL);

	if (FAILED(res))
	{
		Logger::log << "Couldn't create crosshair texture: " << res << std::endl;
	}

	res = crosshairTexture->GetSurfaceLevel(0, &crosshairSurface);

	if (FAILED(res))
	{
		Logger::log << "Couldn't create crosshair render target: " << res << std::endl;
	}

	res = Helpers::GetDirect3DDevice9()->CreateTexture(GetScopeWidth(), GetScopeHeight(), 1, desc.Usage, desc.Format, D3DPOOL_DEFAULT, &scopeTexture, NULL);

	if (FAILED(res))
	{
		Logger::log << "Couldn't create scope texture: " << res << std::endl;
	}

	res = scopeTexture->GetSurfaceLevel(0, &scopeSurface);

	if (FAILED(res))
	{
		Logger::log << "Couldn't create scope render target: " << res << std::endl;
	}
}


void WinXrApi::CreateTexAndSurface(int index, UINT width, UINT height, DWORD usage, D3DFORMAT format)
{
	for (int i = 0; i < 2; i++)
	{
		HANDLE sharedHandle = nullptr;

		// Create texture on game

		HRESULT result = Helpers::GetDirect3DDevice9()->CreateTexture(width, height, 1, usage, format, D3DPOOL_DEFAULT, &eyeTexture_Game[i][index], &sharedHandle);
		if (FAILED(result))
		{
			Logger::log << "Failed to create game " << index << " texture: " << result << std::endl;
		}

		//// Created shared texture on vr
		//result = mirrorDevice->CreateTexture(width, height, 1, usage, format, D3DPOOL_DEFAULT, &eyeTexture_VR[i][index], &sharedHandle);
		//if (FAILED(result))
		//{
		//	Logger::log << "Failed to create vr " << index << " texture: " << result << std::endl;
		//}

		// Extract game surface
		result = eyeTexture_Game[i][index]->GetSurfaceLevel(0, &eyeSurface_Game[i][index]);

		if (FAILED(result))
		{
			Logger::log << "Failed to get game render surface from " << index << ": " << result << std::endl;
		}

		//// Extract vr surface
		//result = eyeTexture_VR[i][index]->GetSurfaceLevel(0, &eyeSurface_VR[i][index]);

		//if (FAILED(result))
		//{
		//	Logger::log << "Failed to get vr render surface from " << index << ": " << result << std::endl;
		//}
	}
}

WinXrApi::~WinXrApi()
{
	Logger::log << "[WinXrApi] ending WinlatorXR VR mode..." << std::endl;

	std::filesystem::path dirPath = "Z:/tmp/xr";
	std::filesystem::path fallbackDir = "D:/xrtemp";
	std::filesystem::path filePath = dirPath / "vr";
	std::filesystem::path fallbackFile = fallbackDir / "vr";

	if (std::filesystem::exists(filePath) && std::filesystem::is_regular_file(filePath)) {
		try {
			std::filesystem::remove(filePath);
		}
		catch (const std::exception& e) {
			Logger::log << "Error deleting file: " << e.what() << std::endl;
		}
	}
	else {
		try {
			std::filesystem::remove(fallbackFile);
		}
		catch (const std::exception& e) {
			Logger::log << "Error deleting file: " << e.what() << std::endl;
		}
	}
}
