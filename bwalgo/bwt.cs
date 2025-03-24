namespace BWalgo;
public class BWTalgo
{
    public static (string, int) ForwardConversion(string str)
    {
        var permutations = new (string, int)[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            permutations[i] = (str, i);
        }

        Array.Sort(permutations, new StringWithEndIndexesCompaper());
        string result = "";
        int resultEndIndex = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (permutations[i].Item2 == 0)
            {
                resultEndIndex = i + 1;
            }
            result = result + permutations[i].Item1[(permutations[i].Item2 + str.Length - 1) % str.Length];
        }

        return (result, resultEndIndex);
    }

    public static string InverseConversion(string str, int endIndex)
    {
        endIndex--;
        var arrayOfCountCharsBefore = new int[str.Length];
        Dictionary<char, int> dictionaryOfCharCount = new();

        for (int i = 0; i < str.Length; i++)
        {
            if (!dictionaryOfCharCount.ContainsKey(str[i]))
            {
                dictionaryOfCharCount[str[i]] = 0;
            }
            arrayOfCountCharsBefore[i] = dictionaryOfCharCount[str[i]];
            dictionaryOfCharCount[str[i]]++;
        }

        Dictionary<char, int> dictionaryOfCharCountOfSmallerChars = new();
        var sortedArrayByDictionaryOfCharCount = new List<char>(dictionaryOfCharCount.Keys);
        sortedArrayByDictionaryOfCharCount.Sort();
        var sum = 0;
        foreach (char ch in sortedArrayByDictionaryOfCharCount)
        {
            dictionaryOfCharCountOfSmallerChars[ch] = sum;
            sum += dictionaryOfCharCount[ch];
        }

        string result = "";
        result = result + str[endIndex];
        int lastNumRowInSortedTable = endIndex;
        for (int i = 0; i < str.Length - 1; i++)
        {
            lastNumRowInSortedTable = dictionaryOfCharCountOfSmallerChars[result[0]] + arrayOfCountCharsBefore[lastNumRowInSortedTable];
            result = str[lastNumRowInSortedTable] + result; 
        }

        return result;
    }
}
