// <copyright file="NullValueException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ControlWork;

/// <summary>
/// Exception of dequeue from null queue.
/// </summary>
public class NullValueException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NullValueException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    public NullValueException(string message)
        : base(message)
    {
    }
}
