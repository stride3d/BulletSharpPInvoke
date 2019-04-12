#include <vhacdHACD.h>
#include <vhacdMeshDecimator.h>
#include <vector>
#include <iostream>
#include <fstream>
#include <atomic>
#include <map>
#include "wrapper.h"

//#define DEBUG_EXPORT 1

std::map<int, std::atomic_bool> gCancelTokens;

struct Hull
{
	unsigned int points;
	float* verts;
	unsigned int indices;
	unsigned int* tris;
};

struct CompoundHull
{
	unsigned int count;
	Hull* hulls;
};

void VHCDCallBack(const char * msg)
{
	printf("%s\n", msg);
}

void CancelGenerate(int token)
{
	if(gCancelTokens.find(token) != gCancelTokens.end())
	{
		gCancelTokens[token].exchange(true);
	}
}

void* GenerateCompoundShape(unsigned int vertexCount, unsigned int indicesCount, float* vertexes, unsigned int* indices, bool simpleHull,
							int depth, int posSampling, int angleSampling, int posRefine, int angleRefine, float alpha, float threshold, int cancelToken)
{
	gCancelTokens[cancelToken].exchange(false);

	long nTriangles = indicesCount / 3;
	long nPoints = vertexCount;
	VHACD::Vec3<VHACD::Real>* pPoints = new VHACD::Vec3<VHACD::Real>[nPoints];
    VHACD::Vec3<long>* pTriangles = new VHACD::Vec3<long>[nTriangles];

	for(int i=0; i < vertexCount; i++ ) 
	{
		int index = i * 3;
		VHACD::Vec3<VHACD::Real> vertex(vertexes[index], vertexes[index+1], vertexes[index+2]);
		pPoints[i] = vertex;
	}

	for(int i=0; i < indicesCount / 3;i++)
	{
		int index = i * 3;
		VHACD::Vec3<long> triangle(indices[index], indices[index+1], indices[index+2]);
		pTriangles[i] = triangle;
	}

	VHACD::Mesh mesh;
    mesh.ResizePoints(nPoints);
    mesh.ResizeTriangles(nTriangles);
    for(size_t p = 0; p < nPoints; ++p) mesh.SetPoint(p, pPoints[p]);
    for(size_t t = 0; t < nTriangles; ++t) mesh.SetTriangle(t, pTriangles[t]);
    delete [] pPoints;
	delete [] pTriangles;

	if(gCancelTokens[cancelToken]) return NULL;

	mesh.CleanDuplicatedVectices();

	if(gCancelTokens[cancelToken]) return NULL;

	if(nTriangles > 1000)
	{
		nTriangles = mesh.GetNTriangles();
		nPoints = mesh.GetNPoints();

		double decimationTris = ((double)nTriangles / 100.0) * 5.0;
		long ldecimationTris = (long)decimationTris;

		std::vector< VHACD::Vec3<VHACD::Real> > points;
		std::vector< VHACD::Vec3<long> > triangles;

		for(int i=0; i < nPoints; i++ ) 
		{
			points.push_back(mesh.GetPoint(i));
		}

		for(int i=0; i < nTriangles;i++)
		{
			triangles.push_back(mesh.GetTriangle(i));
		}

		VHACD::MeshDecimator decimator;
		decimator.SetCallBack(&VHCDCallBack);
		decimator.Initialize(points.size(), triangles.size(), &points[0], &triangles[0]);
		decimator.Decimate(0, ldecimationTris);

		nTriangles = decimator.GetNTriangles();
        nPoints = decimator.GetNVertices();
        pPoints = new VHACD::Vec3<VHACD::Real>[nPoints];
        pTriangles = new VHACD::Vec3<long>[nTriangles];
        decimator.GetMeshData(pPoints, pTriangles);

		mesh.ResizePoints(nPoints);
		mesh.ResizeTriangles(nTriangles);
		for(size_t p = 0; p < nPoints; ++p) mesh.SetPoint(p, pPoints[p]);
		for(size_t t = 0; t < nTriangles; ++t) mesh.SetTriangle(t, pTriangles[t]);
		delete [] pPoints;
		delete [] pTriangles;
	}

	if(gCancelTokens[cancelToken]) return NULL;
 
	if(simpleHull)
	{
		VHACD::Mesh meshCh;
		mesh.ComputeConvexHull(meshCh);

		if(gCancelTokens[cancelToken]) return NULL;

		CompoundHull* compound = new CompoundHull();
		compound->count = 1;
		compound->hulls = (Hull*)malloc(sizeof(Hull) * compound->count);

		compound->hulls[0].points = meshCh.GetNPoints();
		compound->hulls[0].indices = meshCh.GetNTriangles();

		compound->hulls[0].verts = (float*)malloc(sizeof(float) * 3 * compound->hulls[0].points);	
		const VHACD::Real* chp = meshCh.GetPoints();
		for(unsigned int v = 0; v < compound->hulls[0].points * 3; v++)
		{
			compound->hulls[0].verts[v] = chp[v];
		}

		compound->hulls[0].tris = (unsigned int*)malloc(sizeof(unsigned int) * 3 * compound->hulls[0].indices);	
		const long* cht = meshCh.GetTriangles();
		for(unsigned int v = 0; v < compound->hulls[0].indices * 3; v++)
		{
			compound->hulls[0].tris[v] = cht[v];
		}

#if DEBUG_EXPORT
		meshCh.SaveOFF("M:\\test.off");
#endif

		return compound;
	}

	//else

	std::vector<VHACD::Mesh*> parts;
    VHACD::ApproximateConvexDecomposition(mesh, depth, posSampling, angleSampling, posRefine, angleRefine, alpha, threshold, parts, &VHCDCallBack, gCancelTokens[cancelToken]);

	if(gCancelTokens[cancelToken]) return NULL;

	CompoundHull* compound = new CompoundHull();
	compound->count = parts.size();
	compound->hulls = (Hull*)malloc(sizeof(Hull) * compound->count);

#if DEBUG_EXPORT
	std::ofstream foutCH("M:\\test.wrl");
	VHACD::Material mat;
#endif

	for(unsigned int i = 0; i < compound->count; i++)
	{
		VHACD::Mesh ch;
		parts[i]->ComputeConvexHull(ch);

		compound->hulls[i].points = ch.GetNPoints();
		compound->hulls[i].indices = ch.GetNTriangles();

		compound->hulls[i].verts = (float*)malloc(sizeof(float) * 3 * compound->hulls[i].points);	
		const VHACD::Real* chp = ch.GetPoints();
		for(unsigned int v = 0; v < compound->hulls[i].points * 3; v++)
		{
			compound->hulls[i].verts[v] = chp[v];
		}

		compound->hulls[i].tris = (unsigned int*)malloc(sizeof(unsigned int) * 3 * compound->hulls[i].indices);	
		const long* cht = ch.GetTriangles();
		for(unsigned int v = 0; v < compound->hulls[i].indices * 3; v++)
		{
			compound->hulls[i].tris[v] = cht[v];
		}

#if DEBUG_EXPORT
		mat.m_diffuseColor.X() = mat.m_diffuseColor.Y() = mat.m_diffuseColor.Z() = 0.0;
        while (mat.m_diffuseColor.X() == mat.m_diffuseColor.Y() ||
                mat.m_diffuseColor.Z() == mat.m_diffuseColor.Y() ||
                mat.m_diffuseColor.Z() == mat.m_diffuseColor.X()  )
        {
            mat.m_diffuseColor.X() = (rand()%100) / 100.0;
            mat.m_diffuseColor.Y() = (rand()%100) / 100.0;
            mat.m_diffuseColor.Z() = (rand()%100) / 100.0;
        }

		ch.SaveVRML2(foutCH, mat);
#endif
	}

#if DEBUG_EXPORT
	foutCH.close();
#endif

	return compound;
}

