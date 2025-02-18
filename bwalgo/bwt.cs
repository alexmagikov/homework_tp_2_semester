public class BWTalgo
{
    public static (string, int) ForwardConversion(string str)
    {
        var permutations = new (string, int)[str.Length];
        var endCharPosition = str.Length;
        for (int i = 0; i < str.Length; i++)
        {
            permutations[i] = (str.Substring(i) + str.Substring(0, i), endCharPosition - i);
        }

        Array.Sort(permutations, new StringWithEndIndexesCompaper());

        string result = "";
        int resultEndIndex = 0;
        for (int i = 0; i < str.Length; i++)
        {
            result = result + permutations[i].Item1[^1];
            if (permutations[i].Item2 == endCharPosition)
            {
                resultEndIndex = i + 1;
            }
        }

        return (result, resultEndIndex);
    }

    public static string InverseConversion(string str, int endIndex)
    {
        endIndex--;
        var arrayOfCountCharsBefore = new int[str.Length];
        Dictionary<char, int> dictionaryOfCharCount = new Dictionary<char, int>();

        for (int i = 0; i < str.Length; i++)
        {
            if (!dictionaryOfCharCount.ContainsKey(str[i]))
            {
                dictionaryOfCharCount[str[i]] = 0;
            }
            arrayOfCountCharsBefore[i] = dictionaryOfCharCount[str[i]];
            dictionaryOfCharCount[str[i]]++;
        }

        Dictionary<char, int> dictionaryOfCharCountOfSmallerChars = new Dictionary<char, int>();
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

public class StringWithEndIndexesCompaper : IComparer<(string, int)>
{
    public int Compare((string, int) str1, (string, int) str2)
    {
        int i = 0;
        while (str1.Item1[i] == str2.Item1[i])
        {
            if (i == str1.Item2 || i == str2.Item2)
            {
                return str1.Item2 > str2.Item2 ? 1 : -1;
            }
            i++;
        }

        if (i == str1.Item2 || i == str2.Item2)
        {
            return i == str1.Item2 ? -1 : 1;
        }

        return str1.Item1[i].CompareTo(str2.Item1[i]);
    }
}