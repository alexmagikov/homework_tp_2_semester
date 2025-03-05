namespace LZW.Tests;

public class TestsForLZWCompressor
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
        int[] expected = { 97, 256, 257 };
        Assert.That(LZWcompressor.Compress(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForCompressForOneValue()
    {
        byte[] sequence = { 97 };
        int[] expected = { 97 };
        Assert.That(LZWcompressor.Compress(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForTransformSequenceForNormalValue()
    {
        int[] sequence = { 97, 98, 256, 257 };
        byte[] expected = { 97, 98, 128, 64, 64 };
        Assert.That(LZWcompressor.TransformSequence(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForTransformSequenceForTwoDifferentValue()
    {
        int[] sequence = { 97, 98, 256, 1500 };
        byte[] expected = { 97, 98, 128, 93, 192 };
        Assert.That(LZWcompressor.TransformSequence(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForTransformSequenceFor8BitValue()
    {
        int[] sequence = { 97, 98 };
        byte[] expected = { 97, 98 };
        Assert.That(LZWcompressor.TransformSequence(sequence), Is.EqualTo(expected));
    }
}
