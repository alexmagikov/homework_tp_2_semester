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
        var tree = new ParsingTree.ParsingTree(GetTestFilePath("TestForNormalValue_ParsingTreeCreateShouldReturnCorrectResult.txt"));
        Assert.That(tree.PrintTree(), Is.EqualTo("(* (+ 1 1) 2)"));
    }
    
    [Test]
    public void TestForDivideBy0Value_ParsingTreeCreateShouldReturnCorrectResult()
    {
        var tree = new ParsingTree.ParsingTree(GetTestFilePath("TestForDivideBy0Value_ParsingTreeCreateShouldReturnCorrectResult.txt"));
        Assert.Throws<DivideByZeroException>(() =>
        {
            var result = CalculateTree.Calculate(tree);
        });
    }
    
    private static string GetTestFilePath(string fileName)
    {
        var testDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        return Path.Combine(testDirectory!, "TestFiles", fileName);
    }
}