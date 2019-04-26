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
MKDIR = 


ifeq ($(OS),Windows_NT)
	#CFLAGS += -target x86_64-pc-windows-gnu -stdlib=libstdc++
	#LDFLAGS += -stdlib=libstdc++
	EXTENSION = dll
	#CCFLAGS += -D WIN32
	#ifeq ($(PROCESSOR_ARCHITEW6432),AMD64)
	#	CCFLAGS += -D AMD64
	#else
	#	ifeq ($(PROCESSOR_ARCHITECTURE),AMD64)
	#		CCFLAGS += -D AMD64
	#	endif
	#	ifeq ($(PROCESSOR_ARCHITECTURE),x86)
	#		CCFLAGS += -D IA32
	#	endif
	#endif
else
	CFLAGS += -fPIC
	UNAME_S := $(shell uname -s)
	ifeq ($(UNAME_S),Linux)
		EXTENSION = so
		#CCFLAGS += -D LINUX
	endif
	ifeq ($(UNAME_S),Darwin)
		EXTENSION = dylib
		#CCFLAGS += -D OSX
	endif

	UNAME_P := $(shell uname -p)
	ifeq ($(UNAME_P),x86_64)
		#CCFLAGS += -D AMD64
	endif
	ifneq ($(filter %86,$(UNAME_P)),)
		#CCFLAGS += -D IA32
	endif
	ifneq ($(filter arm%,$(UNAME_P)),)
		#CCFLAGS += -D ARM
	endif
endif

COMM = x64/libbulletc.$(EXTENSION) x86/libbulletc.$(EXTENSION)

#Windows has special requirements, build is split and run twice, see build_win.bat
ifeq ($(WIN_ARCH_CUSTOM),x64)
	COMM = x64/libbulletc.$(EXTENSION)
endif
ifeq ($(WIN_ARCH_CUSTOM),x86)
	COMM = x86/libbulletc.$(EXTENSION)
endif

FILE_LIST := $(wildcard \
		$(TOP)/bullet/src/LinearMath/*.cpp \
		$(TOP)/bullet/src/Bullet3Common/*.cpp \
		$(TOP)/bullet/src/BulletCollision/BroadphaseCollision/*.cpp \
		$(TOP)/bullet/src/BulletCollision/CollisionDispatch/*.cpp \
		$(TOP)/bullet/src/BulletCollision/CollisionShapes/*.cpp \
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
		$(TOP)/bullet/src/BulletCollision/Gimpact/*.cpp \
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

x64/libbulletc.$(EXTENSION): $(LOCAL_SRC_FILES)
	clang++ -target x86_64-pc-windows-gnu $(LDFLAGS) $(CFLAGS) $(LOCAL_SRC_FILES) $(INCLUDE) -o $@ $(LIBS)

x86/libbulletc.$(EXTENSION): $(LOCAL_SRC_FILES)
	clang++ -target i686-pc-windows-gnu $(LDFLAGS) $(CFLAGS) $(LOCAL_SRC_FILES) $(INCLUDE) -o $@ $(LIBS)

