#ifdef _MSC_VER
#define EXPORT __declspec(dllexport)
#else
#if __GNUC__ >= 4
	#define EXPORT __attribute__ ((visibility("default")))
#else
	#define EXPORT
#endif
#endif

extern "C"
{
	EXPORT void* GenerateCompoundShape(unsigned int vertexCount, unsigned int indicesCount, float* vertexes, unsigned int* indices, bool simpleHull,
		int depth, int posSampling, int angleSampling, int posRefine, int angleRefine, float alpha, float threshold, int cancelToken);
	EXPORT void DeleteHulls(void* hulls);
	EXPORT void CancelGenerate(int token);
	EXPORT unsigned int GetNumHulls(void* hulls);
	EXPORT unsigned int GetHullNumPoints(void* hulls, unsigned int index);
	EXPORT void CopyHullPoints(void* hulls, unsigned int index, float* outPoints);
	EXPORT unsigned int GetHullNumIndices(void* hulls, unsigned int index);
	EXPORT void CopyHullIndices(void* hulls, unsigned int index, unsigned int* outIndices);
}