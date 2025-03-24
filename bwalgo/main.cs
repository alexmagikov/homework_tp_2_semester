using BWalgo;

if (!Tests.IsAllTestsCompleted())
{
    return -1;
}

Console.WriteLine("choose a type of conversion: 1 - forward, 2 - inverse:");
var choice = Convert.ToInt32(Console.ReadLine());

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

return choice switch
{
    1 => ProcessingForwardConversion(),
    2 => ProcessingInverseConversion(),
    _ => -1
};
        

int ProcessingForwardConversion()
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

int ProcessingInverseConversion()
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
 