// <copyright file="MyLinqTests.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace MyLinqTests;

using MyLinq;

public class MyLinqTests
{
    [Test]
    public void TestForNormalValue_SkipShouldReturnNormalValue()
    {
        var result = new[] { 1, 2, 3, 4 };
        Assert.That(MyLinq.Skip(result, 1), Is.EqualTo(new int[] {2, 3, 4}));
    }

    [Test]
    public void TestForNormalValue_TakeShouldReturnNormalValue()
    {
        var result = new[] { 1, 2, 3, 4 };
        Assert.That(MyLinq.Take(result, 1), Is.EqualTo(new int[] { 1 }));
    }

    [Test]
    public void TestForNormalValue_CompositionOfTakeAndSkipShouldReturnNormalValue()
    {
        var result = new[] { 1, 2, 3, 4 };
        Assert.That(MyLinq.Skip(MyLinq.Take(result, 3), 1), Is.EqualTo(new int[] { 2, 3}));
    }

    [Test]
    public void TestForNormalValue_ForGetPrimeNumbers()
    {
        var expected = new[] { 1, 2, 3, 5, 7 };

        var res = MyLinq.GetPrimeNumbers().Take(5).ToArray();

        Assert.That(expected, Is.EqualTo(res));
    }
}
