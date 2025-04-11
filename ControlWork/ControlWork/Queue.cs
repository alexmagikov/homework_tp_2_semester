// <copyright file="Queue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ControlWork;

/// <summary>
/// Queue realization by binaryHeap.
/// </summary>
public class Queue
{
    private (int, int)[] binHeap = new (int, int)[10];
    private int heapSize;

    /// <summary>
    /// Gets a value indicating whether return true if queue is empty, else - false.
    /// </summary>
    public bool Empty => this.heapSize == 0;

    /// <summary>
    /// Add element to queue.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="priority">Priority.</param>
    public void Enqueue(int value, int priority)
    {
        if (this.heapSize >= this.binHeap.Length)
        {
            Array.Resize(ref this.binHeap, this.binHeap.Length * 2);
        }

        this.heapSize++;

        this.binHeap[this.heapSize - 1] = (value, priority);
        this.SiftUp(this.heapSize - 1);
    }

    /// <summary>
    /// Remove element from queue with the highest priority.
    /// </summary>
    /// <returns>Value with max priority.</returns>
    public int Dequeue()
    {
        if (this.heapSize == 0)
        {
            throw new NullValueException("Queue is empty");
        }

        var value = this.binHeap[0].Item1;
        this.binHeap[0] = this.binHeap[this.heapSize - 1];
        this.SiftDown(0);
        this.heapSize--;

        return value;
    }

    private void SiftUp(int index)
    {
        while (index > 0)
        {
            var parent = (index - 1) / 2;
            if (this.binHeap[parent].Item2 < this.binHeap[index].Item2)
            {
                this.Swap(index, parent);
                index = parent;
            }
            else
            {
                break;
            }
        }
    }

    private void SiftDown(int index)
    {
        while ((2 * index) + 1 < this.heapSize)
        {
            var leftChildIndex = (index * 2) + 1;
            var rightChildIndex = (index * 2) + 2;
            var needIndex = leftChildIndex;
            if (rightChildIndex < this.heapSize && this.binHeap[rightChildIndex].Item2 > this.binHeap[leftChildIndex].Item2)
            {
                needIndex = rightChildIndex;
            }

            if (this.binHeap[needIndex].Item2 <= this.binHeap[index].Item2)
            {
                break;
            }

            this.Swap(needIndex, index);
            index = needIndex;
        }
    }

    private void Swap(int index1, int index2)
        => (this.binHeap[index1], this.binHeap[index2]) = (this.binHeap[index2], this.binHeap[index1]);
}