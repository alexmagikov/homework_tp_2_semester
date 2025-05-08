// <copyright file="SkipListTests.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace SkipListTests;

using SkipList;

public class SkipListTests
{
    private SkipList<int> skipList;

    [SetUp]
    public void Setup()
    {
        this.skipList = new SkipList<int>(Comparer<int>.Default);
    }

    [Test]
    public void TestForNormalValue_ShouldSkipListAddElement()
    {
        this.skipList.Add(3);
        this.skipList.Add(1);
        this.skipList.Add(2);
        Assert.That(this.skipList[1], Is.EqualTo(2));
    }

    [Test]
    public void TestForBadIndexes_ShouldSkipListGetElementByIndexReturnException()
    {
        this.skipList.Add(3);
        Assert.Throws<ArgumentOutOfRangeException>(() => { var tmp = this.skipList[3]; });
    }

    [Test]
    public void TestForEqualValue_ShouldSkipListAddElement()
    {
        this.skipList.Add(3);
        this.skipList.Add(3);
        Assert.That(this.skipList[1], Is.EqualTo(3));
    }

    [Test]
    public void TestForEqualValue_ShouldSkipListReturnCount()
    {
        this.skipList.Add(3);
        this.skipList.Add(3);
        Assert.That(this.skipList.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestForNormalValue_ShouldSkipListRemoveElement()
    {
        this.skipList.Add(2);
        this.skipList.Add(3);
        this.skipList.Remove(2);
        Assert.That(this.skipList[0], Is.EqualTo(3));
    }

    [Test]
    public void TestForNormalValue_ShouldSkipListRemoveByIndexElement()
    {
        this.skipList.Add(2);
        this.skipList.Add(3);
        this.skipList.RemoveAt(1);
        Assert.That(this.skipList[0], Is.EqualTo(2));
    }

    [Test]
    public void TestForNormalValue_ShouldSkipListRemoveByIndexCountReturnNormalValue()
    {
        this.skipList.Add(2);
        this.skipList.Add(3);
        this.skipList.RemoveAt(1);
        Assert.That(this.skipList.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestForBadValue_ShouldSkipListRemoveReturnException()
    {
        this.skipList.Add(2);
        this.skipList.Add(3);
        Assert.That(this.skipList.Remove(1), Is.EqualTo(false));
    }

    [Test]
    public void TestForNormalValue_ShouldSkipListClearAll()
    {
        this.skipList.Add(2);
        this.skipList.Add(3);
        this.skipList.Clear();
        Assert.That(this.skipList.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestForNormalValue_ShouldIteratorReturnNormalValue()
    {
        this.skipList.Add(2);
        this.skipList.Add(3);
        var expected = new int[2] { 2, 3 };
        var index = 0;

        foreach (var item in this.skipList)
        {
            Assert.That(item, Is.EqualTo(expected[index]));
            index++;
        }
    }

    [Test]
    public void TestForNormalValue_ShouldCopyAllElements()
    {
        this.skipList.Add(2);
        this.skipList.Add(1);
        this.skipList.Add(3);

        var result = new int[3];
        var expected = new int[3] { 1, 2, 3 };
        this.skipList.CopyTo(result, 0);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestForNormalValue_ShouldContainsReturnTrue()
    {
        this.skipList.Add(2);
        this.skipList.Add(1);
        this.skipList.Add(3);

        Assert.That(this.skipList.Contains(2), Is.EqualTo(true));
    }
}
