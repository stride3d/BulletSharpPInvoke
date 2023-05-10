TOP = $(call my-dir)..

include $(CLEAR_VARS)

INCLUDE = \
   -I$(TOP)/bullet/src \
   -I$(TOP)/bullet/Extras/Serialize/BulletFileLoader \
   -I$(TOP)/bullet/Extras/Serialize/BulletWorldImporter \
   -I$(TOP)/bullet/Extras/Serialize/BulletXmlWorldImporter \
   -I$(TOP)/bullet/Extras/HACD \
   -I$(TOP)/bullet/examples/ThirdPartyLibs/tinyxml2 \
   -I$(TOP)/libbulletc/src \

CFLAGS = $(INCLUDE) -O3 -Wall -Wno-unused-variable -std=c++14
LDFLAGS = --shared
LIBS =
EXTENSION =
86_TARGET =
64_TARGET =
ARM64_TARGET =

COMM = x64/libbulletc.$(EXTENSION) x86/libbulletc.$(EXTENSION)

ifeq ($(OS),Windows_NT)
	$(error Windows currently does build successfully but the generated dll has dependencies, see clang_windows git branch for partial work on that front)
	EXTENSION = dll
	86_TARGET = -target i686-pc-windows-gnu
	64_TARGET = -target x86_64-pc-windows-gnu

	ifeq ($(WIN_ARCH_CUSTOM),x64)
		COMM = x64/libbulletc.$(EXTENSION)
	endif
	ifeq ($(WIN_ARCH_CUSTOM),x86)
		COMM = x86/libbulletc.$(EXTENSION)
	endif
else
	LIBS = -ldl
	CFLAGS += -fPIC
	86_TARGET = -m32
	64_TARGET = -m64

	UNAME_S := $(shell uname -s)
	ifeq ($(UNAME_S),Linux)
		EXTENSION = so
	endif
	ifeq ($(UNAME_S),Darwin)
		COMM = arm64/libbulletc.$(EXTENSION) x64/libbulletc.$(EXTENSION) x86/libbulletc.$(EXTENSION)
		64_TARGET = -arch arm64
		EXTENSION = dylib
	endif
endif

ifeq ($(DETERMINISTIC_BUILD),true)
# The SSE2 instructions (...) are fully IEEE754-1985 compliant, and they permit better reproducibility
# (thanks to the static rounding precision) and portability with other platforms.
# -Muller et aliis, Handbook of Floating-Point Arithmetic - p.107
	CFLAGS += -msse2 -mfpmath=sse
endif

FILE_LIST := $(wildcard \
		$(TOP)/bullet/src/LinearMath/*.cpp \
		$(TOP)/bullet/src/Bullet3Common/*.cpp \
		$(TOP)/bullet/src/BulletCollision/BroadphaseCollision/*.cpp \
		$(TOP)/bullet/src/BulletCollision/CollisionDispatch/*.cpp \
		$(TOP)/bullet/src/BulletCollision/CollisionShapes/*.cpp \
		$(TOP)/bullet/src/BulletCollision/Gimpact/*.cpp \
		$(TOP)/bullet/src/BulletCollision/NarrowPhaseCollision/*.cpp \
		$(TOP)/bullet/src/BulletDynamics/ConstraintSolver/*.cpp \
		$(TOP)/bullet/src/BulletDynamics/Dynamics/*.cpp \
		$(TOP)/bullet/src/BulletDynamics/Featherstone/*.cpp \
		$(TOP)/bullet/src/BulletDynamics/MLCPSolvers/*.cpp \
		$(TOP)/bullet/src/BulletDynamics/Vehicle/*.cpp \
		$(TOP)/bullet/src/BulletDynamics/Character/*.cpp \
		$(TOP)/bullet/src/BulletSoftBody/*.cpp \
		$(TOP)/bullet/src/BulletInverseDynamics/*.cpp \
		$(TOP)/bullet/src/BulletInverseDynamics/details/*.cpp \
		$(TOP)/bullet/Extras/Serialize/BulletFileLoader/*.cpp \
		$(TOP)/bullet/Extras/Serialize/BulletWorldImporter/*.cpp \
		$(TOP)/bullet/Extras/Serialize/BulletXmlWorldImporter/*.cpp \
		$(TOP)/bullet/Extras/HACD/*.cpp \
		$(TOP)/bullet/examples/ThirdPartyLibs/tinyxml2/*.cpp \
		$(TOP)/libbulletc/*.cpp \
		$(TOP)/libbulletc/src/*.cpp \
		)
LOCAL_SRC_FILES := $(FILE_LIST:$(LOCAL_PATH)/%=%)

OBJECTS=$(LOCAL_SRC_FILES:.cpp=.o)

all: $(COMM)

arm64/libbulletc.$(EXTENSION): $(LOCAL_SRC_FILES)
	mkdir -p arm64
	clang++ $(64_TARGET) $(LDFLAGS) $(CFLAGS) $(LOCAL_SRC_FILES) $(INCLUDE) -o $@ $(LIBS)

x64/libbulletc.$(EXTENSION): $(LOCAL_SRC_FILES)
	mkdir -p x64
	clang++ $(64_TARGET) $(LDFLAGS) $(CFLAGS) $(LOCAL_SRC_FILES) $(INCLUDE) -o $@ $(LIBS)

x86/libbulletc.$(EXTENSION): $(LOCAL_SRC_FILES)
	mkdir -p x86
	clang++ $(86_TARGET) $(LDFLAGS) $(CFLAGS) $(LOCAL_SRC_FILES) $(INCLUDE) -o $@ $(LIBS)
