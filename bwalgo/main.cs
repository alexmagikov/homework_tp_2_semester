using System;
using System.Runtime.CompilerServices;

namespace BWalgo
{
    public class BWalgo
    {
        static int Main(string[] args)
        {
            if (!Tests.IsAllTestsCompleted())
            {
                return -1;
            }

            Console.WriteLine("choose a type of conversion: 1 - forward, 2 - inverse:");
            var choice = Convert.ToInt32(Console.ReadLine());

            return choice switch
            {
                1 => ProccessingForwardConversion(),
                2 => ProccessingInverseConversion(),
                _ => -1
            };
        }

        static private int ProccessingForwardConversion()
        {
            Console.WriteLine("input string: ");
            var str = Console.ReadLine();
            if (str is null)
            {
                Console.WriteLine("error: string is null");
                return -1;
            }
            var result = BWTalgo.ForwardConversion(str);
            var transformedStr = result.Item1;
            var numOfInputStringMatrix = result.Item2;
            Console.WriteLine($"transformed string: {transformedStr}");
            Console.WriteLine($"num of input string in matrix: {numOfInputStringMatrix}");
            return 0;
        }

        static private int ProccessingInverseConversion()
        {
            Console.WriteLine("transformed string: ");
            var transformedStr = Console.ReadLine();
            if (transformedStr is null)
            {
                Console.WriteLine("error: string is null");
                return -1;
            }
            Console.WriteLine("num of input string in matrix: ");
            var numOfInputStringMatrix = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"the original string is {BWTalgo.InverseConversion(transformedStr, numOfInputStringMatrix)}");

            return 0;
        }
    }

    public class Tests
    {
        private static bool TestForNormalValueForForwardConversion()
        {
            string str = "abacaba";
            return BWTalgo.ForwardConversion(str).Item1 == "bcabaaa" && BWTalgo.ForwardConversion(str).Item2 == 3;
        }

        private static bool TestForNormalValueForInverseConversion()
        {
            string str = "nnbaaa";
            int numOfInputStringMatrix = 4;
            return BWTalgo.InverseConversion(str, numOfInputStringMatrix) == "banana";
        }

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
            return result.Item1 == "bb" && result.Item2 == 2;
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
}
