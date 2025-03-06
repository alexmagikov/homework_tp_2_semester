namespace LZW.Tests;

public class TestsForLZWDecompressor
{
    [Test]
    public void TestForDecompressForNormalValue()
    {
        byte[] expected = { 97, 98, 97, 98, 97, 98 };
        int[] sequence = { 97, 98, 256, 256 };
        Assert.That(LZWdecompressor.Decompress(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForDecompressForEqualValueSequence()
    {
        byte[] expected = { 97, 97, 97, 97, 97, 97 };
        int[] sequence = { 97, 256, 257 };
        Assert.That(LZWdecompressor.Decompress(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForDecompressForOneValue()
    {
        byte[] expected = { 97 };
        int[] sequence = { 97 };
        Assert.That(LZWdecompressor.Decompress(sequence), Is.EqualTo(expected));
    }

    //[Test]
    //public void TestForDecodeForNormalValue()
    //{
    //    int[] expected = { 97, 98, 256, 257 };
    //    byte[] sequence = { 97, 98, 128, 64, 64 };
    //    Assert.That(LZWdecompressor.e(sequence), Is.EqualTo(expected));
    //}
}
