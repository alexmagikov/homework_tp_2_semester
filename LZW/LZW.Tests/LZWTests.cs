using LZW;

namespace LZW.Tests;

public class TestsForLZW
{
    [Test]
    public void TestForCompressForNormalValue()
    {
        byte[] sequence = { 97, 98, 97, 98, 97, 98 };
        int[] expected = { 97, 98, 256, 256 };
        Assert.That(LZWcompressor.Compress(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForCompressForStaticValue()
    {
        byte[] sequence = { 97, 97, 97, 97, 97, 97 };
        int[] expected = { 97, 256, 257};
        Assert.That(LZWcompressor.Compress(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForCompressForOneValue()
    {
        byte[] sequence = { 97 };
        int[] expected = { 97 };
        Assert.That(LZWcompressor.Compress(sequence), Is.EqualTo(expected));
    }
}
