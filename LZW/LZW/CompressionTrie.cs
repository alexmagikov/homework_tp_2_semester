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
    /// Add sequence of bytes to Trie.
    /// </summary>
    /// <param name="element">Sequence of bytes.</param>
    /// <param name="code">Code.</param>
    /// <returns>True if sequence of bytes is the first. </returns>
    public bool Add(List<byte> element, int code)
    {
        if (this.Contains(element))
        {
            return false;
        }

        var index = 0;
        var currentVertex = this.root;
        foreach (var byteElement in element)
        {
            if (!currentVertex.NextVertexes.ContainsKey(byteElement))
            {
                currentVertex.NextVertexes[byteElement] = new ();
            }

            currentVertex = currentVertex.NextVertexes[byteElement];
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
    /// Return is sequence of bytes contained in Trie.
    /// </summary>
    /// <param name="element">Sequence of bytes.</param>
    /// <returns>True if sequence of bytes is contained, else - false.</returns>
    public bool Contains(List<byte> element)
    {
        var index = 0;
        var currentVertex = this.root;
        foreach (var byteElement in element)
        {
            if (!currentVertex.NextVertexes.ContainsKey(byteElement))
            {
                return false;
            }

            currentVertex = currentVertex.NextVertexes[byteElement];
            index++;
        }

        return currentVertex.IsTerminal;
    }

    /// <summary>
    /// Get Code of sequence of bytes.
    /// </summary>
    /// <param name="element">Sequence of bytes.</param>
    /// <returns>Pair of num of code and errorCode.</returns>
    public (int, bool) GetCode(List<byte> element)
    {
        var index = 0;
        var currentVertex = this.root;
        foreach (var byteElement in element)
        {
            if (!currentVertex.NextVertexes.ContainsKey(byteElement))
            {
                return (0, false);
            }

            currentVertex = currentVertex.NextVertexes[byteElement];
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
        public int Code { get; set; }
    }
}