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
    /// <param name="path">Path of file.</param>
    public ParsingTree(string path)
    {
        var line = ReadFile(path);
        var index = 0;
        this.Root = Parse(line, ref index);
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
        else if (int.TryParse(tokens[index], out var value))
        {
            index++;
            return new Operand(value);
        }
        else
        {
            throw new FormatException($"Unexpected '{tokens[index]}'");
        }
    }

    /// <summary>
    /// Read String from file to operators and operands.
    /// </summary>
    /// <param name="path">Path.</param>
    /// <returns>List of operators and operands.</returns>
    private static List<string> ReadFile(string path)
    {
        var lines = File.ReadAllLines(path);
        if (lines.Length != 1)
        {
            throw new InvalidDataException("File must consist 1 string");
        }

        var line = lines[0];
        var result = new List<string>();

        var index = 0;
        while (index < line.Length)
        {
            if (line[index] == '(' || line[index] == ')')
            {
                result.Add(line[index].ToString());
                index++;
                continue;
            }

            if (line[index] == ' ')
            {
                index++;
                continue;
            }

            if (char.IsDigit(line[index]) || (line[index] == '-' && index + 1 < line.Length && char.IsDigit(line[index + 1])))
            {
                var start = index;
                if (line[index] == '-')
                {
                    index++;
                }

                while (index < line.Length && char.IsDigit(line[index]))
                {
                    index++;
                }

                result.Add(line.Substring(start, index - start));
                continue;
            }

            result.Add(line[index].ToString());
            index++;
        }

        return result;
    }
}