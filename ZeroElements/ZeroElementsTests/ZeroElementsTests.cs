// <copyright file="ZeroElementsTests.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace ZeroElementsTests;

using ZeroElements;

public class ZeroElementsTests
{
    [Test]
    public void IntList_ShouldReturnNormalValue()
        => Assert.That(
            CalculationZeroElements.CalculateZeroElements<int>([1, 2, 3, 0, 2, 0], new IntZeroChecker()),
            Is.EqualTo(2));

    [Test]
    public void AllZerosList_ShouldReturnListLength()
        => Assert.That(
            CalculationZeroElements.CalculateZeroElements([0, 0, 0], new IntZeroChecker()),
            Is.EqualTo(3));

    [Test]
    public void NoZerosList_ShouldReturnZero()
        => Assert.That(
            CalculationZeroElements.CalculateZeroElements([1, 2, 3], new IntZeroChecker()),
            Is.EqualTo(0));

    [Test]
    public void CharList_ShouldReturnNormalValue()
      => Assert.That(
            CalculationZeroElements.CalculateZeroElements<char>(['1', '2', ' ', '0', ' ', '1'], new CharZeroChecker()),
            Is.EqualTo(2));

    [Test]
    public void EmptyList_ShouldReturnZero()
        => Assert.That(
            CalculationZeroElements.CalculateZeroElements<int>(new List<int>(), new IntZeroChecker()),
            Is.EqualTo(0));

    [Test]
    public void NullList_ShouldReturnException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            CalculationZeroElements.CalculateZeroElements(null, new IntZeroChecker()));
    }

    public class IntZeroChecker : IZeroChecker<int>
    {
        public bool IsZero(int value)
            => value == 0;
    }

    public class CharZeroChecker : IZeroChecker<char>
    {
        public bool IsZero(char value)
            => value == ' ';
    }
}
