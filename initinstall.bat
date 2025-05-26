@echo off
echo Configuring halo install directory for HaloCEVR...
set "DEFAULT_EXE=Halo.exe"
set /p EXE_DIR="Enter Halo install folder (e.g. C:\Program Files (x86)\Halo Combat Evolved): "
set /p EXE_NAME="Enter Halo executable name (default: %DEFAULT_EXE%): "
if "%EXE_NAME%"=="" set "EXE_NAME=%DEFAULT_EXE%"

echo Setting environment variables...
setx HALOCEVR_DIR %EXE_DIR%
setx HALOCEVR_EXE %EXE_NAME%

echo Executable directory: %HALOCEVR_DIR%
echo Executable name: %HALOCEVR_EXE%

set "FULL_PATH=%HALOCEVR_DIR%\%HALOCEVR_EXE%"

if exist "%FULL_PATH%" (
    echo [92m%FULL_PATH% is a valid halo installation. Builds should automatically launch halo once compiled.[0m
) else (
    echo [91mError: Can't find %FULL_PATH%! Builds will produce a valid d3d9.dll file, but will fail attempting to launch halo.[0m
)

pause