// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;
using System.Text;
using LZW;
string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
string path = Path.Combine(exePath, @"..\..\..\test1.txt");
path = Path.GetFullPath(path); // Нормализует путь
byte[] fileBytes = File.ReadAllBytes(path);

Console.WriteLine(Assembly.GetExecutingAssembly().Location);
// Вывод байтов
Console.WriteLine("Содержимое файла в байтах:");
foreach (var b in fileBytes)
{
    Console.Write($"{b} ");
}
Console.WriteLine();

var resul = LZWcompressor.Compress(fileBytes);
foreach (int value in resul)
{
    Console.Write($"{value} ");
}
Console.WriteLine();
Console.WriteLine();
int[] result = { 97, 98, 256, 256 };
Console.WriteLine();
byte[] arr = LZWcompressor.TransformSequence(result);
foreach (int value in arr)
{
    Console.Write($"{value} ");
}

Console.WriteLine();

Console.WriteLine(LZWfunctions.GetCoefficient(fileBytes, arr.Length));

////List<int> values = LZWdecompressor.ReadVariableBitData(@"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped");

//Console.WriteLine(LZWfunctions.GetCoefficient(fileBytes, arr.Length));

byte[] sequence = { 97, 98, 128, 64, 0 };
int[] seq = LZWdecompressor.DecodeByteSequence(sequence);
foreach (int value in seq)
{
    Console.Write($"{value} ");
}

//Console.WriteLine(args.Length);

// file.Create(@"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped");\

///// <summary>
///// LZW forward conversion.
///// </summary>

///var str = File.ReadAllText(path);

//Console.WriteLine(str);


//// Преобразование байтов в текст (UTF-8)
//string text = Encoding.UTF8.GetString(fileBytes);

//// Вывод текста
//Console.WriteLine("Содержимое файла как текст:");
//Console.WriteLine(text);

//CompressionTrie trie = new ();

LZWfunctions.CompareLZWCompressorWithBWAndWithoutBW();