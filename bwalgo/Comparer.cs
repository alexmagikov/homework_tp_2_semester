namespace BWalgo;

public class StringWithEndIndexesCompaper : IComparer<(string, int)>
{
    public int Compare((string, int) str1, (string, int) str2)
    {
        var indexStr1 = str1.Item2;
        var indexStr2 = str2.Item2;
        while (indexStr1 < str1.Item2 + str1.Item1.Length)
        {
            if (str1.Item1[indexStr1 % (str1.Item1.Length)] == str2.Item1[indexStr2 % (str2.Item1.Length)])
            {
                indexStr1++;
                indexStr2++;
            }
            else
            {
                break;
            }
        }

        return str1.Item1[indexStr1 % (str1.Item1.Length)].CompareTo(str1.Item1[indexStr2 % (str2.Item1.Length)]);
    }
}
