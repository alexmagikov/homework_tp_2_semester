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

    [Test]
    public void TestForDecodeByteSequenceeForNormalValue()
    {
        int[] expected = { 97, 98, 256, 256 };
        byte[] sequence = { 48, 152, 168, 5, 0 };
        Assert.That(LZWdecompressor.DecodeByteSequence(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForDecodeByteSequenceeForTwoDifferentValue()
    {
        int[] expected = { 97, 98, 256, 512, 566 };
        byte[] sequence = { 48, 152, 168, 6, 128, 52, 108 };
        Assert.That(LZWdecompressor.DecodeByteSequence(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForDecodeByteSequenceeFor8BitValue()
    {
        int[] expected = { 97, 98 };
        byte[] sequence = { 48, 152, 128 };
        Assert.That(LZWdecompressor.DecodeByteSequence(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForDecodeByteSequenceeFor0Value()
    {
        int[] expected = { 0 };
        byte[] sequence = { 0, 0 };
        Assert.That(LZWdecompressor.DecodeByteSequence(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void TestForDecodeAndReturnInputFile()
    {
        byte[] inputSeq = { 96, 97, 98 };
        int[] codes = LZWcompressor.Compress(inputSeq);
        byte[] encode = LZWcompressor.EncodeByteSequencee(codes);
        Assert.That(LZWdecompressor.DecodeByteSequence(encode), Is.EqualTo(inputSeq));
    }
}
