REM We have to do this weird dance of setting temporary paths to the right mingw version as I couldn't get 64 to work with x86 builds
setlocal
set PATH=%PATH%;C:\Program Files\LLVM\bin;%~dp0WinReq\mingw64\bin
make WIN_ARCH_CUSTOM=x64
endlocal
setlocal
set PATH=%PATH%;C:\Program Files\LLVM\bin;%~dp0WinReq\mingw32\bin
make WIN_ARCH_CUSTOM=x86
endlocal