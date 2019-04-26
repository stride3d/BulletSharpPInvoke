REM Windows
pushd VHACD_Lib\VHACD
msbuild VHACD.sln /p:Configuration=Release
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

pushd VHACD_Lib\VHACD
msbuild VHACD.sln /p:Configuration=Release;Platform=x64
if %ERRORLEVEL% neq 0 GOTO :error_popd
popd

GOTO :end
:error_popd
popd
echo Error during compilation
EXIT /B %ERRORLEVEL%
pause
:end
