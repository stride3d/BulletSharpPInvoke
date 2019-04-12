#include "conversion.h"
#include "btSerializer_wrap.h"

btChunk* btChunk_new()
{
	return new btChunk();
}

int btChunk_getChunkCode(btChunk* obj)
{
	return obj->m_chunkCode;
}

int btChunk_getDna_nr(btChunk* obj)
{
	return obj->m_dna_nr;
}

int btChunk_getLength(btChunk* obj)
{
	return obj->m_length;
}

int btChunk_getNumber(btChunk* obj)
{
	return obj->m_number;
}

void* btChunk_getOldPtr(btChunk* obj)
{
	return obj->m_oldPtr;
}

void btChunk_setChunkCode(btChunk* obj, int value)
{
	obj->m_chunkCode = value;
}

void btChunk_setDna_nr(btChunk* obj, int value)
{
	obj->m_dna_nr = value;
}

void btChunk_setLength(btChunk* obj, int value)
{
	obj->m_length = value;
}

void btChunk_setNumber(btChunk* obj, int value)
{
	obj->m_number = value;
}

void btChunk_setOldPtr(btChunk* obj, void* value)
{
	obj->m_oldPtr = value;
}

void btChunk_delete(btChunk* obj)
{
	delete obj;
}

btChunk* btSerializer_allocate(btSerializer* obj, size_t size, int numElements)
{
	return obj->allocate(size, numElements);
}

void btSerializer_finalizeChunk(btSerializer* obj, btChunk* chunk, char* structType, int chunkCode, void* oldPtr)
{
	obj->finalizeChunk(chunk, structType, chunkCode, oldPtr);
}

const char* btSerializer_findNameForPointer(btSerializer* obj, void* ptr)
{
	return obj->findNameForPointer(ptr);
}

void* btSerializer_findPointer(btSerializer* obj, void* oldPtr)
{
	return obj->findPointer(oldPtr);
}

void btSerializer_finishSerialization(btSerializer* obj)
{
	obj->finishSerialization();
}

const unsigned char* btSerializer_getBufferPointer(btSerializer* obj)
{
	return obj->getBufferPointer();
}

int btSerializer_getCurrentBufferSize(btSerializer* obj)
{
	return obj->getCurrentBufferSize();
}

int btSerializer_getSerializationFlags(btSerializer* obj)
{
	return obj->getSerializationFlags();
}

void* btSerializer_getUniquePointer(btSerializer* obj, void* oldPtr)
{
	return obj->getUniquePointer(oldPtr);
}

void btSerializer_registerNameForPointer(btSerializer* obj, void* ptr, char* name)
{
	obj->registerNameForPointer(ptr, name);
}

void btSerializer_serializeName(btSerializer* obj, char* ptr)
{
	obj->serializeName(ptr);
}

void btSerializer_setSerializationFlags(btSerializer* obj, int flags)
{
	obj->setSerializationFlags(flags);
}

void btSerializer_startSerialization(btSerializer* obj)
{
	obj->startSerialization();
}

void btSerializer_delete(btSerializer* obj)
{
	delete obj;
}

btPointerUid* btPointerUid_new()
{
	return new btPointerUid();
}

void btPointerUid_delete(btPointerUid* obj)
{
	delete obj;
}

btDefaultSerializer* btDefaultSerializer_new(int totalSize)
{
	return new btDefaultSerializer(totalSize);
}

btDefaultSerializer* btDefaultSerializer_new2()
{
	return new btDefaultSerializer();
}

unsigned char* btDefaultSerializer_internalAlloc(btDefaultSerializer* obj, size_t size)
{
	return obj->internalAlloc(size);
}

void btDefaultSerializer_writeHeader(btDefaultSerializer* obj, unsigned char* buffer)
{
	obj->writeHeader(buffer);
}
