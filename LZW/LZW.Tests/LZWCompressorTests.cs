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
    public void TestForCompressForEqualValueSequence()
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
    public void TestForCompressForNullValue()
    {
        byte[] sequence = {};
        int[] expected = {};
        Assert.That(LZWcompressor.Compress(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForEncodeByteSequenceeForNormalValue()
    {
        int[] sequence = { 97, 98, 256, 256};
        byte[] expected = { 48, 152, 168, 5, 0 };
        Assert.That(LZWcompressor.EncodeByteSequencee(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForEncodeByteSequenceeForTwoDifferentValue()
    {
        int[] sequence = { 97, 98, 256, 512, 566 };
        byte[] expected = { 48, 152, 168, 6, 128, 52, 108};
        Assert.That(LZWcompressor.EncodeByteSequencee(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForEncodeByteSequenceeFor8BitValue()
    {
        int[] sequence = { 97, 98 };
        byte[] expected = { 48, 152, 128 };
        Assert.That(LZWcompressor.EncodeByteSequencee(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForEncodeByteSequenceeFor0Value()
    {
        int[] sequence = { 0 };
        byte[] expected = { 0, 0};
        Assert.That(LZWcompressor.EncodeByteSequencee(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForEncodeByteSequenceeForNullValue()
    {
        int[] sequence = {};
        byte[] expected = {};
        Assert.That(LZWcompressor.EncodeByteSequencee(sequence), Is.EqualTo(expected));
    }
}
