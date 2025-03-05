// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;
using System.Text;
using LZW;
string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
string path = Path.Combine(exePath, @"..\..\..\test.txt");
path = Path.GetFullPath(path); // Нормализует путь
byte[] fileBytes = File.ReadAllBytes(path);

Console.WriteLine(Assembly.GetExecutingAssembly().Location);
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

// Вывод байтов
Console.WriteLine("Содержимое файла в байтах:");
foreach (var b in fileBytes)
{
    Console.Write($"{b} ");
}

//Console.WriteLine();
var result = LZWcompressor_WithBWalgo.Compress(fileBytes);

//foreach (var b in result)
//{
//    Console.Write($"{b} ");
//}

byte[] arr = LZWcompressor.TransformSequence(result);

////var n = LZWdecompressor.Decompress(result);

////foreach (var b in n)
////{
////    Console.Write($"{b} ");
////}
Console.WriteLine(LZWfunctions.GetCoefficient(fileBytes, arr.Length));

////List<int> values = LZWdecompressor.ReadVariableBitData(@"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped");

//int[] values = { 97, 98, 256, 1500 };

//var tmp = LZWcompressor.TransformSequence(values);

//Console.WriteLine("Прочитанные значения:");
//foreach (byte value in tmp)
//{
//    Console.Write($"{value} ");
//}

//Console.WriteLine(LZWfunctions.GetCoefficient(fileBytes, arr.Length));