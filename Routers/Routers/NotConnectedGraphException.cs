// <copyright file="NotConnectedGraphException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Not connected graph exception.
/// </summary>
public class NotConnectedGraphException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotConnectedGraphException"/> class.
    /// Return message of exception.
    /// </summary>
    /// <param name="message">Message.</param>
    public NotConnectedGraphException(string message)
        : base(message)
    {
    }
}