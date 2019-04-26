This repo houses bullet 2, the physics engine used within [Xenko](https://github.com/xenko3d/xenko), its C++ / C# wrapper and build scripts for the different supported platforms.
- bullet => Official bullet repo
- libbulletc => C++ wrapper
- BulletSharp => C# wrapper around C++ wrapper
- src => build scripts

Clang is documented here to try to ensure determinism across platforms, as are the different \*\_d scripts.

---

##### Building bullet and its C++ wrapper:
- Windows x64 / x86:
	- [Make](http://gnuwin32.sourceforge.net/packages/make.htm) -> Setup program.
	- [Clang](http://releases.llvm.org/download.html) -> Windows 64 under Pre-Built Binaries.
	- Verify that they all have set their path within your environment variables.
		- Control Panel\System and Security\System -> Advanced system settings -> Environment Variables... -> Select 'PATH' inside your System Variables -> Edit
		- Here's how the default install path look under x64:
			- C:\Program Files (x86)\GnuWin32\bin
			- C:\Program Files\LLVM\bin
	- > win.bat
- Windows x64 / x86 / Store / UWP / ARM msbuild:
	- Install Visual Studio 2015+ with C++, cmake and Windows Store/UWP requirements.
	- > msbuild_winstore.bat
	- If you run into any issue (which you most likely will) good luck, CMake wants to build everything, you'll have to fiddle around with it.
- Unix:
- Mac:
- Android under Windows:
	- [AndroidNDK](https://developer.android.com/ndk/downloads)
	- > cd to C:\android-ndk-r19c or wherever you installed it
	- > ndk-build -C path_to\BulletSharpPInvoke\src\Android\jni
	- (building is slow af, see those build files for more info)

---

Original README content:

# BulletSharp
BulletSharp is a .NET wrapper for the [Bullet](https://pybullet.org/) physics library.

This version uses Platform Invoke. There is also an equivalent version written in C++/CLI: https://github.com/AndresTraks/BulletSharp

libbulletc is a C interface to Bullet. It compiles into a .dll or .so file that exports Bullet functions.

BulletSharpPInvoke is a .NET library that proxies calls from .NET to libbulletc.

The benefit of P/Invoke over C++/CLI is that it runs on all platforms that support P/Invoke into shared user-mode libraries (Windows, Unix, Mac OS). See also [Supported platforms](https://github.com/AndresTraks/BulletSharp/wiki/Supported-platforms).