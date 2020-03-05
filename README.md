This repo houses bullet 2, the physics engine used within [Stride](https://github.com/stride3d/stride), its C++ / C# wrapper and build scripts for the different supported platforms.
- bullet => Official bullet repo
- libbulletc => C++ wrapper
- BulletSharp => C# wrapper around C++ wrapper
- src => build scripts

---

## MAKE SURE YOU PULLED SUBMODULES WITH THIS REPO

##### Building bullet and its C++ wrapper:
- Windows x64 / x86 / Store / UWP / ARM msbuild:
	- Install Visual Studio 2015+ with C++, cmake and Windows Store/UWP requirements.
	- > msbuild_winstore.bat
	- If you run into any issue (which you most likely will) good luck, CMakeLists wants to build everything, you'll have to fiddle around with it.
- Unix:
	- > sudo apt install make
	- > sudo apt install clang
	- > cd /src
	- > make
- Mac:
	- > xcode-select --install
	- > cd /src
	- > make
- iOS:
	- > xcode-select --install
	- Install xcode
	- Make sure that your terminal is in dev mode, look at xcode's preferences to change that
	- > cd /src/iOS/bulletc
	- > ./build.sh
- Android under Windows:
	- [AndroidNDK](https://developer.android.com/ndk/downloads)
	- > cd to C:\android-ndk-r19c or wherever you installed it
	- > ndk-build -C path_to\BulletSharpPInvoke\src\Android\jni
	- (building is slow af, see those build files for more info)

##### Building BulletSharpPInvoke:
- Install latest .Net Standard
- Set BulletSharp.NetStandard.sln 's configuration to Release or ReleaseiOS if building for iOS
- Build through dotnet or your C# IDE


---

Original README content:

# BulletSharp
BulletSharp is a .NET wrapper for the [Bullet](https://pybullet.org/) physics library.

This version uses Platform Invoke. There is also an equivalent version written in C++/CLI: https://github.com/AndresTraks/BulletSharp

libbulletc is a C interface to Bullet. It compiles into a .dll or .so file that exports Bullet functions.

BulletSharpPInvoke is a .NET library that proxies calls from .NET to libbulletc.

The benefit of P/Invoke over C++/CLI is that it runs on all platforms that support P/Invoke into shared user-mode libraries (Windows, Unix, Mac OS). See also [Supported platforms](https://github.com/AndresTraks/BulletSharp/wiki/Supported-platforms).