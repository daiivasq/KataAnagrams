
using Anagrams;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace Anagram
{
     public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var path = @"C:\Users\Renombrar\Documents\REPOSITORIOS\INTEC\Anagrams\Anagrams\wordlist.txt";
            Archivo file = new Archivo(path);
            Hashing diccionary = new Hashing(file.get_array());
            Anagram2 anagram = new Anagram2(diccionary);

            TextWriter sw = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(sw);
            anagram.Print(sw);
            timer.Stop();


            Console.WriteLine();
            Console.WriteLine($"Cantidad de tiempo: {timer.Elapsed}");
            Console.WriteLine($"Cantidad de palabras en este archivo: {file.get_array().Length}");
            Console.WriteLine($"Cantidad de sets de anagramas: {anagram.anagrams_sets_quantity}");
            Console.WriteLine($"Cantidad de palabras con anagramas: {anagram.anagram_words_count}");
            sw.Flush();
            Console.ReadKey();


        }
    }
}