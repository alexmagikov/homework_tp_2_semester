// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

if (args.Length < 2)
{
    Console.WriteLine("Usage: program <inputPath> <outputPath>");
    return 1;
}

var inputPath = args[0];
var outputPath = args[1];

try
{
    var graph = CreateGraph.ReadFile(inputPath);
    PrimFindMst.FindMst(graph);
}
catch (FileNotFoundException exception)
{
    Console.WriteLine($"File not found: {exception.FileName}");
    return 1;
}
catch (FormatException exception)
{
    Console.WriteLine(exception.Message);
    return 1;
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
    return 1;
}

return 0;
