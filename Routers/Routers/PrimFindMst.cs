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
        if (graph.Graph.Count == 0)
        {
            throw new NullGraphException("Null graph");
        }

        var resultGraph = new RoutersGraph();

        var distancesToMst = GetTheInitialArrayOfDistancesFromGraph(graph);
        distancesToMst[graph.Graph.Keys.First()] = 0;

        PriorityQueue<int, int> priorityQueue = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        priorityQueue.Enqueue(graph.Graph.Keys.First(), distancesToMst[graph.Graph.Keys.First()]);

        var inMst = new HashSet<int>();

        Dictionary<int, int> parents = new();

        while (priorityQueue.Count > 0)
        {
            var currentRouter = priorityQueue.Dequeue();

            if (inMst.Contains(currentRouter))
            {
                continue;
            }

            inMst.Add(currentRouter);

            if (parents.ContainsKey(currentRouter))
            {
                resultGraph.AddEdgeOfRouters(parents[currentRouter], currentRouter, distancesToMst[currentRouter]);
            }

            foreach (var router in graph.Graph[currentRouter].Keys)
            {
                if (!inMst.Contains(router) && (graph.Graph[currentRouter][router] > distancesToMst[router]))
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
        foreach (var keyRouter in graph.Graph.Keys)
        {
            routers.Add(keyRouter);
            foreach (var router in graph.Graph[keyRouter].Keys)
            {
                routers.Add(router);
            }
        }

        return routers.Count;
    }
}