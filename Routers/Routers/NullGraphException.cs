// <copyright file="NullGraphException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Null graph exception.
/// </summary>
public class NullGraphException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NullGraphException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    public NullGraphException(string message)
        : base(message)
    {
    }
}