// <copyright file="Operator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Operator of ParsingTree.
/// </summary>
public abstract class Operator : Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Operator"/> class.
    /// </summary>
    /// <param name="leftOperand">Left operand.</param>
    /// <param name="rightOperand">Right operand.</param>
    protected Operator(Node leftOperand, Node rightOperand)
    {
        this.LeftOperand = leftOperand;
        this.RightOperand = rightOperand;
    }

    /// <summary>
    /// Gets left operand.
    /// </summary>
    protected Node LeftOperand { get; }

    /// <summary>
    /// Gets right operand.
    /// </summary>
    protected Node RightOperand { get; }

    /// <summary>
    /// Calculate node value.
    /// </summary>
    /// <returns>Float value.</returns>
    public override float Calculate()
    {
        var leftResult = this.LeftOperand.Calculate();
        var rightResult = this.RightOperand.Calculate();
        return this.OperandMethod(leftResult, rightResult);
    }

    /// <summary>
    /// Operand method: +, -, /, *.
    /// </summary>
    /// <param name="leftValue">Left value for calculation.</param>
    /// <param name="rightValue">Right value for calculation.</param>
    /// <returns>Result.</returns>
    protected abstract float OperandMethod(float leftValue, float rightValue);
}