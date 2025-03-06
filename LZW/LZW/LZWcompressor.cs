// <copyright file="LZWcompressor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection.Emit;

namespace LZW;

/// <summary>
/// LZW algo.
/// </summary>
public class LZWcompressor
{
    /// <summary>
    /// Forward conversion of LZW.
    /// </summary>
    /// <param name="sequence">Input array of bytes.</param>
    /// <returns>Transformed array of int codes.</returns>
    public static int[] Compress(byte[] sequence)
    {
        int code = 256;
        var trieOfBytes = CompressionTrie.InitializeTrieBytes();

        List<int> compressedSequence = new ();
        List<byte> currentElement = new ();

        foreach (byte element in sequence)
        {
            List<byte> tmpElement = new List<byte>(currentElement);
            tmpElement.Add(element);

            if (!trieOfBytes.Contains(tmpElement.ToArray()))
            {
                compressedSequence.Add(trieOfBytes.GetCode(currentElement.ToArray()).Item1);
                trieOfBytes.Add(tmpElement.ToArray(), code);
                currentElement.Clear();
                currentElement.Add(element);
                code++;
            }
            else
            {
                currentElement = tmpElement;
            }
        }

        if (currentElement.Count > 0)
        {
            compressedSequence.Add(trieOfBytes.GetCode(currentElement.ToArray()).Item1);
        }

        return compressedSequence.ToArray();
    }

    /// <summary>
    /// Transform sequence of int codes to variable length bit sequence.
    /// </summary>
    /// <param name="sequence">Array of int codes.</param>
    /// <returns>Array of bytes.</returns>
    public static byte[] TransformSequence(int[] sequence)
    {
        List<byte> result = new List<byte>();
        byte currentByte = 0;
        int bitPosition = 0;

        foreach (int code in sequence)
        {
            int bitCount = 8;
            while (code >= (1 << bitCount))
            {
                bitCount++;
            }

            for (int i = bitCount - 1; i >= 0; i--)
            {
                currentByte |= (byte)(((code >> i) & 1) << (7 - bitPosition));
                bitPosition++;

                if (bitPosition == 8)
                {
                    result.Add(currentByte);
                    bitPosition = 0;
                    currentByte = 0;
                }
            }
        }

        if (bitPosition > 0)
        {
            result.Add(currentByte);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Write transformed sequence in file.
    /// </summary>
    /// <param name="transformedSequence">Transformed sequence.</param>
    /// <param name="filePath">Path of the file.</param>
    public static void WriteInFile(byte[] transformedSequence, string filePath)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            fileStream.Write(transformedSequence, 0, transformedSequence.Length);
        }

        Console.WriteLine($"The converted string was successfully written to the file");
    }
}
