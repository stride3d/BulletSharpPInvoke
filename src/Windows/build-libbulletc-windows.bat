REM Windows
mkdir ..\build\bulletc\Windows\x86
pushd ..\build\bulletc\Windows\x86
cmake ..\..\..\..\libbulletc\ -G "Visual Studio 15" -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows\x86\lib
msbuild libbulletc.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir ..\build\bulletc\Windows\x64
pushd ..\build\bulletc\Windows\x64
cmake ..\..\..\..\libbulletc\ -G "Visual Studio 15 Win64" -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows\x64\lib
msbuild libbulletc.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

@REM Windows 10
mkdir ..\build\bulletc\Windows10\x86
pushd ..\build\bulletc\Windows10\x86
cmake ..\..\..\..\libbulletc\ -G "Visual Studio 15" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DBUILD_MULTITHREADING=OFF -DCMAKE_C_COMPILER_WORKS=FALSE -DBULLET_LIBS_DIR=..\..\..\bullet\Windows10\x86\lib
msbuild libbulletc.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir ..\build\bulletc\Windows10\x64
pushd ..\build\bulletc\Windows10\x64
cmake ..\..\..\..\libbulletc\ -G "Visual Studio 15 Win64" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows10\x64\lib
msbuild libbulletc.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir ..\build\bulletc\Windows10\ARM
pushd ..\build\bulletc\Windows10\ARM
cmake ..\..\..\..\libbulletc\ -G "Visual Studio 15 ARM" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows10\ARM\lib
msbuild libbulletc.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

GOTO :end
:error_popd
popd
echo Error during compilation
EXIT /B %ERRORLEVEL%
pause
:end
