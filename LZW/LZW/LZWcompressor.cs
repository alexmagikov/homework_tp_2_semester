// <copyright file="LZWcompressor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

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
    /// Write in file.
    /// </summary>
    /// <param name="sequence">Array of int codes.</param>
    /// <param name="filePath">Path to put zipped file.</param>
    /// <returns>Num of bytes in result file.</returns>
    /// <exception cref="ArgumentException">If num in sequence > 4096.</exception>
    public static int WriteInFile(int[] sequence, string filePath)
    {
        int numBytes = 0;
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fileStream))
        {
            byte currentByte = 0;
            int bitPosition = 0;
            foreach (int number in sequence)
            {
                int bitCount = number switch
                {
                    // < 64 => 6,
                    // < 128 => 7,
                    // < 256 => 8,
                    < 512 => 9,
                    < 1024 => 10,
                    < 2048 => 11,
                    < 4096 => 12,
                    _ => throw new ArgumentException($"Число {number} превышает максимально допустимое значение 4095"),
                };

                for (int i = bitCount - 1; i >= 0; i--)
                {
                    currentByte |= (byte)(((number >> i) & 1) << (7 - bitPosition));
                    bitPosition++;
                    if (bitPosition == 8)
                    {
                        writer.Write(currentByte);
                        bitPosition = 0;
                        currentByte = 0;
                        numBytes++;
                    }
                }
            }

            if (bitPosition > 0)
            {
                writer.Write(currentByte);
                numBytes++;
            }
        }

        Console.WriteLine($"The converted string was successfully written to the file");
        return numBytes;
    }
}