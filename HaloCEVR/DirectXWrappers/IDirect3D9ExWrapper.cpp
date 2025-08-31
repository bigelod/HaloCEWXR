#include "IDirect3D9ExWrapper.h"
#include "IDirect3DDevice9ExWrapper.h"
#include "../Logger.h"
#include "../Game.h"

HRESULT IDirect3D9ExWrapper::CreateDevice(UINT Adapter, D3DDEVTYPE DeviceType, HWND hFocusWindow, DWORD BehaviorFlags, D3DPRESENT_PARAMETERS* pPresentationParameters, IDirect3DDevice9** ppReturnedDeviceInterface)
{
	Logger::log << "Intercepting CreateDevice, creating wrapped Ex version" << std::endl;

	Logger::log << "Given present params: " << pPresentationParameters->PresentationInterval << ", " << pPresentationParameters->BackBufferWidth << ", " << pPresentationParameters->BackBufferHeight << std::endl;
	pPresentationParameters->PresentationInterval = D3DPRESENT_INTERVAL_IMMEDIATE;
	
	// It should be possible to avoid this hack by using a similar approach to scope, but the code path is slightly different
	if (pPresentationParameters->BackBufferWidth != 1200 || pPresentationParameters->BackBufferHeight != 600)
	{
		pPresentationParameters->BackBufferWidth = Game::instance.backBufferWidth;
		pPresentationParameters->BackBufferHeight = Game::instance.backBufferHeight;
		Logger::log << "New dimensions: " << Game::instance.backBufferWidth << "x" << Game::instance.backBufferHeight << std::endl;
	}

	Logger::log << "Creating with Adapter: " << Adapter << std::endl;

	IDirect3DDevice9Ex* RealDevice = nullptr;
	HRESULT Result = Real->CreateDeviceEx(Adapter, DeviceType, hFocusWindow, BehaviorFlags, pPresentationParameters, NULL, &RealDevice);

	if (SUCCEEDED(Result))
	{
		*ppReturnedDeviceInterface = new IDirect3DDevice9ExWrapper(RealDevice);
	}
	else
	{
		*ppReturnedDeviceInterface = nullptr;
	}

	return Result;
}

HRESULT __stdcall IDirect3D9ExWrapper::QueryInterface(REFIID riid, void** ppvObj)
{
	return Real->QueryInterface(riid, ppvObj);
}

ULONG __stdcall IDirect3D9ExWrapper::AddRef(void)
{
	return Real->AddRef();
}

ULONG __stdcall IDirect3D9ExWrapper::Release(void)
{
	Game::instance.Shutdown();
	return Real->Release();
}

HRESULT __stdcall IDirect3D9ExWrapper::RegisterSoftwareDevice(void* pInitializeFunction)
{
	return Real->RegisterSoftwareDevice(pInitializeFunction);
}

UINT __stdcall IDirect3D9ExWrapper::GetAdapterCount(void)
{
	return Real->GetAdapterCount();
}

HRESULT __stdcall IDirect3D9ExWrapper::GetAdapterIdentifier(UINT Adapter, DWORD Flags, D3DADAPTER_IDENTIFIER9* pIdentifier)
{
	return Real->GetAdapterIdentifier(Adapter, Flags, pIdentifier);
}

UINT __stdcall IDirect3D9ExWrapper::GetAdapterModeCount(UINT Adapter, D3DFORMAT Format)
{
	return Real->GetAdapterModeCount(Adapter, Format);
}

HRESULT __stdcall IDirect3D9ExWrapper::EnumAdapterModes(UINT Adapter, D3DFORMAT Format, UINT Mode, D3DDISPLAYMODE* pMode)
{
	return Real->EnumAdapterModes(Adapter, Format, Mode, pMode);
}

HRESULT __stdcall IDirect3D9ExWrapper::GetAdapterDisplayMode(UINT Adapter, D3DDISPLAYMODE* pMode)
{
	HRESULT result = Real->GetAdapterDisplayMode(Adapter, pMode);

	if (SUCCEEDED(result))
	{
		return result;
	}

	// There's a very weird bug on my Radeon machine where this call fails unless I swap the display's graphics format back and forth before launching
	// Hopefully if we just lie to halo about the result of this call nothing will break...
	Logger::log << "[D3D] WARNING! GetAdapterDisplayMode failed, lying about the results to shut up halo" << std::endl;

	pMode->Format = D3DFMT_X8R8G8B8;
	pMode->Width = 1080;
	pMode->Height = 1920;
	pMode->RefreshRate = 60;
	return S_OK;
}

