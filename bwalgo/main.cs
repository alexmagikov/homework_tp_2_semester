using System;
using System.Runtime.CompilerServices;

namespace BWalgo
{
    public class BWalgo
    {
        static int Main(string[] args)
        {
            var str = System.Console.ReadLine();
            if (str is null)
            {
                Console.WriteLine("error: string is null");
                return -1;
            }
            str = BWTalgo.ForwardConversion(str).Item1;
            return 0;
        }
    }

    public class Tests
    {

    }
}
