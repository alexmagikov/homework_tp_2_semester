using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class BWTalgo
{
    public static (string, int) ForwardConversion(string str)
    {
        var permutations = new (string, int)[str.Length + 1];
        var endChar = '$';
        var endCharPosition = str.Length;
        var tmpStr = str + endChar;
        permutations[0] = (tmpStr.Substring(tmpStr.Length) + tmpStr.Substring(0, tmpStr.Length), endCharPosition);
        Console.WriteLine(permutations[0]);
        for (int i = 1; i < tmpStr.Length; i++)
        {
            permutations[i] = (tmpStr.Substring(tmpStr.Length - i) + tmpStr.Substring(0, tmpStr.Length - i), endCharPosition + i - tmpStr.Length);
            Console.WriteLine(permutations[i]);
        }

        Array.Sort(permutations, new StringWithEndIndexesCompaper());
        Console.WriteLine();
        for (int i = 0; i < tmpStr.Length; i++)
        {
            Console.WriteLine(permutations[i]);
        }

        string result = "";
        int resultEndIndex = 0;
        for (int i = 0; i < tmpStr.Length; i++)
        {
            result = result + permutations[i].Item1[^1];
            if (permutations[i].Item1[^1] == endChar && permutations[i].Item2 == endCharPosition)
            {
                resultEndIndex = i;
            }
        }
        Console.WriteLine(result);
        return (result, resultEndIndex);
    }

    public static string InverseConversion(string str, int endIndex)
    {
        var array = str.ToCharArray(0, str.Length);
        for (int i = 0; i < str.Length; i++)
        {
          // Array.Sort(array, new StringWithEndIndexesCompaper());
        }
        return "";
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

    