HRESULT __stdcall IDirect3D9ExWrapper::CheckDeviceType(UINT Adapter, D3DDEVTYPE DevType, D3DFORMAT AdapterFormat, D3DFORMAT BackBufferFormat, BOOL bWindowed)
{
	return Real->CheckDeviceType(Adapter, DevType, AdapterFormat, BackBufferFormat, bWindowed);
}

HRESULT __stdcall IDirect3D9ExWrapper::CheckDeviceFormat(UINT Adapter, D3DDEVTYPE DeviceType, D3DFORMAT AdapterFormat, DWORD Usage, D3DRESOURCETYPE RType, D3DFORMAT CheckFormat)
{
	return Real->CheckDeviceFormat(Adapter, DeviceType, AdapterFormat, Usage, RType, CheckFormat);
}

HRESULT __stdcall IDirect3D9ExWrapper::CheckDeviceMultiSampleType(UINT Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SurfaceFormat, BOOL Windowed, D3DMULTISAMPLE_TYPE MultiSampleType, DWORD* pQualityLevels)
{
	return Real->CheckDeviceMultiSampleType(Adapter, DeviceType, SurfaceFormat, Windowed, MultiSampleType, pQualityLevels);
}

HRESULT __stdcall IDirect3D9ExWrapper::CheckDepthStencilMatch(UINT Adapter, D3DDEVTYPE DeviceType, D3DFORMAT AdapterFormat, D3DFORMAT RenderTargetFormat, D3DFORMAT DepthStencilFormat)
{
	return Real->CheckDepthStencilMatch(Adapter, DeviceType, AdapterFormat, RenderTargetFormat, DepthStencilFormat);
}

HRESULT __stdcall IDirect3D9ExWrapper::CheckDeviceFormatConversion(UINT Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SourceFormat, D3DFORMAT TargetFormat)
{
	return Real->CheckDeviceFormatConversion(Adapter, DeviceType, SourceFormat, TargetFormat);
}

HRESULT __stdcall IDirect3D9ExWrapper::GetDeviceCaps(UINT Adapter, D3DDEVTYPE DeviceType, D3DCAPS9* pCaps)
{
	return Real->GetDeviceCaps(Adapter, DeviceType, pCaps);
}

HMONITOR __stdcall IDirect3D9ExWrapper::GetAdapterMonitor(UINT Adapter)
{
	return Real->GetAdapterMonitor(Adapter);
}

UINT __stdcall IDirect3D9ExWrapper::GetAdapterModeCountEx(UINT Adapter, const D3DDISPLAYMODEFILTER* pFilter)
{
	return Real->GetAdapterModeCountEx(Adapter, pFilter);
}

HRESULT __stdcall IDirect3D9ExWrapper::EnumAdapterModesEx(UINT Adapter, const D3DDISPLAYMODEFILTER* pFilter, UINT Mode, D3DDISPLAYMODEEX* pMode)
{
	return Real->EnumAdapterModesEx(Adapter, pFilter, Mode, pMode);
}

HRESULT __stdcall IDirect3D9ExWrapper::GetAdapterDisplayModeEx(UINT Adapter, D3DDISPLAYMODEEX* pMode, D3DDISPLAYROTATION* pRotation)
{
	return Real->GetAdapterDisplayModeEx(Adapter, pMode, pRotation);
}

HRESULT __stdcall IDirect3D9ExWrapper::CreateDeviceEx(UINT Adapter, D3DDEVTYPE DeviceType, HWND hFocusWindow, DWORD BehaviorFlags, D3DPRESENT_PARAMETERS* pPresentationParameters, D3DDISPLAYMODEEX* pFullscreenDisplayMode, IDirect3DDevice9Ex** ppReturnedDeviceInterface)
{
	Logger::log << "Intercepting CreateDeviceEx, supplying wrapped version" << std::endl;
	IDirect3DDevice9Ex* RealDevice = nullptr;
	HRESULT Result = Real->CreateDeviceEx(Adapter, DeviceType, hFocusWindow, BehaviorFlags, pPresentationParameters, pFullscreenDisplayMode, &RealDevice);

	if (SUCCEEDED(Result))
	{
		*ppReturnedDeviceInterface = new IDirect3DDevice9ExWrapper(RealDevice);
	}
	else
	{
		*ppReturnedDeviceInterface = nullptr;
	}

	return Result;
}

HRESULT __stdcall IDirect3D9ExWrapper::GetAdapterLUID(UINT Adapter, LUID* pLUID)
{
	return Real->GetAdapterLUID(Adapter, pLUID);
}
