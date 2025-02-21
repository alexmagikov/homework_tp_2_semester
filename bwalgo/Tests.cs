namespace BWalgo;

public class Tests
{
    private static bool TestForNormalValueForForwardConversion()
        => BWTalgo.ForwardConversion("abacaba").Item1 == "bcabaaa" && BWTalgo.ForwardConversion("abacaba").Item2 == 3;
   

    private static bool TestForNormalValueForInverseConversion()
        => BWTalgo.InverseConversion("nnbaaa", 4) == "banana";
   

    private static bool TestForIdenticalConversion()
    {
        var result = BWTalgo.ForwardConversion("banana");
        return BWTalgo.InverseConversion(result.Item1, result.Item2) == "banana";
    }

    private static bool TestForNullStringForwardConversion()
    {
        var result = BWTalgo.ForwardConversion("");
        return result.Item1 == "" && result.Item2 == 0;
    }

    private static bool TestForStringWithDublicate()
    {
        var result = BWTalgo.ForwardConversion("bb");
        return result.Item1 == "bb" && result.Item2 == 1;
    }

    public static bool IsAllTestsCompleted()
    {
        bool[] array =
        {
                TestForNormalValueForForwardConversion(),
                TestForNormalValueForInverseConversion(),
                TestForIdenticalConversion(),
                TestForNullStringForwardConversion(),
                TestForStringWithDublicate(),
            };
        for (var i = 0; i < array.Length; i++)
        {
            if (!array[i])
            {
                Console.WriteLine($"test {i} is not completed");
                return false;
            }
        }

        return true;
    }
}

