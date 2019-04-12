REM Windows
mkdir ..\build\bullet\Windows\x86
pushd ..\build\bullet\Windows\x86
cmake ..\..\..\..\bullet\ -G "Visual Studio 15" -DUSE_MSVC_RUNTIME_LIBRARY_DLL=ON -DBUILD_MULTITHREADING=OFF
msbuild BULLET_PHYSICS.sln /p:Configuration=Release /t:LinearMath:Rebuild;BulletCollision:Rebuild;BulletDynamics:Rebuild;BulletFileLoader:Rebuild;BulletSoftBody:Rebuild;BulletWorldImporter:Rebuild;BulletXmlWorldImporter:Rebuild
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir ..\build\bullet\Windows\x64
pushd ..\build\bullet\Windows\x64
cmake ..\..\..\..\bullet\ -G "Visual Studio 15 Win64" -DUSE_MSVC_RUNTIME_LIBRARY_DLL=ON -DBUILD_MULTITHREADING=OFF
msbuild BULLET_PHYSICS.sln /p:Configuration=Release /t:LinearMath:Rebuild;BulletCollision:Rebuild;BulletDynamics:Rebuild;BulletFileLoader:Rebuild;BulletSoftBody:Rebuild;BulletWorldImporter:Rebuild;BulletXmlWorldImporter:Rebuild
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

@REM Windows 10
mkdir ..\build\bullet\Windows10\x86
pushd ..\build\bullet\Windows10\x86
cmake ..\..\..\..\bullet\ -G "Visual Studio 15" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DUSE_MSVC_RUNTIME_LIBRARY_DLL=ON -DBUILD_MULTITHREADING=OFF
msbuild BULLET_PHYSICS.sln /p:Configuration=Release /t:LinearMath:Rebuild;BulletCollision:Rebuild;BulletDynamics:Rebuild;BulletFileLoader:Rebuild;BulletSoftBody:Rebuild;BulletWorldImporter:Rebuild;BulletXmlWorldImporter:Rebuild
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir ..\build\bullet\Windows10\x64
pushd ..\build\bullet\Windows10\x64
cmake ..\..\..\..\bullet\ -G "Visual Studio 15 Win64" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DUSE_MSVC_RUNTIME_LIBRARY_DLL=ON -DBUILD_MULTITHREADING=OFF
msbuild BULLET_PHYSICS.sln /p:Configuration=Release /t:LinearMath:Rebuild;BulletCollision:Rebuild;BulletDynamics:Rebuild;BulletFileLoader:Rebuild;BulletSoftBody:Rebuild;BulletWorldImporter:Rebuild;BulletXmlWorldImporter:Rebuild
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

mkdir ..\build\bullet\Windows10\ARM
pushd ..\build\bullet\Windows10\ARM
cmake ..\..\..\..\bullet\ -G "Visual Studio 15 ARM" -DCMAKE_SYSTEM_NAME=WindowsStore -DCMAKE_SYSTEM_VERSION=10.0.15063 -DUSE_MSVC_RUNTIME_LIBRARY_DLL=ON -DBUILD_MULTITHREADING=OFF
msbuild BULLET_PHYSICS.sln /p:Configuration=Release /t:LinearMath:Rebuild;BulletCollision:Rebuild;BulletDynamics:Rebuild;BulletFileLoader:Rebuild;BulletSoftBody:Rebuild;BulletWorldImporter:Rebuild;BulletXmlWorldImporter:Rebuild
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

GOTO :end
:error_popd
popd
echo Error during compilation
EXIT /B %ERRORLEVEL%
pause
:end
