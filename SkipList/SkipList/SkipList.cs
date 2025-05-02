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
/// <typeparam name="T">Type of SkipList element.</typeparam>
public class SkipList<T> : IList<T>
{
    private readonly IComparer<T> comparer;
    private Node root;
    private int count;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    /// <param name="comparer">Comparer of type T.</param>
    public SkipList(IComparer<T> comparer)
    {
        this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        this.root = new Node(default, null, null);
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
    /// Operations with element by index in SkipList.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <returns>Get - element in SkipList, Set - set element in SkipList.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If index not corrected.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this.GetNodeByIndex(index).Key;
        }

        set
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var node = this.GetNodeByIndex(index);
            node.Key = value;
        }
    }

    /// <summary>
    /// Add element to SkipList.
    /// </summary>
    /// <param name="element">Element.</param>
    public void Add(T element)
    {
        var newNode = this.InsertByNode(this.root, element);
        if (newNode != null)
        {
            var newRoot = new Node(default, null, this.root);
            this.root = newRoot;
        }

        this.count++;
    }

    /// <summary>
    /// Clear SkipList.
    /// </summary>
    public void Clear()
    {
        this.root = new Node(default, null, null);
        this.count = 0;
    }

    /// <summary>
    /// Check contains element in SkipList.
    /// </summary>
    /// <param name="element">Element.</param>
    /// <returns>True if element is contained in SkipList, else - false.</returns>
    public bool Contains(T element)
        => this.FindNode(element) != null;

    /// <summary>
    /// Copy elements from SkipList to array startinf from arrayIndex.
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
        for (int i = 0; i < this.count; i++)
        {
            array[arrayIndex + i] = current.Key;
            current = current.Next;
        }
    }

    /// <summary>
    /// Return index of element.
    /// </summary>
    /// <param name="element">Element.</param>
    /// <returns>Index if element in SkipList, else - -1.</returns>
    public int IndexOf(T element)
    {
        var current = this.GetFirstNode();
        int index = 0;
        while (current != null)
        {
            if (this.comparer.Compare(current.Key, element) == 0)
            {
                return index;
            }

            current = current.Next;
            index++;
        }

        return -1;
    }

    /// <summary>
    /// Insert element to SkipList by index.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="element">Element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Return exception if index is not corrected</exception>
    public void Insert(int index, T element)
    {
        if (index < 0 || index > this.count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (index == this.count)
        {
            this.Add(element);
            return;
        }

        var newNode = this.InsertByNode(this.root, element);
        this.count++;
    }

    public bool Remove(T item)
    {
        // todo
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var node = this.GetNodeByIndex(index);
        this.DeleteByNode(this.root, node.Key);
        this.count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }


    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

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

    private Node? InsertByNode(Node res, T key)
    {
        while (res.Next != null && this.comparer.Compare(res.Next.Key, key) < 0)
        {
            res = res.Next;
        }

        Node? downNode = null;

        if (res.Down != null)
        {
            downNode = this.InsertByNode(res.Down, key);
        }

        if (downNode != null || res.Down == null)
        {
            res.Next = new Node(key, res.Next, downNode);
            if (Random.Shared.Next(0, 2) == 0)
            {
                return res.Next;
            }
        }

        return null;
    }

    private void DeleteByNode(Node res, T key)
    {
        while (res.Next != null && this.comparer.Compare(res.Next.Key, key) < 0)
        {
            res = res.Next;
        }

        if (res.Down != null)
        {
            this.DeleteByNode(res.Down, key);
        }

        if (res.Next != null && this.comparer.Compare(res.Next.Key, key) == 0)
        {
            res.Next = res.Next.Next;
        }
    }

    public struct Enumerator : IEnumerator<T>, IEnumerator
    {
        public object Current => throw new NotImplementedException();

        T IEnumerator<T>.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    private class Node(T? key, Node? next, Node? down)
    {
        public T? Key { get; set; } = key;

        public Node? Next { get; set; } = next;

        public Node? Down { get; } = down;
    }
}