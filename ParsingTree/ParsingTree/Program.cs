// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

try
{
    var path = args[0];
    var tokens = ParsingTree.ReaderFile.Tokenize(path);
    var tree = new ParsingTree.ParsingTree(tokens);
    var result = ParsingTree.CalculateTree.Calculate(tree);
    Console.WriteLine($"ParsingTree: {tree.PrintTree()}");
    Console.WriteLine($"result: {result}");
    return 0;
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
    return -1;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
    return -1;
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
    return -1;
}