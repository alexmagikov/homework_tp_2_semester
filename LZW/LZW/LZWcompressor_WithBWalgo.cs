namespace LZW;

public class LZWcompressor_WithBWalgo
{
    /// <summary>
    /// Forward conversion of LZW.
    /// </summary>
    /// <param name="sequence">Input array of bytes.</param>
    /// <returns>Transformed array of int codes.</returns>
    public static int[] Compress(byte[] str)
    {
        string sequence = System.Text.Encoding.UTF8.GetString(str);
        sequence = BWalgo.ForwardConversion(sequence).Item1;

        int code = 256;
        var trieOfBytes = CompressionTrie.InitializeTrieBytes();

        List<int> compressedSequence = new();
        List<byte> currentElement = new();

        foreach (byte element in sequence)
        {
            List<byte> tmpElement = new List<byte>(currentElement);
            tmpElement.Add(element);

            if (!trieOfBytes.Contains(tmpElement.ToArray()))
            {
                compressedSequence.Add(trieOfBytes.GetCode(currentElement.ToArray()).Item1);
                trieOfBytes.Add(tmpElement.ToArray(), code);
                currentElement.Clear();
                currentElement.Add(element);
                code++;
            }
            else
            {
                currentElement = tmpElement;
            }
        }

        if (currentElement.Count > 0)
        {
            compressedSequence.Add(trieOfBytes.GetCode(currentElement.ToArray()).Item1);
        }

        return compressedSequence.ToArray();
    }
}
