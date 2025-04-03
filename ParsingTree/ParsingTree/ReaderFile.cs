// <copyright file="ReaderFile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// Read file.
/// </summary>
public static class ReaderFile
{
    /// <summary>
    /// Read file and tokenize them.
    /// </summary>
    /// <param name="path">Path of the file.</param>
    /// <returns>List of tokens.</returns>
    /// <exception cref="InvalidDataException">Bad data.</exception>
    public static List<string> Tokenize(string path)
    {
        var lines = File.ReadAllLines(path);
        if (lines.Length != 1)
        {
            throw new FormatException("File must consist 1 string");
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