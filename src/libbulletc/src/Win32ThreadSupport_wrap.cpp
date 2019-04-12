#include <BulletMultiThreaded/Win32ThreadSupport.h>

#ifdef USE_WIN32_THREADING

#include <BulletMultiThreaded/btParallelConstraintSolver.h>
#include <BulletMultiThreaded/SpuNarrowPhaseCollisionTask/SpuGatheringCollisionTask.h>

#include "conversion.h"
#include "Win32ThreadSupport_wrap.h"

Win32ThreadFunc Win32ThreadFunc_getProcessCollisionTask()
{
	return processCollisionTask;
}

Win32ThreadFunc Win32ThreadFunc_getSolverThreadFunc()
{
	return SolverThreadFunc;
}

Win32lsMemorySetupFunc Win32lsMemorySetupFunc_getCreateCollisionLocalStoreMemory()
{
	return createCollisionLocalStoreMemory;
}

Win32lsMemorySetupFunc Win32lsMemorySetupFunc_getSolverlsMemoryFunc()
{
	return SolverlsMemoryFunc;
}

Win32ThreadSupport_Win32ThreadConstructionInfo* Win32ThreadSupport_Win32ThreadConstructionInfo_new(char* uniqueName, Win32ThreadFunc userThreadFunc, Win32lsMemorySetupFunc lsMemoryFunc, int numThreads, int threadStackSize)
{
	return new Win32ThreadSupport_Win32ThreadConstructionInfo(uniqueName, userThreadFunc, lsMemoryFunc, numThreads, threadStackSize);
}

Win32ThreadSupport_Win32ThreadConstructionInfo* Win32ThreadSupport_Win32ThreadConstructionInfo_new2(char* uniqueName, Win32ThreadFunc userThreadFunc, Win32lsMemorySetupFunc lsMemoryFunc, int numThreads)
{
	return new Win32ThreadSupport_Win32ThreadConstructionInfo(uniqueName, userThreadFunc, lsMemoryFunc, numThreads);
}

Win32ThreadSupport_Win32ThreadConstructionInfo* Win32ThreadSupport_Win32ThreadConstructionInfo_new3(char* uniqueName, Win32ThreadFunc userThreadFunc, Win32lsMemorySetupFunc lsMemoryFunc)
{
	return new Win32ThreadSupport_Win32ThreadConstructionInfo(uniqueName, userThreadFunc, lsMemoryFunc);
}

Win32lsMemorySetupFunc Win32ThreadSupport_Win32ThreadConstructionInfo_getLsMemoryFunc(Win32ThreadSupport_Win32ThreadConstructionInfo* obj)
{
	return obj->m_lsMemoryFunc;
}

int Win32ThreadSupport_Win32ThreadConstructionInfo_getNumThreads(Win32ThreadSupport_Win32ThreadConstructionInfo* obj)
{
	return obj->m_numThreads;
}

int Win32ThreadSupport_Win32ThreadConstructionInfo_getThreadStackSize(Win32ThreadSupport_Win32ThreadConstructionInfo* obj)
{
	return obj->m_threadStackSize;
}

const char* Win32ThreadSupport_Win32ThreadConstructionInfo_getUniqueName(Win32ThreadSupport_Win32ThreadConstructionInfo* obj)
{
	return obj->m_uniqueName;
}

Win32ThreadFunc Win32ThreadSupport_Win32ThreadConstructionInfo_getUserThreadFunc(Win32ThreadSupport_Win32ThreadConstructionInfo* obj)
{
	return obj->m_userThreadFunc;
}

void Win32ThreadSupport_Win32ThreadConstructionInfo_setLsMemoryFunc(Win32ThreadSupport_Win32ThreadConstructionInfo* obj, Win32lsMemorySetupFunc value)
{
	obj->m_lsMemoryFunc = value;
}

void Win32ThreadSupport_Win32ThreadConstructionInfo_setNumThreads(Win32ThreadSupport_Win32ThreadConstructionInfo* obj, int value)
{
	obj->m_numThreads = value;
}

void Win32ThreadSupport_Win32ThreadConstructionInfo_setThreadStackSize(Win32ThreadSupport_Win32ThreadConstructionInfo* obj, int value)
{
	obj->m_threadStackSize = value;
}

void Win32ThreadSupport_Win32ThreadConstructionInfo_setUniqueName(Win32ThreadSupport_Win32ThreadConstructionInfo* obj, char* value)
{
	obj->m_uniqueName = value;
}

void Win32ThreadSupport_Win32ThreadConstructionInfo_setUserThreadFunc(Win32ThreadSupport_Win32ThreadConstructionInfo* obj, Win32ThreadFunc value)
{
	obj->m_userThreadFunc = value;
}

void Win32ThreadSupport_Win32ThreadConstructionInfo_delete(Win32ThreadSupport_Win32ThreadConstructionInfo* obj)
{
	delete obj;
}

Win32ThreadSupport* Win32ThreadSupport_new(Win32ThreadSupport_Win32ThreadConstructionInfo* threadConstructionInfo)
{
	return new Win32ThreadSupport(*threadConstructionInfo);
}

bool Win32ThreadSupport_isTaskCompleted(Win32ThreadSupport* obj, unsigned int* puiArgument0, unsigned int* puiArgument1, int timeOutInMilliseconds)
{
	return obj->isTaskCompleted(puiArgument0, puiArgument1, timeOutInMilliseconds);
}

void Win32ThreadSupport_startThreads(Win32ThreadSupport* obj, Win32ThreadSupport_Win32ThreadConstructionInfo* threadInfo)
{
	obj->startThreads(*threadInfo);
}

#endif
