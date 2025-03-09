// <copyright file="LZWfunctions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

using System.Reflection;

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
    public static float GetCoefficient(byte[] inputSequence, byte[] numBytesOfResultFile)
    {
        return (float)inputSequence.Length / numBytesOfResultFile.Length;
    }

    /// <summary>
    /// Compare LZW compress with BW algo and without BW algo on large length text.
    /// </summary>
    public static void CompareLZWCompressorWithBWAndWithoutBWOnRandomText()
    {
        string? exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (exePath == null)
        {
            throw new Exception("Не удалось определить путь к исполняемому файлу");
        }

        string path = Path.Combine(exePath, @"..\..\..\testBW1.txt");
        path = Path.GetFullPath(path);
        byte[] fileBytes = File.ReadAllBytes(path);

        int[] resultByLZWCompressor = LZWcompressor.Compress(fileBytes);
        int[] resultByLZWCompressorWithBW = LZWcompressor_WithBWalgo.Compress(fileBytes);

        byte[] transformSequenceWithLZW = LZWcompressor.EncodeByteSequencee(resultByLZWCompressor);
        byte[] transformSequenceWithLZWWithBW = LZWcompressor.EncodeByteSequencee(resultByLZWCompressorWithBW);

        float coefficentWithLZW = GetCoefficient(fileBytes, transformSequenceWithLZW);
        float coefficentWithLZWWithBw = GetCoefficient(fileBytes, transformSequenceWithLZWWithBW);

        Console.WriteLine($"Coefficent of transform without BW on random text: {coefficentWithLZW}");
        Console.WriteLine($"Coefficent of transform with BW on random text: {coefficentWithLZWWithBw}");
    }

    /// <summary>
    /// Compare LZW compress with BW algo and without BW algo on large length sequence of symbols.
    /// </summary>
    /// <exception cref="Exception">Uncorrect path.</exception>
    public static void CompareLZWCompressorWithBWAndWithoutBWOnRandomSequenceOfSymbols()
    {
        string? exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (exePath == null)
        {
            throw new Exception("Не удалось определить путь к исполняемому файлу");
        }

        string path = Path.Combine(exePath, @"..\..\..\testBW2.txt");
        path = Path.GetFullPath(path);
        byte[] fileBytes = File.ReadAllBytes(path);

        int[] resultByLZWCompressor = LZWcompressor.Compress(fileBytes);
        int[] resultByLZWCompressorWithBW = LZWcompressor_WithBWalgo.Compress(fileBytes);

        byte[] transformSequenceWithLZW = LZWcompressor.EncodeByteSequencee(resultByLZWCompressor);
        byte[] transformSequenceWithLZWWithBW = LZWcompressor.EncodeByteSequencee(resultByLZWCompressorWithBW);

        float coefficentWithLZW = GetCoefficient(fileBytes, transformSequenceWithLZW);
        float coefficentWithLZWWithBw = GetCoefficient(fileBytes, transformSequenceWithLZWWithBW);

        Console.WriteLine($"Coefficent of transform without BW on random sequence of symbols: {coefficentWithLZW}");
        Console.WriteLine($"Coefficent of transform with BW on random sequence of symbols: {coefficentWithLZWWithBw}");
    }
}
