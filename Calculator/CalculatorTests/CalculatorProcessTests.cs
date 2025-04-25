using Calculator;

namespace CalculatorTests;
public class CalculatorProcessTests
{
    private CalculatorProcess calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new CalculatorProcess(); 
    }

    [Test]
    public void TestForBasicSum_ShouldCalculatorProcessReturnNormalValue()
    {
        calculator.ProcessInput("1");
        calculator.ProcessInput("+");
        calculator.ProcessInput("2");
        calculator.ProcessInput("=");
        Assert.That(calculator.CurrentValue, Is.EqualTo(3));
    }

    [Test]
    public void TestForBasicSumForDoubleEquals_ShouldCalculatorProcessReturnNormalValue()
    {
        calculator.ProcessInput("1");
        calculator.ProcessInput("+");
        calculator.ProcessInput("2");
        calculator.ProcessInput("=");
        calculator.ProcessInput("=");
        Assert.That(calculator.CurrentValue, Is.EqualTo(5));
    }

    [Test]
    public void TestForDivisionException_ShouldCalculatorProcessReturnNormalValue()
    {
        calculator.ProcessInput("2");
        calculator.ProcessInput("/");
        Assert.Throws<DivideByZeroException>(() => calculator.ProcessInput("0"));
    }

    [Test]
    public void TestForComplexStatements_ShouldCalculatorProcessReturnNormalValue()
    {
        calculator.ProcessInput("1");
        calculator.ProcessInput("+");
        calculator.ProcessInput("1");
        calculator.ProcessInput("*");
        calculator.ProcessInput("2");
        calculator.ProcessInput("-");
        calculator.ProcessInput("8");
        calculator.ProcessInput("/");
        calculator.ProcessInput("2");
        calculator.ProcessInput("=");
        Assert.That(calculator.CurrentValue, Is.EqualTo(-2));
    }
}

