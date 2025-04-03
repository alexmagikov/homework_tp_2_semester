// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Node of tree.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Calculate expression.
    /// </summary>
    /// <returns>Result of calculation.</returns>
    public abstract float Calculate();

    /// <summary>
    /// Return expression.
    /// </summary>
    /// <returns>Expression.</returns>
    public abstract string Print();
}