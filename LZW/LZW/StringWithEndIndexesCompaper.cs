// <copyright file="StringWithEndIndexesCompaper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// Comparer for BW.
/// </summary>
public class StringWithEndIndexesCompaper : IComparer<(string, int)>
{
    /// <summary>
    /// Compare func.
    /// </summary>
    /// <param name="str1">1 string to compare.</param>
    /// <param name="str2">2 string to compare.</param>
    /// <returns>1 if 2 string > then 1, -1 in opposite case, 0 if they are equal.</returns>
    public int Compare((string, int) str1, (string, int) str2)
    {
        var indexStr1 = str1.Item2;
        var indexStr2 = str2.Item2;
        while (indexStr1 < str1.Item2 + str1.Item1.Length)
        {
            if (str1.Item1[indexStr1 % str1.Item1.Length] == str2.Item1[indexStr2 % str2.Item1.Length])
            {
                indexStr1++;
                indexStr2++;
            }
            else
            {
                break;
            }
        }

        return str1.Item1[indexStr1 % str1.Item1.Length].CompareTo(str1.Item1[indexStr2 % str2.Item1.Length]);
    }
}
