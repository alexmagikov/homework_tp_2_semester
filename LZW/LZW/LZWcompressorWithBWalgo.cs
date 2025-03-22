// <copyright file="LZWcompressorWithBWalgo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// LZW with BW.
/// </summary>
public class LZWcompressorWithBWalgo
{
    /// <summary>
    /// Forward conversion of LZW.
    /// </summary>
    /// <param name="str">Input array of bytes.</param>
    /// <returns>Transformed array of int codes.</returns>
    public static int[] Compress(byte[] str)
    {
        string sequence = System.Text.Encoding.UTF8.GetString(str);
        sequence = BWalgo.ForwardConversion(sequence).Result;
        byte[] sequenceBytes = System.Text.Encoding.UTF8.GetBytes(sequence);

        return LZWcompressor.Compress(sequenceBytes);
    }
}
