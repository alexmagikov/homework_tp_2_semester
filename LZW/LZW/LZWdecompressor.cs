// <copyright file="LZWdecompressor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Xml.Linq;

namespace LZW;

/// <summary>
/// LZW decompressor.
/// </summary>
public class LZWdecompressor
{
    /// <summary>
    /// Decompress func.
    /// </summary>
    /// <param name="compressedSequence">Array of int value.</param>
    /// <returns>Input sequence.</returns>
    public static byte[] Decompress(int[] compressedSequence)
    {
        var dictionaryOfCodes = new Dictionary<int, byte[]>();
        for (int i = 0; i < 256; i++)
        {
            dictionaryOfCodes[i] = new byte[] { (byte)i };
        }

        int nextCode = 256;
        byte[] previousSequence = dictionaryOfCodes[compressedSequence[0]];
        List<byte> result = new List<byte>(previousSequence);

        for (int i = 1; i < compressedSequence.Length; i++)
        {
            int code = compressedSequence[i];
            byte[] currentSequence;

            if (dictionaryOfCodes.ContainsKey(code))
            {
                currentSequence = dictionaryOfCodes[code];
            }
            else
            {
                currentSequence = previousSequence.Concat(new byte[] { previousSequence[0] }).ToArray();
            }

            result.AddRange(currentSequence);

            byte[] newSequence = previousSequence.Concat(new byte[] { currentSequence[0] }).ToArray();
            dictionaryOfCodes[nextCode] = newSequence;
            nextCode++;

            previousSequence = currentSequence;
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read compressed data.
    /// </summary>
    /// <param name="filePath">Path of the file.</param>
    /// <returns>Array of bytes of input data.</returns>
    public static byte[] ReadFromFile(string filePath)
    {

    }
}
