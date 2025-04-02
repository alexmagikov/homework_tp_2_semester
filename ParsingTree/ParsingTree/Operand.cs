// <copyright file="Operand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Operand of ParsingTree.
/// </summary>
public class Operand : Node
{
    private readonly int value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Operand"/> class.
    /// </summary>
    /// <param name="value">Value.</param>
    public Operand(int value)
    {
        this.value = value;
    }

    /// <summary>
    /// Calculate expression.
    /// </summary>
    /// <returns>Result of calculation.</returns>
    public override float Calculate()
        => this.value;

    /// <summary>
    /// Return expression.
    /// </summary>
    /// <returns>Expression.</returns>
    public override string Print()
        => this.value.ToString();
}