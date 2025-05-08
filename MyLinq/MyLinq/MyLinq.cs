// <copyright file="MyLinq.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// MyLinq class.
/// </summary>
public static class MyLinq
{
    /// <summary>
    /// Infinity sequence of prime numbers.
    /// </summary>
    /// <returns>Return sequence.</returns>
    public static IEnumerable<int> GetPrimeNumbers()
    {
        int num = 1;

        while (true)
        {
            bool isPrime = true;

            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                yield return num;
            }

            num++;
        }
    }

    /// <summary>
    /// Take first n elements from IEnumerable.
    /// </summary>
    /// <typeparam name="T">Type of sequence.</typeparam>
    /// <param name="seq">Sequence.</param>
    /// <param name="n">Num of first need elements.</param>
    /// <returns>Result sequence.</returns>
    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
    {
        int index = 0;
        foreach (var item in seq)
        {
            if (index < n)
            {
                yield return item;
                index++;
            }
            else
            {
                yield break;
            }
        }
    }

    /// <summary>
    /// Initializes static members of the <see cref="MyLinq"/> class.
    /// </summary>
    /// /// <typeparam name="T">Type of sequence.</typeparam>
    /// <param name="seq">Input IEnumerable.</param>
    /// <param name="n">Num of elements shoud return.</param>
    /// <returns>Result IEnumerable.</returns>
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
    {
        int index = 0;
        foreach (var item in seq)
        {
            if (index < n)
            {
                index++;
                continue;
            }
            else
            {
                yield return item;
            }
        }
    }
}
