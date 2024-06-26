/* Copyright (c) 2011 Khaled Mamou (kmamou at gmail dot com)
 All rights reserved.
 
 
 Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 
 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 
 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
 
 3. The names of the contributors may not be used to endorse or promote products derived from this software without specific prior written permission.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#include <vhacdGraph.h>
namespace VHACD
{    
    
    GraphEdge::GraphEdge()
    {
        m_v1 = -1;
        m_v2 = -1;
		m_name = -1;
        m_volume = 0;
        m_concavity = 0;
        m_deleted = false;
        m_convexHull = 0;
	}
   
    GraphVertex::GraphVertex()
    {
		m_name = -1;
        m_concavity = 0;
        m_volume = 0;
        m_deleted = false;
    }
    
    bool GraphVertex::DeleteEdge(long name)
    {
        return m_edges.Erase(name);
    }

    Graph::Graph()
    {
        m_nV = 0;
        m_nE = 0;
        m_nCCs = 0;
    }
    
    Graph::~Graph()
    {
    }
    
	void Graph::Allocate(size_t nV, size_t nE)
	{ 
		m_nV = nV;
		m_edges.reserve(nE);
		m_vertices.resize(nV);
		for(size_t i = 0; i < nV; i++)
		{
			m_vertices[i].m_name = static_cast<long>(i);
		}
	}

    long Graph::AddVertex()
    {
		size_t name = m_vertices.size();
		m_vertices.resize(name+1);
        m_vertices[name].m_name = static_cast<long>(name);
        m_nV++;
        return static_cast<long>(name);
    }
    
    long Graph::AddEdge(long v1, long v2)
    {
		size_t name = m_edges.size();
		m_edges.push_back(GraphEdge());
        m_edges[name].m_name = static_cast<long>(name);
        m_edges[name].m_v1 = v1;
        m_edges[name].m_v2 = v2;
        m_vertices[v1].AddEdge(static_cast<long>(name));
        m_vertices[v2].AddEdge(static_cast<long>(name));
        m_nE++;
		return static_cast<long>(name);
    }

    bool Graph::DeleteEdge(long name)
    {
		if (name < static_cast<long>(m_edges.size()))
		{
            long v1 = m_edges[name].m_v1;
            long v2 = m_edges[name].m_v2;
			m_edges[name].m_deleted = true;
            m_vertices[v1].DeleteEdge(name);
            m_vertices[v2].DeleteEdge(name);
			m_nE--;
			return true;
		}
		return false;
    }
    bool Graph::DeleteVertex(long name)
    {
		if (name < static_cast<long>(m_vertices.size()))
		{
			m_vertices[name].m_deleted = true;
            m_vertices[name].m_edges.Clear();
			m_vertices[name].m_ancestors.Clear();
			m_nV--;
			return true;
		}
		return false;
    }    
    bool Graph::EdgeCollapse(long v1, long v2)
	{
		long edgeToDelete = GetEdgeID(v1, v2);
        if (edgeToDelete >= 0) 
		{
			// delete the edge (v1, v2)
			DeleteEdge(edgeToDelete);

			size_t nA = m_vertices[v2].m_ancestors.Size();
			m_vertices[v1].m_ancestors.PushBack(v2);
			for(size_t a = 0; a < nA; ++a)
			{
				m_vertices[v1].m_ancestors.PushBack(m_vertices[v2].m_ancestors[a]);
			}				

			// update adjacency information
			SArray<long, SARRAY_DEFAULT_MIN_SIZE> & v1Edges =  m_vertices[v1].m_edges;
			long b = -1;
            long idEdge;
			for(size_t ed = 0; ed < m_vertices[v2].m_edges.Size(); ++ed) 
			{
                idEdge = m_vertices[v2].m_edges[ed];
				if (m_edges[idEdge].m_v1 == v2)
				{
					b = m_edges[idEdge].m_v2;
				}
				else
				{
					b = m_edges[idEdge].m_v1;
				}
				if (GetEdgeID(v1, b) >= 0)
				{
					m_edges[idEdge].m_deleted = true;
					m_vertices[b].DeleteEdge(idEdge);
					m_nE--;
				}
				else
				{
					m_edges[idEdge].m_v1 = v1;
					m_edges[idEdge].m_v2 = b;
					v1Edges.Insert(idEdge);
				}
			}
			// delete the vertex v2
            DeleteVertex(v2);			
            return true;
        }
		return false;
    }
    
    long Graph::GetEdgeID(long v1, long v2) const
    {
		if (v1 < static_cast<long>(m_vertices.size()) && !m_vertices[v1].m_deleted)
		{
            long idEdge;
			for(size_t ed = 0; ed < m_vertices[v1].m_edges.Size(); ++ed) 
			{
                idEdge =  m_vertices[v1].m_edges[ed];
				if ( (m_edges[idEdge].m_v1 == v2) || 
					 (m_edges[idEdge].m_v2 == v2)   ) 
				{
					return m_edges[idEdge].m_name;
				}
			}
		}
        return -1;
    }
    
	void Graph::Print() const
	{
		std::cout << "-----------------------------" << std::endl;
        std::cout << "vertices (" << m_nV << ")" << std::endl;
        for (size_t v = 0; v < m_vertices.size(); ++v) 
		{
			const GraphVertex & currentVertex = m_vertices[v];
			if (!m_vertices[v].m_deleted)
			{

				std::cout  << currentVertex.m_name	  << "\t";
				long idEdge;
				for(size_t ed = 0; ed < currentVertex.m_edges.Size(); ++ed) 
				{
                    idEdge = currentVertex.m_edges[ed];
					std::cout  << "(" << m_edges[idEdge].m_v1 << "," << m_edges[idEdge].m_v2 << ") "; 	  
				}
				std::cout << std::endl;
			}			
		}

		std::cout << "vertices (" << m_nE << ")" << std::endl;
		for (size_t e = 0; e < m_edges.size(); ++e) 
		{
			const GraphEdge & currentEdge = m_edges[e];
			if (!m_edges[e].m_deleted)
			{
				std::cout  << currentEdge.m_name	  << "\t(" 
						   << m_edges[e].m_v1		  << "," 
						   << m_edges[e].m_v2		  << ") "<< std::endl;
			}			
		}
	}
	void Graph::Clear()
	{
		m_vertices.clear();
		m_edges.clear();
		m_nV = 0;
        m_nE = 0;
	}
    
}