unsigned int GetNumHulls(void* hulls)
{
	CompoundHull* compound = (CompoundHull*)hulls;
	return compound->count;
}

unsigned int GetHullNumPoints(void* hulls, unsigned int index)
{
	CompoundHull* compound = (CompoundHull*)hulls;
	return compound->hulls[index].points * 3;
}

void CopyHullPoints(void* hulls, unsigned int index, float* outPoints)
{
	CompoundHull* compound = (CompoundHull*)hulls;
	memcpy(outPoints, compound->hulls[index].verts, sizeof(float) * 3 * compound->hulls[index].points);
}

unsigned int GetHullNumIndices(void* hulls, unsigned int index)
{
	CompoundHull* compound = (CompoundHull*)hulls;
	return compound->hulls[index].indices * 3;
}

void CopyHullIndices(void* hulls, unsigned int index, unsigned int* outIndices)
{
	CompoundHull* compound = (CompoundHull*)hulls;
	memcpy(outIndices, compound->hulls[index].tris, sizeof(unsigned int) * 3 * compound->hulls[index].indices);
}

void DeleteHulls(void* hulls)
{
	CompoundHull* compound = (CompoundHull*)hulls;
	for(unsigned int i = 0; i < compound->count; i++)
	{
		free(compound->hulls[i].verts);
		free(compound->hulls[i].tris);
	}

	free(compound->hulls);

	delete compound;
}
