#include "main.h"

extern "C"
{
	EXPORT btChunk* btChunk_new();
	EXPORT int btChunk_getChunkCode(btChunk* obj);
	EXPORT int btChunk_getDna_nr(btChunk* obj);
	EXPORT int btChunk_getLength(btChunk* obj);
	EXPORT int btChunk_getNumber(btChunk* obj);
	EXPORT void* btChunk_getOldPtr(btChunk* obj);
	EXPORT void btChunk_setChunkCode(btChunk* obj, int value);
	EXPORT void btChunk_setDna_nr(btChunk* obj, int value);
	EXPORT void btChunk_setLength(btChunk* obj, int value);
	EXPORT void btChunk_setNumber(btChunk* obj, int value);
	EXPORT void btChunk_setOldPtr(btChunk* obj, void* value);
	EXPORT void btChunk_delete(btChunk* obj);

	EXPORT btChunk* btSerializer_allocate(btSerializer* obj, size_t size, int numElements);
	EXPORT void btSerializer_finalizeChunk(btSerializer* obj, btChunk* chunk, char* structType, int chunkCode, void* oldPtr);
	EXPORT const char* btSerializer_findNameForPointer(btSerializer* obj, void* ptr);
	EXPORT void* btSerializer_findPointer(btSerializer* obj, void* oldPtr);
	EXPORT void btSerializer_finishSerialization(btSerializer* obj);
	EXPORT const unsigned char* btSerializer_getBufferPointer(btSerializer* obj);
	EXPORT int btSerializer_getCurrentBufferSize(btSerializer* obj);
	EXPORT int btSerializer_getSerializationFlags(btSerializer* obj);
	EXPORT void* btSerializer_getUniquePointer(btSerializer* obj, void* oldPtr);
	EXPORT void btSerializer_registerNameForPointer(btSerializer* obj, void* ptr, char* name);
	EXPORT void btSerializer_serializeName(btSerializer* obj, char* ptr);
	EXPORT void btSerializer_setSerializationFlags(btSerializer* obj, int flags);
	EXPORT void btSerializer_startSerialization(btSerializer* obj);
	EXPORT void btSerializer_delete(btSerializer* obj);

	EXPORT btPointerUid* btPointerUid_new();
	EXPORT void btPointerUid_delete(btPointerUid* obj);

	EXPORT btDefaultSerializer* btDefaultSerializer_new(int totalSize);
	EXPORT btDefaultSerializer* btDefaultSerializer_new2();
	EXPORT unsigned char* btDefaultSerializer_internalAlloc(btDefaultSerializer* obj, size_t size);
	EXPORT void btDefaultSerializer_writeHeader(btDefaultSerializer* obj, unsigned char* buffer);
}
