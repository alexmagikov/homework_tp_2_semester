// <copyright file="SubtractionOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Subtraction operator.
/// </summary>
public class SubtractionOperator : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubtractionOperator"/> class.
    /// </summary>
    /// <param name="leftOperand">Left operand.</param>
    /// <param name="rightOperand">Right operand.</param>
    public SubtractionOperator(Node leftOperand, Node rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// Return operand.
    /// </summary>
    /// <returns>Operand.</returns>
    public override string Print()
        => $"(- {this.LeftOperand.Print()} {this.RightOperand.Print()})";

    /// <summary>
    /// Return multiplication.
    /// </summary>
    /// <param name="leftValue">Left value.</param>
    /// <param name="rightValue">Right value.</param>
    /// <returns>Result.</returns>
    protected override float OperandMethod(float leftValue, float rightValue)
        => leftValue - rightValue;
}