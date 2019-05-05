REM Windows
mkdir msbuild\x86
pushd msbuild\x86
cmake ..\..\..\libbulletc\ -G "Visual Studio 16" -A Win32 -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows\x86\lib -DCMAKE_CXX_COMPILER:FILEPATH="c:/program files (x86)/microsoft visual studio/2019/preview/common7/ide/commonextensions/microsoft/Llvm/bin/clang-cl.exe" -DCMAKE_C_COMPILER:FILEPATH="c:/program files (x86)/microsoft visual studio/2019/preview/common7/ide/commonextensions/microsoft/Llvm/bin/clang-cl.exe"
cd /d "C:/Program Files (x86)/Microsoft Visual Studio/2019/Preview/MSBuild/Current/Bin"
msbuild E:\GitProject\BulletSharpPInvoke\src\msbuild\x86\libbulletc.sln /p:Configuration=Release /p:Toolset=clang_cl_x86 /p:CLToolExe=clang-cl.exe /p:CLToolPath="c:/program files (x86)/microsoft visual studio/2019/preview/common7/ide/commonextensions/microsoft/Llvm/bin/"
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir msbuild\x64
pushd msbuild\x64
cmake ..\..\..\libbulletc\ -G "Visual Studio 16" -A x64 -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows\x64\lib -DCMAKE_CXX_COMPILER:FILEPATH="c:/program files (x86)/microsoft visual studio/2019/preview/common7/ide/commonextensions/microsoft/Llvm/bin/clang-cl.exe" -DCMAKE_C_COMPILER:FILEPATH="c:/program files (x86)/microsoft visual studio/2019/preview/common7/ide/commonextensions/microsoft/Llvm/bin/clang-cl.exe"
cd /d "C:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Current\Bin"
msbuild E:\GitProject\BulletSharpPInvoke\src\msbuild\x64\libbulletc.sln /p:Configuration=Release /p:Toolset=clang_cl_x64 /p:CLToolExe=clang-cl.exe /p:CLToolPath="c:/program files (x86)/microsoft visual studio/2019/preview/common7/ide/commonextensions/microsoft/Llvm/bin/"
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

@REM Windows 10
mkdir msbuild\WStore_x86
pushd msbuild\WStore_x86
cmake ..\..\..\libbulletc\ -G "Visual Studio 15" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DBUILD_MULTITHREADING=OFF -DCMAKE_C_COMPILER_WORKS=FALSE -DBULLET_LIBS_DIR=..\..\..\bullet\Windows10\x86\lib
msbuild libbulletc.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir msbuild\WStore_x64
pushd msbuild\WStore_x64
cmake ..\..\..\libbulletc\ -G "Visual Studio 15 Win64" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows10\x64\lib
msbuild libbulletc.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir msbuild\WStore_ARM
pushd msbuild\WStore_ARM
cmake ..\..\..\libbulletc\ -G "Visual Studio 15 ARM" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DBUILD_MULTITHREADING=OFF -DBULLET_LIBS_DIR=..\..\..\bullet\Windows10\ARM\lib
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
