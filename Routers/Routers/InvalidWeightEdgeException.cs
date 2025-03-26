// <copyright file="InvalidWeightEdgeException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Not corrected weight of the edge.
/// </summary>
public class InvalidWeightEdgeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidWeightEdgeException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    public InvalidWeightEdgeException(string message)
        : base(message)
    {
    }
}