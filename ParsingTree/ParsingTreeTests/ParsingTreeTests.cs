using System.Reflection;
using ParsingTree;

namespace ParsingTreeTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestForNormalValue_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "*", "(", "+", "1", "1", ")", "2", ")"};
        var tree = new ParsingTree.ParsingTree(tokens);
        Assert.That(tree.PrintTree(), Is.EqualTo("(* (+ 1 1) 2)"));
    }
    
    [Test]
    public void TestForDivideBy0Value_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "/", "1", "0", ")"};
        var tree = new ParsingTree.ParsingTree(tokens);
        Assert.Throws<DivideByZeroException>(() =>
        {
            var result = CalculateTree.Calculate(tree);
        });
    }
    
    [Test]
    public void TestForMissingBracket_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "/", "1", "0"};
        Assert.Throws<FormatException>(() =>
        {
            var tree = new ParsingTree.ParsingTree(tokens);
        });
    }
    
    [Test]
    public void TestFor2OperandsInARow_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "/", "/", "0"};
        Assert.Throws<FormatException>(() =>
        {
            var tree = new ParsingTree.ParsingTree(tokens);
        });
    }
    
    [Test]
    public void TestForAllOperans_CalculateTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(","/", "(", "-", "(", "*", "(", "+", "3", "3", ")", "2", ")", "3", ")", "3",")"};
        var tree = new ParsingTree.ParsingTree(tokens);
        Assert.That( CalculateTree.Calculate(tree), Is.EqualTo(3));
    }
    
    [Test]
    public void TestForSoloOperand_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "/", "1", ")"};
        Assert.Throws<FormatException>(() =>
        {
            var tree = new ParsingTree.ParsingTree(tokens);
        });
    }
    
    [Test]
    public void TestForExtraOperand_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "/", "1", "1", "1", ")"};
        Assert.Throws<FormatException>(() =>
        {
            var tree = new ParsingTree.ParsingTree(tokens);
        });
    }
    
    [Test]
    public void TestForUnknownOperand_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "%", "1", "1", ")"};
        Assert.Throws<FormatException>(() =>
        {
            var tree = new ParsingTree.ParsingTree(tokens);
        });
    }
    
    [Test]
    public void TestForOppositeValueOperand_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tokens = new List<string>{"(", "+", "5", "-5", ")"};
        var tree = new ParsingTree.ParsingTree(tokens);
        Assert.That( CalculateTree.Calculate(tree), Is.EqualTo(0));
    }
}