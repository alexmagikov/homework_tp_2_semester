using System.Reflection;

namespace RoutersTests;

using NUnit.Framework.Internal;
using Routers;

/// <summary>
/// Tests for Routers Project.
/// </summary>
public class PrimTests
{
    /// <summary>
    /// Test for normal value for Prim`s algo.
    /// </summary>
    [Test]
    public void TestForNormalGraph_ShouldCreateTheMst()
    {
        var graph = new RoutersGraph(GetTestFilePath("TestForNormalGraph_ShouldCreateTheMst.txt"));
        var resultGraph = PrimFindMst.FindMst(graph);
        var expectedGraph = new RoutersGraph();
        expectedGraph.AddEdgeOfRouters(1, 2, 10);
        expectedGraph.AddEdgeOfRouters(1, 4, 7);
        expectedGraph.AddEdgeOfRouters(1, 3, 5);
        Assert.That(resultGraph.CompareGraph(expectedGraph), Is.EqualTo(true));
    }

    /// <summary>
    /// Test for no connected graph.
    /// </summary>
    [Test]
    public void TestForNoConnectedGraph_ShouldCreateTheMst()
    {
        var graph = new RoutersGraph(GetTestFilePath("TestForNoConnectedGraph_ShouldCreateTheMst.txt"));
        Assert.Throws<NotConnectedGraphException>(() => PrimFindMst.FindMst(graph));
    }

    /// <summary>
    /// Test for no not corrected format file.
    /// </summary>
    [Test]
    public void TestForFormatException_ShouldCreateTheMst()
    {
        Assert.Throws<FormatException>(() =>
        {
            var routersGraph = new RoutersGraph(GetTestFilePath("TestForFormatException_ShouldCreateTheMst.txt"));
        });
    }

    /// <summary>
    /// Test for null graph.
    /// </summary>
    [Test]
    public void TestForNullGraph_ShouldCreateTheMst()
    {
        var graph = new RoutersGraph();
        Assert.Throws<NullGraphException>(() => PrimFindMst.FindMst(graph));
    }

    private static string GetTestFilePath(string fileName)
    {
        var testDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        return Path.Combine(testDirectory!, "TestFiles", fileName);
    }
}