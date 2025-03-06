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
    /// Decode byte sequence.
    /// </summary>
    /// <param name="compressedSequence">Byte sequence.</param>
    /// <returns>Array of codes.</returns>
    public static int[] DecodeByteSequence(byte[] compressedSequence)
    {
        List<int> result = new List<int>();
        int bitCount = 8;
        int currentCode = 0;
        int bitsRead = 0;

        foreach (byte b in compressedSequence)
        {
            for (int i = 7; i >= 0; i--)
            {
                // Читаем биты из байта
                int bit = (b >> i) & 1;
                currentCode = (currentCode << 1) | bit;
                bitsRead++;

                // Если накопили достаточно бит для текущего кода
                if (bitsRead == bitCount)
                {
                    result.Add(currentCode);
                    currentCode = 0;
                    bitsRead = 0;
                    if (result.Count >= (1 << bitCount) - 255)
                    {
                        bitCount++;
                    }
                }
            }
        }

        // Если остались необработанные биты
        if (bitsRead > 0)
        {
            result.Add(currentCode);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read byte sequence from file.
    /// </summary>
    /// <param name="filePath">Path of the file.</param>
    /// <returns>Byte sequence from file.</returns>
    public static byte[] ReadFromFile(string filePath)
    {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        return fileBytes;
    }
}