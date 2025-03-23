// <copyright file="PrimFindMst.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Routers;

/// <summary>
/// Search MST.
/// </summary>
public class PrimFindMst
{
    /// <summary>
    /// Find MST by Prim`s algorithm.
    /// </summary>
    /// <param name="graph">Input graph.</param>
    /// <returns>Result Mst.</returns>
    public static Dictionary<int, List<(int Router, int LengthOfEdge)>> FindMst(Dictionary<int, List<(int Router, int LengthEdge)>> graph)
    {
        Dictionary<int, List<(int, int)>> resultGraph = new();
        PriorityQueue<int, int> priorityQueue = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        var distancesToMst = GetTheInitialArrayOfDistancesFromGraph(graph);
        distancesToMst[graph.Keys.First()] = 0;

        var currentVertex = priorityQueue.Dequeue();
        for (int i = 0; i < distancesToMst.Length; i++)
        {
            foreach (var router in graph[currentVertex])
            {
                var isRouterInQueue = priorityQueue.UnorderedItems.Any(item => item.Element == router.Router);
                if (isRouterInQueue && graph[currentVertex])
                {
                    
                }
            }
        }
    }
    
    private static int[] GetTheInitialArrayOfDistancesFromGraph(Dictionary<int, List<(int Router, int LengthEdge)>> graph)
    {
        HashSet<int> vertices = [];
        foreach (var key in graph.Keys)
        {
            vertices.Add(key);
            foreach (var edge in graph[key])
            {
                vertices.Add(edge.Router);
            }
        }

        int vertexCount = vertices.Count;
        int[] distances = new int[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            distances[i] = -1;
        }

        return distances;
    }
}