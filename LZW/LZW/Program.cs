// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;
using LZW;

string path = args[0];
string parameterForCompression = args[1];

switch (parameterForCompression)
{
    case "-c":
        byte[] fileBytes = File.ReadAllBytes(path);
        int[] compressedData = LZWcompressor.Compress(fileBytes);
        Console.WriteLine();
        byte[] encodedData = LZWcompressor.EncodeByteSequencee(compressedData);
        LZWcompressor.WriteInFile(encodedData, path);
        break;

    case "-u":
        byte[] decodedData = LZWdecompresso(path);
        int[] codes = LZWdecompressor.DecodeByteSequence(decodedData);
        byte[] inputSequence = LZWdecompressor.Decompress(codes);
        break;

    default:
        throw new ArgumentException($"Unknown parameter: {parameterForCompression}");
}

Console.WriteLine("Compare compression with BW and without BW:");
LZWfunctions.CompareLZWCompressorWithBWAndWithoutBWOnRandomText();
LZWfunctions.CompareLZWCompressorWithBWAndWithoutBWOnRandomSequenceOfSymbols();



//Console.WriteLine(Assembly.GetExecutingAssembly().Location);
//// Вывод байтов
//Console.WriteLine("Содержимое файла в байтах:");
//foreach (var b in fileBytes)
//{
//    Console.Write($"{b} ");
//}
//Console.WriteLine();

// C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped

//using LZW;



//var result = LZWcompressor.Compress(fileBytes);
//Console.WriteLine("file data: ");
//foreach (var value in fileBytes)
//{
//    Console.Write($"{value} ");
//}

//Console.WriteLine("\nencoded data: ");
//byte[] arr = LZWcompressor.EncodeByteSequencee(result);
//foreach (int value in arr)
//{
//    Console.Write($"{value} ");
//}

//Console.WriteLine("\nencoded data: ");

//int[] r = LZWdecompressor.DecodeByteSequence(arr);
//foreach (int value in r)
//{
//    Console.Write($"{value} ");

//Console.WriteLine("fwfwfw");

//////List<int> values = LZWdecompressor.ReadVariableBitData(@"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped");

////Console.WriteLine(LZWfunctions.GetCoefficient(fileBytes, arr.Length));

//byte[] sequence = { 97, 98, 128, 64, 0 };
//int[] seq = LZWdecompressor.DecodeByteSequence(sequence);
//foreach (int value in seq)
//{
//    Console.Write($"{value} ");
//}

////Console.WriteLine(args.Length);

//// file.Create(@"C:\Users\User\source\repos\homework_tp_2_smstr\homework_tp_2_semester\LZW\LZW\test.zipped");\

/////var str = File.ReadAllText(path);

////Console.WriteLine(str);


////// Преобразование байтов в текст (UTF-8)
////string text = Encoding.UTF8.GetString(fileBytes);

////// Вывод текста
////Console.WriteLine("Содержимое файла как текст:");
////Console.WriteLine(text);

////CompressionTrie trie = new ();

//LZWfunctions.CompareLZWCompressorWithBWAndWithoutBW();