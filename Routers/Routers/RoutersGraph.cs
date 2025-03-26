// <copyright file="RoutersGraph.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Graph of routers.
/// </summary>
public class RoutersGraph
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoutersGraph"/> class.
    /// </summary>
    public RoutersGraph()
    {
        this.Graph = new Dictionary<int, Dictionary<int, int>>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RoutersGraph"/> class.
    /// </summary>
    /// <param name="path">Path of the file.</param>
    public RoutersGraph(string path)
    {
        this.Graph = ReadFile(path);
    }

    /// <summary>
    /// Gets or sets graph of the routers.
    /// </summary>
    public Dictionary<int, Dictionary<int, int>> Graph { get; set; }

    /// <summary>
    /// Add Edge of the routers.
    /// </summary>
    /// <param name="routerFrom">Router from.</param>
    /// <param name="routerTo">Router to.</param>
    /// <param name="lengthOfEdge">Length of edge.</param>
    public void AddEdgeOfRouters(int routerFrom, int routerTo, int lengthOfEdge)
    {
        if (!this.Graph.ContainsKey(routerFrom))
        {
            this.Graph[routerFrom] = new Dictionary<int, int>();
        }

        this.Graph[routerFrom][routerTo] = lengthOfEdge;
    }

    /// <summary>
    /// Write graph of routers to file.
    /// </summary>
    /// <param name="path">Path to the file.</param>
    public void WriteToFile(string path)
    {
        using StreamWriter writer = new(path);
        var currentIndexEnd = 0;
        foreach (var keyRouter in this.Graph.Keys)
        {
            var currentIndex = 0;
            writer.Write($"{keyRouter}: ");
            foreach (var router in this.Graph[keyRouter])
            {
                writer.Write($"{router.Key} ({router.Value})");
                if (currentIndex < this.Graph[keyRouter].Count - 1)
                {
                    writer.Write(", ");
                }

                currentIndex++;
            }

            if (currentIndexEnd < this.Graph.Keys.Count - 1)
            {
                writer.Write("\n");
            }

            currentIndexEnd++;
        }
    }

    /// <summary>
    /// Compare 2 graphs.
    /// </summary>
    /// <param name="otherGraph">Other Graph.</param>
    /// <returns>True if they are equal, else - false.</returns>
    public bool CompareGraph(RoutersGraph otherGraph)
    {
        if (this.Graph.Count != otherGraph.Graph.Count)
        {
            return false;
        }

        foreach (var (router, adjacentRouters) in this.Graph)
        {
            if (!otherGraph.Graph.ContainsKey(router) || adjacentRouters.Count != otherGraph.Graph[router].Count)
            {
                return false;
            }

            foreach (var (adjacentRouter, lengthOfEdge) in adjacentRouters)
            {
                if (!otherGraph.Graph[router].ContainsKey(adjacentRouter))
                {
                    return false;
                }

                if (otherGraph.Graph[router][adjacentRouter] != lengthOfEdge)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static Dictionary<int, Dictionary<int, int>> ReadFile(string path)
    {
        Dictionary<int, Dictionary<int, int>> resultGraph = new();

        using var reader = new StreamReader(path);
        foreach (var buffer in reader.ReadToEnd().Split('\n'))
        {
            var parts = buffer.Split(':');
            if (parts.Length != 2)
            {
                throw new FormatException("Invalid file format");
            }

            var keyRouter = int.Parse(parts[0].Trim());
            var adjacentRouters = parts[1].Trim();
            var pairs = adjacentRouters.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var pairData = pair.Trim().Split(['(', ')'], StringSplitOptions.RemoveEmptyEntries);
                if (pairData.Length != 2)
                {
                    throw new FormatException("Invalid file format");
                }

                var router = int.Parse(pairData[0].Trim());
                var lengthOfEdge = int.Parse(pairData[1].Trim());
                if (lengthOfEdge < 0)
                {
                    throw new InvalidWeightEdgeException("Not corrected weight of edge");
                }

                if (!resultGraph.ContainsKey(keyRouter))
                {
                    resultGraph[keyRouter] = new Dictionary<int, int>();
                }

                if (!resultGraph.ContainsKey(router))
                {
                    resultGraph[router] = new Dictionary<int, int>();
                }

                resultGraph[keyRouter][router] = lengthOfEdge;
                resultGraph[router][keyRouter] = lengthOfEdge;
            }
        }

        return resultGraph;
    }
}