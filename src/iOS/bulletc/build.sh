#xcodebuild clean
xcodebuild VALID_ARCHS="armv7 armv7s arm64" ONLY_ACTIVE_ARCH=NO -sdk iphoneos -mios-version-min=6.0
xcodebuild VALID_ARCHS="x86_64 i386" ARCHS="x86_64 i386" ONLY_ACTIVE_ARCH=NO -sdk iphonesimulator -mios-version-min=6.0
lipo build/Release-iphoneos/libbulletc.a build/Release-iphonesimulator/libbulletc.a -create -output build/libbulletc.a
file build/libbulletc.a
