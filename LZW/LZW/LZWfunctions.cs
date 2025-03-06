// <copyright file="LZWfunctions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;

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

    /// <summary>
    /// Compare LZW compress with BW algo and without BW algo on 2 large length files. 
    /// </summary>
    public static void CompareLZWCompressorWithBWAndWithoutBW()
    {
        string? exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (exePath == null)
        {
            throw new Exception("Не удалось определить путь к исполняемому файлу");
        }

        string path = Path.Combine(exePath, @"..\..\..\test.txt");
        path = Path.GetFullPath(path);
        byte[] fileBytes = File.ReadAllBytes(path);

        int[] resultByLZWCompressor = LZWcompressor.Compress(fileBytes);
        int[] resultByLZWCompressorWithBW = LZWcompressor_WithBWalgo.Compress(fileBytes);

        byte[] transformSequenceWithLZW = LZWcompressor.TransformSequence(resultByLZWCompressor);
        byte[] transformSequenceWithLZWWithBW = LZWcompressor.TransformSequence(resultByLZWCompressorWithBW);

        float coefficentWithLZW = GetCoefficient(fileBytes, transformSequenceWithLZW.Length);
        float coefficentWithLZWWithBw = GetCoefficient(fileBytes, transformSequenceWithLZWWithBW.Length);

        Console.WriteLine($"Coefficent of transform without BW: {coefficentWithLZW}");
        Console.WriteLine($"Coefficent of transform with BW: {coefficentWithLZWWithBw}");
    }
}
