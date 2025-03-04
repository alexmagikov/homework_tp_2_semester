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
    public static List<int> ReadVariableBitData(string filePath)
    {
        // Читаем все байты из файла
        byte[] fileBytes = File.ReadAllBytes(filePath);

        // Преобразуем байты в битовую строку
        string bitString = BytesToBitString(fileBytes);

        // Декодируем данные
        return DecodeBitString(bitString);
    }

    /// <summary>
    /// Преобразует массив байтов в строку битов
    /// </summary>
    private static string BytesToBitString(byte[] bytes)
    {
        char[] bits = new char[bytes.Length * 8];
        for (int i = 0; i < bytes.Length; i++)
        {
            byte b = bytes[i];
            for (int j = 0; j < 8; j++)
            {
                bits[i * 8 + j] = ((b >> (7 - j)) & 1) == 1 ? '1' : '0';
            }
        }
        return new string(bits);
    }

    /// <summary>
    /// Декодирует битовую строку в список значений
    /// </summary>
    private static List<int> DecodeBitString(string bitString)
    {
        List<int> values = new List<int>();
        int position = 0;

        // Правила определения длины бита
        Func<int, int> GetBitLength = (int value) => {
            if (value < 512) return 9;       // 2^9 = 512
            if (value < 1024) return 10;     // 2^10 = 1024
            if (value < 2048) return 11;     // 2^11 = 2048
            return 12;                       // 2^12 = 4096
        };

        // Начинаем с 9 бит (минимальная длина)
        int currentBitLength = 9;

        while (position + currentBitLength <= bitString.Length)
        {
            // Извлекаем биты для текущего значения
            string valueBits = bitString.Substring(position, currentBitLength);

            // Преобразуем биты в число
            int value = Convert.ToInt32(valueBits, 2);
            values.Add(value);

            // Перемещаем позицию
            position += currentBitLength;

            // Определяем длину следующего значения на основе текущего значения
            currentBitLength = GetBitLength(value);
        }

        return values;
    }
}