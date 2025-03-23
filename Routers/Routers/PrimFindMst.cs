// <copyright file="PrimFindMst.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Search MST.
/// </summary>
public static class PrimFindMst
{
    /// <summary>
    /// Find MST by Prim`s algorithm.
    /// </summary>
    /// <param name="graph">Input graph.</param>
    /// <returns>Result Mst.</returns>
    public static RoutersGraph FindMst(RoutersGraph graph)
    {
        var resultGraph = new RoutersGraph();

        var distancesToMst = GetTheInitialArrayOfDistancesFromGraph(graph);
        distancesToMst[graph.Graph.Keys.First()] = 0;

        PriorityQueue<int, int> priorityQueue = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        foreach (var key in distancesToMst.Keys)
        {
            priorityQueue.Enqueue(key, distancesToMst[key]);
        }

        Dictionary<int, int> parents = new();

        while (priorityQueue.Count > 0)
        {
            var currentRouter = priorityQueue.Dequeue();
            if (parents.ContainsKey(currentRouter))
            {
                resultGraph.AddEdgeOfRouters(parents[currentRouter], currentRouter, distancesToMst[currentRouter]);
            }

            foreach (var router in graph.Graph[currentRouter].Keys)
            {
                var isRouterInQueue = priorityQueue.UnorderedItems.Any(item => item.Element == router);
                if (isRouterInQueue && (graph.Graph[currentRouter][router] > distancesToMst[router]))
                {
                    distancesToMst[router] = graph.Graph[currentRouter][router];
                    parents[router] = currentRouter;
                    priorityQueue.Enqueue(router, distancesToMst[router]);
                }
            }
        }

        if (GetCountOfRoutersByGraph(graph) != GetCountOfRoutersByGraph(resultGraph))
        {
            throw new NotConnectedGraphException("Not connected graph");
        }

        return resultGraph;
    }

    private static Dictionary<int, int> GetTheInitialArrayOfDistancesFromGraph(RoutersGraph graph)
    {
        Dictionary<int, int> distances = new();
        foreach (var router in graph.Graph.Keys)
        {
            distances[router] = -1;
        }

        return distances;
    }

    private static int GetCountOfRoutersByGraph(RoutersGraph graph)
    {
        HashSet<int> routers = [];
        foreach (var key in graph.Graph.Keys)
        {
            routers.Add(key);
            foreach (var edge in graph.Graph[key].Keys)
            {
                routers.Add(edge);
            }
        }

        return routers.Count;
    }
}