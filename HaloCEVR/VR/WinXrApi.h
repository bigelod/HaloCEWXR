#pragma once
#include "WinXrApiUDP.h"
#include "IVR.h"
#include <wtypes.h>
#include <d3d9.h>


class WinXrApi : public IVR
{
public:
	// Start Interface IVR
	void Init();
	void OnGameFinishInit();
	void Shutdown();
	void UpdatePoses();
	void PreDrawFrame(struct Renderer* renderer, float deltaTime);
	void PostDrawFrame(struct Renderer* renderer, float deltaTime);

	void UpdateCameraFrustum(struct CameraFrustum* frustum, int eye);

	int GetViewWidth() { return 1400; }
	int GetViewHeight() { return 1400; }
	float GetViewWidthStretch() { return 1.0f; }
	float GetViewHeightStretch() { return 1.0f; }
	float GetAspect() { return 1.0f; }
	int GetScopeWidth() { return 800; }
	int GetScopeHeight() { return 600; }
	void Recentre() {};
	void SetLocationOffset(Vector3 newOffset);
	Vector3 GetLocationOffset();
	void SetYawOffset(float newOffset);
	float GetYawOffset();
	Matrix4 GetHMDTransform(bool bRenderPose = false);
	Matrix4 GetControllerTransform(ControllerRole role, bool bRenderPose = false);
	Matrix4 GetRawControllerTransform(ControllerRole role, bool bRenderPose = false);
	Matrix4 GetControllerBoneTransform(ControllerRole role, int bone, bool bRenderPose = false);
	Vector3 GetControllerVelocity(ControllerRole role, bool bRenderPose = false);
	bool TryGetControllerFacing(ControllerRole role, Vector3& outDirection);
	struct IDirect3DSurface9* GetRenderSurface(int eye);
	struct IDirect3DTexture9* GetRenderTexture(int eye);
	struct IDirect3DSurface9* GetUISurface();
	struct IDirect3DSurface9* GetCrosshairSurface();
	struct IDirect3DSurface9* GetScopeSurface();
	struct IDirect3DTexture9* GetScopeTexture();
	void SetMouseVisibility(bool bIsVisible) {}
	void SetCrosshairTransform(class Matrix4& newTransform);
	void UpdateInputs();
	InputBindingID RegisterBoolInput(std::string set, std::string action);
	InputBindingID RegisterVector2Input(std::string set, std::string action);
	bool GetBoolInput(InputBindingID id);
	bool GetBoolInput(InputBindingID id, bool& bHasChanged);
	Vector2 GetVector2Input(InputBindingID id);
	Vector2 GetMousePos() { return Vector2(0.0f, 0.0f); }
	bool GetMouseDown() { return false; }
	void ShowKeyboard(const std::string& textBuffer);
	bool IsKeyboardVisible();
	void HideKeyboard();
	std::string GetKeyboardInput();
	std::string GetDeviceName();
	float IPDVal;
	float FOVH;
	float FOVV;
	float FOVTotal = 1.0472f;
	Vector4 QuaternionMultiply(const Vector4& q1, const Vector4& q2);
	Vector3 HMDPos;
	Vector3 LHandPos;
	Vector3 RHandPos;
	Vector4 HMDQuat;
	Vector4 LHandQuat;
	Vector4 RHandQuat;
	Vector2 LThumbstick;
	Vector2 RThumbstick;
	bool LTrigger = false;
	bool LGrip = false;
	bool LClick = false;
	bool RTrigger = false;
	bool RGrip = false;
	bool RClick = false;
	bool L_X = false;
	bool L_Y = false;
	bool R_A = false;
	bool R_B = false;
	bool L_Menu = false;
	bool R_ThumbDown = false;
	bool R_ThumbUp = false;
	// End Interface IVR
	~WinXrApi();

protected:
	void CreateSharedTarget();

	void CreateTexAndSurface(int index, UINT width, UINT height, DWORD usage, D3DFORMAT format);

	void DrawEye(struct Renderer* renderer, float deltaTime, int eye);

	Vector3 positionOffset;
	float yawOffset;

	HWND hWnd;
	struct IDirect3DDevice9* mirrorDevice = nullptr;

	struct IDirect3DSurface9* uiSurface = nullptr;
	struct IDirect3DTexture9* uiTexture = nullptr;
	struct IDirect3DSurface9* crosshairSurface = nullptr;
	struct IDirect3DTexture9* crosshairTexture = nullptr;
	struct IDirect3DSurface9* scopeSurface = nullptr;
	struct IDirect3DTexture9* scopeTexture = nullptr;
	struct IDirect3DSurface9* eyeSurface_Game[2][2];
	struct IDirect3DSurface9* eyeSurface_VR[2][2];

	struct IDirect3DTexture9* eyeTexture_Game[2][2];
	struct IDirect3DTexture9* eyeTexture_VR[2][2];

	struct Binding
	{
		std::string bindingName;
		int virtualKey = 0;
		bool bHasChanged = false;
		bool bPressed = false;
	};

	Binding bindings[13] = {
		{"Jump", VK_SPACE},
		{"SwitchGrenades", 'G'},
		{"Interact", 'E'},
		{"SwitchWeapons", VK_TAB},
		{"Melee", 'Q'},
		{"Flashlight", 'F'},
		{"Grenade", VK_RBUTTON},
		{"Fire", VK_LBUTTON},
		{"MenuBack", 'P'}, // Intentionally weird binding because we don't override this in the same way and it would conflict
		{"Crouch", VK_LCONTROL},
		{"Zoom", 'Z'},
		{"Reload", 'R'},
		{"EMU_MoveHandSwap", 'H'}
	};

	struct AxisBinding
	{
		int virtualKey = 0;
		int scale = 0;
		int axisId = 0;
	};

	struct Axis2D
	{
		std::string axisName;
		int indexX = 0;
		int indexY = 0;
	};

	float axes1D[4] = {
		0.0f,
		0.0f,
		0.0f,
		0.0f
	};

	Axis2D axes2D[2] =
	{
		{"Move", 0, 1},
		{"Look", 2, 3}
	};

	InputBindingID inputMoveHandFlat = 0;
	InputBindingID inputMoveHandVert = 0;
	InputBindingID inputMoveHandSwap = 0;
	bool bMoveHand = true;

	Vector3 mainHandOffset;
	Vector3 mainHandRot;

	bool bKeyboardActive = false;
	std::string keyboardBuffer;
	bool keystate[128];

	WinXrApiUDP* udpReader;
};

