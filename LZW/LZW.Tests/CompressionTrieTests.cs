namespace LZW.Tests;

public class TestsForTrie
{
    private CompressionTrie trie = new();
    [SetUp]
    public void Setup()
    {
        trie = new CompressionTrie();
    }

    [Test]
    public void TestForAddForTrieForNormalValue()
    {
        trie.Add([(byte)1], 0);
        Assert.That(trie.Contains([(byte)1]), Is.EqualTo(true));
    }

    [Test]
    public void TestForAddForTrieForEqualValue()
    {
        trie.Add([(byte)1], 0);
        Assert.That(trie.Add([(byte)1], 0), Is.EqualTo(false));
    }

    [Test]
    public void TestForSizeForTrieForNormalValue()
    {
        trie.Add([(byte)1], 0);
        Assert.That(trie.Size, Is.EqualTo(1));
    }

    [Test]
    public void TestForSizeForTrieForEqualValue()
    {
        trie.Add([(byte)1], 0);
        trie.Add([(byte)1], 0);
        Assert.That(trie.Size, Is.EqualTo(1));
    }

    [Test]
    public void TestForSetCode()
    {
        trie.Add([(byte)1], 1);
        Assert.That(trie.GetCode([(byte)1]), Is.EqualTo((1, true)));
    }
}
