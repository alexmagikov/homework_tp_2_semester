// <copyright file="ParsingTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Parsing tree.
/// </summary>
public class ParsingTree
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParsingTree"/> class.
    /// </summary>
    /// <param name="tokens">Tokens.</param>
    public ParsingTree(List<string> tokens)
    {
        var index = 0;
        this.Root = Parse(tokens, ref index);
        if (index != tokens.Count)
        {
            throw new FormatException("Unexpected tokens at the end");
        }
    }

    /// <summary>
    /// Gets root of tree.
    /// </summary>
    public Node Root { get; }

    /// <summary>
    /// Print tree.
    /// </summary>
    /// <returns>Parsing tree in string view.</returns>
    public string PrintTree()
        => this.Root.Print();

    private static Node Parse(List<string> tokens, ref int index)
    {
        if (tokens[index] == "(")
        {
            index++;
            var operatorToken = tokens[index++];
            var leftOperand = Parse(tokens, ref index);
            var rightOperand = Parse(tokens, ref index);

            if (index >= tokens.Count)
            {
                throw new FormatException($"Missing )");
            }

            if (tokens[index++] != ")")
            {
                throw new FormatException($"Missing )");
            }

            return operatorToken switch
            {
                "+" => new PlusOperator(leftOperand, rightOperand),
                "-" => new SubtractionOperator(leftOperand, rightOperand),
                "/" => new DivisionOperator(leftOperand, rightOperand),
                "*" => new MultiplicationOperator(leftOperand, rightOperand),
                _ => throw new FormatException($"Unexpected '{operatorToken}'"),
            };
        }

        if (int.TryParse(tokens[index], out var value))
        {
            index++;
            return new Operand(value);
        }

        throw new FormatException($"Wrong format");
    }
}