// <copyright file="LZWfunctions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// Additional functions.
/// </summary>
public class LZWfunctions
{
    /// <summary>
    /// Return coefficent of compression.
    /// </summary>
    /// <param name="inputSequence">Input sequence.</param>
    /// <param name="numBytesOfResultFile">Num of bytes of result file.</param>
    /// <returns>Coefficent of compression.</returns>
    public static float GetCoefficient(byte[] inputSequence, int numBytesOfResultFile)
    {
        return (float)inputSequence.Length / numBytesOfResultFile;
    }
}
