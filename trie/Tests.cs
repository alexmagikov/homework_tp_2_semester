// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TrieProject;

/// <summary>
/// class for testing.
/// </summary>
public class Tests
{
    /// <summary>
    /// check for tests.
    /// </summary>
    /// <returns>return true if all tests are completed, else - false.</returns>
    public static bool IsAllTestsCompleted()
    {
        bool[] tests =
        {
            TestForNormalValueForAdd(),
            TestForNormalValueForContains(),
            TestForNullValueForAdd(),
            TestForNormalValueForRemove(),
            TestForSizeValueForAdd(),
            TestForSizeValueForRemove(),
            TestForHowManyStartsWithPrefix(),
            TestForHowManyStartsWithPrefixForNullValue(),
            TestForHowManyStartsWithPrefixWith2Branch(),
            TestForHowManyStartsWithPrefixWith2WordsIn1Branch(),
        };

        foreach (var test in tests)
        {
            if (!test)
            {
                return false;
            }
        }

        return true;
    }

    private static bool TestForNormalValueForAdd()
    {
        Trie trie = new ();
        trie.Add("exmpl");
        return trie != null;
    }

    private static bool TestForNullValueForAdd()
    {
        Trie trie = new ();
        return !trie.Add(string.Empty);
    }

    private static bool TestForSizeValueForAdd()
    {
        Trie trie = new ();
        trie.Add("smthng1");
        trie.Add("smthng2");
        return trie.Size == 2;
    }

    private static bool TestForNormalValueForContains()
    {
        Trie trie = new ();
        trie.Add("exmpl");
        return trie.Contains("exmpl");
    }

    private static bool TestForNormalValueForRemove()
    {
        Trie trie = new ();
        trie.Add("exmpl");
        trie.Remove("exmpl");
        return !trie.Contains("exmpl");
    }

    private static bool TestForSizeValueForRemove()
    {
        Trie trie = new ();
        trie.Add("smthng1");
        trie.Add("smthng2");
        trie.Remove("smthng1");
        return trie.Size == 1;
    }

    private static bool TestForHowManyStartsWithPrefix()
    {
        Trie trie = new ();
        trie.Add("smthng1");
        trie.Add("smthng2");
        return trie.HowManyStartsWithPrefix("smthng") == 2;
    }

    private static bool TestForHowManyStartsWithPrefixWith2Branch()
    {
        Trie trie = new ();
        trie.Add("smthngwwa");
        trie.Add("smthngwwb");
        return trie.HowManyStartsWithPrefix("smthng") == 2;
    }

    private static bool TestForHowManyStartsWithPrefixWith2WordsIn1Branch()
    {
        Trie trie = new ();
        trie.Add("smthngwwa");
        trie.Add("smthngwwaa");
        trie.Add("smthngwwaa");
        trie.Add("smthngwwaaи");
        return trie.HowManyStartsWithPrefix("smthng") == 3;
    }

    private static bool TestForHowManyStartsWithPrefixForNullValue()
    {
        Trie trie = new ();
        return trie.HowManyStartsWithPrefix(string.Empty) == 0;
    }
}