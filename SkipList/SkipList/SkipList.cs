// <copyright file="SkipList.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace SkipList;

using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Skip list implementation.
/// </summary>
/// <typeparam name="T">Type of SkipList item.</typeparam>
public class SkipList<T> : IList<T>
{
    private readonly IComparer<T> comparer;
    private Node root;
    private int count;
    private int version = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    /// <param name="comparer">Comparer of type T.</param>
    public SkipList(IComparer<T> comparer)
    {
        this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        this.root = new Node(default!, null, null);
        this.count = 0;
    }

    /// <summary>
    /// Gets length of SkipList.
    /// </summary>
    public int Count => this.count;

    /// <summary>
    /// Gets a value indicating whether is read only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Operations with item by index in SkipList.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <returns>Get - item in SkipList, Set - set item in SkipList.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If index not corrected.</exception>
    public T this[int index]
    {
        get
        {
            var node = this.GetNodeByIndex(index);
            if (node == null)
            {
                throw new InvalidOperationException("Node not found");
            }

            return node.Key;
        }

        set
        {
            throw new NotSupportedException("Operation is not supported");
        }
    }

    /// <summary>
    /// Add item to SkipList.
    /// </summary>
    /// <param name="item">Item.</param>
    public void Add(T item)
    {
        var newNode = this.InsertByNode(this.root, item);
        if (newNode != null)
        {
            var newRoot = new Node(default!, null, this.root);
            this.root = newRoot;
        }

        this.count++;
        this.version++;
    }

    /// <summary>
    /// Clear SkipList.
    /// </summary>
    public void Clear()
    {
        this.root = new Node(default!, null, null);
        this.count = 0;
        this.version = 1;
    }

    /// <summary>
    /// Check containing item in SkipList.
    /// </summary>
    /// <param name="item">item.</param>
    /// <returns>True if item is contained in SkipList, else - false.</returns>
    public bool Contains(T item)
        => this.FindNode(item) != null;

    /// <summary>
    /// Copy items from SkipList to array starting from arrayIndex.
    /// </summary>
    /// <param name="array">Array.</param>
    /// <param name="arrayIndex">Array index.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegative(arrayIndex);
        if (array.Length - arrayIndex < this.count)
        {
            throw new ArgumentException("Not enough space");
        }

        var current = this.GetFirstNode();
        for (int i = 0; i < this.count && current != null; i++)
        {
            array[arrayIndex + i] = current.Key;
            current = current.Next;
        }
    }

    /// <summary>
    /// Return index of item.
    /// </summary>
    /// <param name="item">item.</param>
    /// <returns>Index if item in SkipList, else -- -1.</returns>
    public int IndexOf(T item)
    {
        var current = this.GetFirstNode();
        int index = 0;
        while (current != null)
        {
            if (this.comparer.Compare(current.Key, item) == 0)
            {
                return index;
            }

            current = current.Next;
            index++;
        }

        return -1;
    }

    /// <inheritdoc/>
    public void Insert(int index, T item)
        => throw new NotSupportedException("Operation is not supported");

    /// <summary>
    /// Remove item from SkipList.
    /// </summary>
    /// <param name="item">item.</param>
    /// <returns>True if element in SkipList, else - false.</returns>
    public bool Remove(T item)
    {
        var res = this.DeleteByNode(this.root, item);
        if (res)
        {
            this.count--;
            this.version++;
        }

        return res;
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        var node = this.GetNodeByIndex(index);
        if (node == null)
        {
            throw new IndexOutOfRangeException("index");
        }

        this.count--;
        this.version++;
        this.DeleteByNode(node, node.Key);
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    /// <summary>
    /// Get enumerator by root.
    /// </summary>
    /// <returns>New enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
        => new Enumerator(this);

    private Node? GetNodeByIndex(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var current = this.GetFirstNode();
        for (int i = 0; i < index; i++)
        {
            current = current?.Next;
        }

        return current;
    }

    private Node? GetFirstNode()
    {
        var current = this.root;
        while (current.Down != null)
        {
            current = current.Down;
        }

        return current.Next;
    }

    private Node? FindNode(T key)
    {
        var current = this.root;
        while (current != null)
        {
            while (current.Next != null && this.comparer.Compare(current.Next.Key, key) < 0)
            {
                current = current.Next;
            }

            if (current.Next != null && this.comparer.Compare(current.Next.Key, key) == 0)
            {
                return current.Next;
            }

            current = current.Down;
        }

        return null;
    }

    private Node? InsertByNode(Node current, T item)
    {
        while (current.Next != null && this.comparer.Compare(current.Next.Key, item) < 0)
        {
            current = current.Next;
        }

        Node? downNode = null;

        if (current.Down != null)
        {
            downNode = this.InsertByNode(current.Down, item);
        }

        if (downNode != null || current.Down == null)
        {
            current.Next = new Node(item, current.Next, downNode);
            if (Random.Shared.Next(0, 2) == 0)
            {
                return current.Next;
            }
        }

        return null;
    }

    private bool DeleteByNode(Node current, T key)
    {
        bool deleted = false;
        while (current.Next != null && this.comparer.Compare(current.Next.Key, key) < 0)
        {
            current = current.Next;
        }

        if (current.Down != null)
        {
            deleted = this.DeleteByNode(current.Down, key) || deleted;
        }

        if (current.Next != null && this.comparer.Compare(current.Next.Key, key) == 0)
        {
            current.Next = current.Next.Next;
            deleted = true;
        }

        return deleted;
    }

    /// <summary>
    /// Enumerator for SkipList.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Enumerator"/> struct.
    /// </remarks>
    /// <param name="skipList">Input SkipList.</param>
    public struct Enumerator(SkipList<T> skipList) : IEnumerator<T>
    {
        private readonly Node root = skipList.root;
        private readonly int lastVersion = skipList.version;
        private Node? current = null;

        /// <summary>
        /// Gets current item.
        /// </summary>
        public T Current
        {
            get
            {
                if (this.current == null)
                {
                    throw new InvalidOperationException();
                }

                return this.current.Key;
            }
        }

        /// <inheritdoc/>
        object? IEnumerator.Current => this.Current;

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            if (this.lastVersion != skipList.version)
            {
                throw new InvalidOperationException("Collection modified");
            }

            if (this.current == null)
            {
                var firstNode = this.GetFirstNode();
                if (firstNode == null)
                {
                    return false;
                }

                this.current = firstNode;
                return true;
            }

            this.current = this.current.Next;
            return this.current != null;
        }

        /// <inheritdoc/>
        public void Reset()
            => this.current = null;

        private Node? GetFirstNode()
        {
            var current = this.root;
            while (current.Down != null)
            {
                current = current.Down;
            }

            return current.Next;
        }
    }

    private class Node(T key, Node? next, Node? down)
    {
        public T Key { get; set; } = key;

        public Node? Next { get; set; } = next;

        public Node? Down { get; } = down;
    }
}