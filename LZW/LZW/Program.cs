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
        byte[] encodedData = LZWcompressor.EncodeByteSequencee(compressedData);
        LZWcompressor.WriteInFile(encodedData, path);
        break;

    case "-u":
        byte[] decodedData = File.ReadAllBytes(path);
        int[] codes = LZWdecompressor.DecodeByteSequence(decodedData);
        byte[] inputSequence = LZWdecompressor.Decompress(codes);
        LZWdecompressor.WriteInFile(inputSequence, path);
        break;

    default:
        throw new ArgumentException($"Unknown parameter: {parameterForCompression}");
}

Console.WriteLine("Compare compression with BW and without BW:");
LZWfunctions.CompareLZWCompressorWithBWAndWithoutBWOnRandomText();
LZWfunctions.CompareLZWCompressorWithBWAndWithoutBWOnRandomSequenceOfSymbols();