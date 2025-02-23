// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TrieProject;

/// <summary>
/// class trie with methods: Add, Contains, Remove and HowManyStartsWithPrefix and property: size.
/// </summary>
public class Trie
{
    /// <summary>
    /// root of trie.
    /// </summary>
    private readonly Vertex root = new ();

    /// <summary>
    /// Gets or sets size of trie.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// add string to trie.
    /// </summary>
    /// <param name="element">string.</param>
    /// <returns>true if string is the first. </returns>
    public bool Add(string element)
    {
        if (string.IsNullOrEmpty(element))
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

            currentVertex = currentVertex.NextVertexes[element[index]];
            index++;
        }

        if (!currentVertex.IsTerminal)
        {
            this.Size++;
            currentVertex.IsTerminal = true;
            return true;
        }

        return false;
    }

    /// <summary>
    /// return is string contained in trie.
    /// </summary>
    /// <param name="element">string.</param>
    /// <returns>true if string is contained, else - false.</returns>
    public bool Contains(string element)
    {
        if (string.IsNullOrEmpty(element))
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
    public bool Remove(string element)
    {
        if (string.IsNullOrEmpty(element))
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
    /// return num of strings which started from prefix.
    /// </summary>
    /// <param name="prefix">prefix.</param>
    /// <returns>num of strings.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        var index = 0;
        var currentVertex = this.root;
        while (index < prefix.Length)
        {
            if (!currentVertex.NextVertexes.ContainsKey(prefix[index]))
            {
                return 0;
            }

            currentVertex = currentVertex.NextVertexes[prefix[index]];
            index++;
        }

        return currentVertex.NextVertexes.Count;
    }

    /// <summary>
    /// vertex of trie.
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// Gets or sets the dictionary of next vertices, indexed by character.
        /// </summary>
        public Dictionary<char, Vertex> NextVertexes { get; set; } = new ();

        /// <summary>
        /// Gets or sets a value indicating whether this vertex is a terminal (end of a word).
        /// </summary>
        public bool IsTerminal { get; set; } = false;
    }
}
