// <copyright file="CalculateTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Calculate the parsing tree.
/// </summary>
public static class CalculateTree
{
    /// <summary>
    /// Calculate the parsing tree.
    /// </summary>
    /// <param name="tree">Parsing tree.</param>
    /// <returns>Result of calculating.</returns>
    public static float Calculate(ParsingTree tree)
        => tree.Root.Calculate();
}