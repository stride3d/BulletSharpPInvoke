LOCAL_PATH:= $(call my-dir)/../../..

include $(CLEAR_VARS)

LOCAL_CFLAGS := $(LOCAL_C_INCLUDES:%=-I%) -DUSE_PTHREADS -mfpu=neon -mfloat-abi=softfp -pthread -DSCE_PFX_USE_SIMD_VECTORMATH -O3 -DANDROID_NDK

# apply these flags if needed 
# -ffast-math -funsafe-math-optimizations

# apply this to disable optimization
# TARGET_CFLAGS := $(TARGET_CFLAGS) -O0

# apply these 2 to turn on assembly output (*.c/*.cpp to *.s file)
#compile-cpp-source = $(eval $(call ev-compile-cpp-source,$1,$(1:%$(LOCAL_CPP_EXTENSION)=%.s)))
#TARGET_CFLAGS := $(TARGET_CFLAGS) -S

# Enable or disable NEON. Don't forget to apply, or not apply, -mfpu=neon and -mfloat-abi=softfp
# flags in addition, e.g., if this is true both of those need to be included in LOCAL_CFLAGS
# to avoid the possibility that ndk-build will "forget" to add them on some files
LOCAL_ARM_NEON := true

TARGET_CFLAGS := $(filter-out -ffpu=vfp,$(TARGET_CFLAGS))

LOCAL_MODULE := bulletc

# Allows windows to build with large command list
LOCAL_SHORT_COMMANDS := true

LOCAL_ARM_MODE := arm
LOCAL_LDLIBS := -L$(SYSROOT)/usr/lib -ldl -llog

LOCAL_C_INCLUDES := \
   $(LOCAL_PATH)/bullet/src \
   $(LOCAL_PATH)/bullet/Extras/Serialize/BulletFileLoader \
   $(LOCAL_PATH)/bullet/Extras/Serialize/BulletWorldImporter \
   $(LOCAL_PATH)/bullet/Extras/Serialize/BulletXmlWorldImporter \
   $(LOCAL_PATH)/bullet/Extras/HACD \
   $(LOCAL_PATH)/bullet/examples/ThirdPartyLibs/tinyxml2 \
   $(LOCAL_PATH)/libbulletc/src \

FILE_LIST := $(wildcard \
		$(LOCAL_PATH)/bullet/src/LinearMath/*.cpp \
		$(LOCAL_PATH)/bullet/src/Bullet3Common/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletCollision/BroadphaseCollision/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletCollision/CollisionDispatch/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletCollision/CollisionShapes/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletCollision/NarrowPhaseCollision/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletDynamics/ConstraintSolver/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletDynamics/Dynamics/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletDynamics/Featherstone/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletDynamics/MLCPSolvers/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletDynamics/Vehicle/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletDynamics/Character/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletSoftBody/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletInverseDynamics/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletInverseDynamics/details/*.cpp \
		$(LOCAL_PATH)/bullet/src/BulletCollision/Gimpact/*.cpp \
		$(LOCAL_PATH)/bullet/Extras/Serialize/BulletFileLoader/*.cpp \
		$(LOCAL_PATH)/bullet/Extras/Serialize/BulletWorldImporter/*.cpp \
		$(LOCAL_PATH)/bullet/Extras/Serialize/BulletXmlWorldImporter/*.cpp \
		$(LOCAL_PATH)/bullet/Extras/HACD/*.cpp \
		$(LOCAL_PATH)/bullet/examples/ThirdPartyLibs/tinyxml2/*.cpp \
		$(LOCAL_PATH)/libbulletc/src/*.cpp \
		)
LOCAL_SRC_FILES := $(FILE_LIST:$(LOCAL_PATH)/%=%)

include $(BUILD_SHARED_LIBRARY)