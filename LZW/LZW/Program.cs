// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text;
using LZW;

string path = @"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test1.txt";
//FileInfo fileInfo = new FileInfo(path);
//if (fileInfo.Exists)
//{
//    Console.WriteLine($"Имя файла: {fileInfo.Name}");
//    Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
//    Console.WriteLine($"Размер: {fileInfo.Length}");
//}

//foreach (var arg in args)
//{
//    Console.WriteLine(arg);
//}

//Console.WriteLine(args.Length);

// file.Create(@"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped");\

///// <summary>
///// LZW forward conversion.
///// </summary>

var str = File.ReadAllText(path);
Console.WriteLine(str);

byte[] fileBytes = File.ReadAllBytes(path);

// Преобразование байтов в текст (UTF-8)
string text = Encoding.UTF8.GetString(fileBytes);

// Вывод текста
//Console.WriteLine("Содержимое файла как текст:");
//Console.WriteLine(text);

CompressionTrie trie = new ();

byte[] sequence = { 97, 97, 97, 97, 97, 97 };
// Вывод байтов
Console.WriteLine("Содержимое файла в байтах:");
foreach (var b in sequence)
{
    Console.Write($"{b} ");
}

Console.WriteLine();
var result = LZWcompressor.Compress(sequence);

foreach (var b in result)
{
    Console.Write($"{b} ");
}

int num = LZWcompressor.WriteInFile(result, @"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test1.zipped");

//var n = LZWdecompressor.Decompress(result);

//foreach (var b in n)
//{
//    Console.Write($"{b} ");
//}

Console.WriteLine(LZWfunctions.GetCoefficient(fileBytes, num));

List<int> values = LZWdecompressor.ReadVariableBitData(@"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped");

Console.WriteLine("Прочитанные значения:");
foreach (int value in values)
{
    Console.Write($"{value} ");
}