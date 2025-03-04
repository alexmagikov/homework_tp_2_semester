// <copyright file="CompressionTrie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// Trie for compression for LZW.
/// </summary>
public class CompressionTrie
{
    /// <summary>
    /// root of Trie.
    /// </summary>
    private readonly Vertex root = new ();

    /// <summary>
    /// Gets or sets size of Trie.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Initialize Trie bytes from 0 to 255 for LZW.
    /// </summary>
    /// <returns>Trie initialized bytes.</returns>
    public static CompressionTrie InitializeTrieBytes()
    {
        CompressionTrie result = new ();
        for (int i = 0; i < 256; i++)
        {
            result.Add([(byte)i], i);
        }

        return result;
    }

    /// <summary>
    /// Add string to Trie.
    /// </summary>
    /// <param name="element">String.</param>
    /// <param name="code">Code.</param>
    /// <returns>True if string is the first. </returns>
    public bool Add(byte[] element, int code)
    {
        if (this.Contains(element))
        {
            return false;
        }

        var index = 0;
        var currentVertex = this.root;
        while (index < element.Length)
        {
            if (!currentVertex.NextVertexes.ContainsKey(element[index]))
            {
                currentVertex.NextVertexes[element[index]] = new ();
            }

            currentVertex.NumChildens++;
            currentVertex = currentVertex.NextVertexes[element[index]];
            index++;
        }

        if (!currentVertex.IsTerminal)
        {
            this.Size++;
            currentVertex.IsTerminal = true;
            currentVertex.Code = code;
            return true;
        }

        return false;
    }

    /// <summary>
    /// return is string contained in Trie.
    /// </summary>
    /// <param name="element">string.</param>
    /// <returns>true if string is contained, else - false.</returns>
    public bool Contains(byte[] element)
    {
        var index = 0;
        var currentVertex = this.root;
        while (index < element.Length)
        {
            if (!currentVertex.NextVertexes.ContainsKey(element[index]))
            {
                return false;
            }

            currentVertex = currentVertex.NextVertexes[element[index]];
            index++;
        }

        return currentVertex.IsTerminal;
    }

    /// <summary>
    /// remove element from tree.
    /// </summary>
    /// <param name="element">element.</param>
    /// <returns>true if element is contained, else - false.</returns>
    public bool Remove(byte[] element)
    {
        if (!this.Contains(element))
        {
            return false;
        }

        var index = 0;
        var currentVertex = this.root;
        while (index < element.Length)
        {
            if (!currentVertex.NextVertexes.ContainsKey(element[index]))
            {
                return false;
            }

            currentVertex.NumChildens--;
            currentVertex = currentVertex.NextVertexes[element[index]];
            index++;
        }

        if (currentVertex.IsTerminal)
        {
            currentVertex.IsTerminal = false;
        }

        this.Size--;
        return true;
    }

    /// <summary>
    /// Get Code of sequence of bytes.
    /// </summary>
    /// <param name="element">Sequence of bytes.</param>
    /// <returns>Pair of num of code and errorCode.</returns>
    public (int, bool) GetCode(byte[] element)
    {
        var index = 0;
        var currentVertex = this.root;
        while (index < element.Length)
        {
            if (!currentVertex.NextVertexes.ContainsKey(element[index]))
            {
                return (0, false);
            }

            currentVertex = currentVertex.NextVertexes[element[index]];
            index++;
        }

        return (currentVertex.Code, true);
    }

    /// <summary>
    /// vertex of Trie.
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// Gets or sets the dictionary of next vertices, indexed by character.
        /// </summary>
        public Dictionary<byte, Vertex> NextVertexes { get; set; } = new ();

        /// <summary>
        /// Gets or sets a value indicating whether this vertex is a terminal (end of a word).
        /// </summary>
        public bool IsTerminal { get; set; } = false;

        /// <summary>
        /// Gets or sets infromation for method HowManyStartsWithPrefix(string prefix).
        /// </summary>
        public int NumChildens { get; set; } = 0;

        /// <summary>
        /// Gets or sets infromation for method HowManyStartsWithPrefix(string prefix).
        /// </summary>
        public int Code { get; set; }
    }
}