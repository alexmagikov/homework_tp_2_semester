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
        var TrieOfBytes = Trie.InitializeTrieBytes();
        List<byte> inputSequence = new ();
        inputSequence.Add((byte)compressedSequence[0]);
        for (int i = 1; i < compressedSequence.Length; i++)
        {
            List<byte> tmpElement = new List<byte>(inputSequence);
            tmpElement.Add(()compressedSequence[i]);    
            if (TrieOfBytes.Contains())
            {

            }
        }

        return [(byte)1];
    }
}
