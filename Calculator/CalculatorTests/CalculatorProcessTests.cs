// <copyright file="CalculatorProcessTests.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace CalculatorTests;

using Calculator;

public class CalculatorProcessTests
{
    private CalculatorProcess calculator;

    [SetUp]
    public void Setup()
    {
        this.calculator = new CalculatorProcess();
    }

    [Test]
    public void TestForBasicSum_ShouldCalculatorProcessReturnNormalValue()
    {
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("+");
        this.calculator.ProcessInput("2");
        this.calculator.ProcessInput("=");
        Assert.That(this.calculator.CurrentValue, Is.EqualTo(3));
    }

    [Test]
    public void TestForBasicSumForDoubleEquals_ShouldCalculatorProcessReturnNormalValue()
    {
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("+");
        this.calculator.ProcessInput("2");
        this.calculator.ProcessInput("=");
        this.calculator.ProcessInput("=");
        Assert.That(this.calculator.CurrentValue, Is.EqualTo(5));
    }

    [Test]
    public void TestForDivisionException_ShouldCalculatorProcessReturnNormalValue()
    {
        this.calculator.ProcessInput("2");
        this.calculator.ProcessInput("/");
        this.calculator.ProcessInput("0");
        Assert.Throws<DivideByZeroException>(() => this.calculator.ProcessInput("="));
    }

    [Test]
    public void TestForComplexStatements_ShouldCalculatorProcessReturnNormalValue()
    {
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("+");
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("*");
        this.calculator.ProcessInput("2");
        this.calculator.ProcessInput("-");
        this.calculator.ProcessInput("8");
        this.calculator.ProcessInput("/");
        this.calculator.ProcessInput("2");
        this.calculator.ProcessInput("=");
        Assert.That(this.calculator.CurrentValue, Is.EqualTo(-2));
    }

    [Test]
    public void TestForComplexNumbers_ShouldCalculatorProcessReturnNormalValue()
    {
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("+");
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("2");
        this.calculator.ProcessInput("=");
        Assert.That(this.calculator.CurrentValue, Is.EqualTo(13));
    }

    [Test]
    public void TestForNegativeNumbers_ShouldCalculatorProcessReturnNormalValue()
    {
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("+");
        this.calculator.ProcessInput("-");
        this.calculator.ProcessInput("1");
        this.calculator.ProcessInput("=");
        Assert.That(this.calculator.CurrentValue, Is.EqualTo(0));
    }
}