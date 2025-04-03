// <copyright file="DivisionOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Division operator.
/// </summary>
public class DivisionOperator : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DivisionOperator"/> class.
    /// </summary>
    /// <param name="leftOperand">Left operand.</param>
    /// <param name="rightOperand">Right operand.</param>
    public DivisionOperator(Node leftOperand, Node rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// Return operand.
    /// </summary>
    /// <returns>Operand.</returns>
    public override string Print()
        => $"(/ {this.LeftOperand.Print()} {this.RightOperand.Print()})";

    /// <summary>
    /// Return multiplication.
    /// </summary>
    /// <param name="leftValue">Left value.</param>
    /// <param name="rightValue">Rigth value.</param>
    /// <returns>Result.</returns>
    protected override float OperandMethod(float leftValue, float rightValue)
    {
        if (rightValue == 0)
        {
            throw new DivideByZeroException();
        }

        return leftValue / rightValue;
    }
}