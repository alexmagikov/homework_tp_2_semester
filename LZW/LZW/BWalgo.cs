// <copyright file="BWalgo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// BW algo.
/// </summary>
public class BWalgo
{
    /// <summary>
    /// Forward conversion of BW algo.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Transformed string and errorCode.</returns>
    public static (string Result, int NumStr) ForwardConversion(string str)
    {
        var permutations = new (string, int)[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            permutations[i] = (str, i);
        }

        Array.Sort(permutations, new StringWithEndIndexesCompaper());
        string result = string.Empty;
        int resultEndIndex = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (permutations[i].Item2 == 0)
            {
                resultEndIndex = i + 1;
            }

            result = result + permutations[i].Item1[(permutations[i].Item2 + str.Length - 1) % str.Length];
        }

        return (result, resultEndIndex);
    }
}
