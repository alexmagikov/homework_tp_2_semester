// <copyright file="MultiplicationOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Multiplication operator.
/// </summary>
public class MultiplicationOperator : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MultiplicationOperator"/> class.
    /// </summary>
    /// <param name="leftOperand">Left operand.</param>
    /// <param name="rightOperand">Right operand.</param>
    public MultiplicationOperator(Node leftOperand, Node rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// Return operand.
    /// </summary>
    /// <returns>Operand.</returns>
    public override string Print()
        => $"(* {this.LeftOperand.Print()} {this.RightOperand.Print()})";

    /// <summary>
    /// Return multiplication.
    /// </summary>
    /// <param name="leftValue">Left value.</param>
    /// <param name="rightValue">Right value.</param>
    /// <returns>Result.</returns>
    protected override float OperandMethod(float leftValue, float rightValue)
        => leftValue * rightValue;
}