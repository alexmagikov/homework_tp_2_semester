// <copyright file="LZWcompressor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
    public static void WriteInFile(int[] sequence, string filePath)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fileStream))
        {
            List<byte> currentBytes = new ();
            foreach (uint number in sequence)
            {
                var prefixCode = 0;
                if (number < 512)
                {
                    prefixCode = 0;
                }
                else if (number < 1024)
                {
                    prefixCode = 1;
                }
                else if (number < 2048)
                {
                    prefixCode = 2;
                }
                else if (number < 4096)
                {
                    prefixCode = 3;
                }
                writer.Write(current);
            }
        }

        Console.WriteLine($"The converted string was successfully written to the file");

        //using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        //using (BinaryReader reader = new BinaryReader(fileStream))
        //{
        //    long numberOfValues = fileStream.Length / sizeof(uint);

        //    Console.WriteLine($"Чтение {numberOfValues} значений из файла:");

        //    for (int i = 0; i < numberOfValues; i++)
        //    {
        //        uint value = reader.ReadUInt32();
        //        Console.WriteLine($"Значение {i + 1}: {value}");
        //    }
        //}
    }
}