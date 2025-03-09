// <copyright file="LZWdecompressor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
        int byteIndex = 0;
        int bitPosition = 0;

        while (byteIndex < compressedSequence.Length || (byteIndex == compressedSequence.Length && bitPosition > 0))
        {
            int extraBits = 0;
            bool prefixComplete = false;

            while (!prefixComplete && byteIndex < compressedSequence.Length)
            {
                int bit = (compressedSequence[byteIndex] >> (7 - bitPosition)) & 1;

                bitPosition++;
                if (bitPosition == 8)
                {
                    bitPosition = 0;
                    byteIndex++;
                }

                if (bit == 0)
                {
                    prefixComplete = true;
                }
                else
                {
                    extraBits++;
                }
            }

            int value = 0;
            int bitsToRead = 8 + extraBits;
            int bitsRead = 0;

            while (bitsRead < bitsToRead && byteIndex < compressedSequence.Length)
            {
                int bit = (compressedSequence[byteIndex] >> (7 - bitPosition)) & 1;
                value = (value << 1) | bit;

                bitPosition++;
                bitsRead++;

                if (bitPosition == 8)
                {
                    bitPosition = 0;
                    byteIndex++;
                }
            }

            if (bitsRead == bitsToRead)
            {
                result.Add(value);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Create new file file by input file and write to this encoded data.
    /// </summary>
    /// <param name="transformedSequence">Transformed sequence.</param>
    /// <param name="filePath">Path of the file.</param>
    public static void WriteInFile(byte[] transformedSequence, string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Исходный файл не найден.", filePath);
        }

        using (FileStream fileStream = new FileStream(Path.ChangeExtension(filePath, ".zipped"), FileMode.Create))
        {
            fileStream.Write(transformedSequence, 0, transformedSequence.Length);
        }

        Console.WriteLine($"The converted string was successfully written to the file");
    }
}