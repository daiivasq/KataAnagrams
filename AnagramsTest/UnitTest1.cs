using Anagrams;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AnagramsTest
{
    public class Tests
    {

        [Test]
        public void New_Object_Has_Empty_Array()
        {
            string[] expected_resultd = new string[] { };
            Archivo ar = new Archivo();
            string[] output = ar.get_array();
            Assert.AreEqual(output, expected_resultd);
        }


        [Test]
        public void Assert_Dictionary_Hashmap()
        {
            Hashing hashmap = new Hashing();
            Dictionary<string, List<string>> expected = new Dictionary<string, List<string>>();
            Assert.AreEqual(hashmap.anagrams, expected);
        }

        [Test]
        public void Assert_Sorting_Dictionary_Anagrams_Only()
        {
            string[] words = new string[] { "cat", "tca", "cta", "bos", "obs", "sob", "water" };
            Hashing hashmap = new Hashing(words);
            Dictionary<string, List<string>> expected = new Dictionary<string, List<string>>()
            {
                ["act"] = new List<string>() { "cat", "tca", "cta" },
                ["bos"] = new List<string>() { "bos", "obs", "sob" },
            };

            Assert.AreEqual(hashmap.anagrams, expected);
        }

        [Test]
        public void Assert_Sorting_Dictionary_All_Words()
        {
            string[] words = new string[] { "cat", "tca", "cta", "bos", "obs", "sob", "water" };
            Hashing hashmap = new Hashing(words);
            Dictionary<string, List<string>> expected = new Dictionary<string, List<string>>()
            {
                ["act"] = new List<string>() { "cat", "tca", "cta" },
                ["bos"] = new List<string>() { "bos", "obs", "sob" },
                ["aertw"] = new List<string>() { "water" }
            };

            Assert.AreEqual(hashmap.words, expected);
        }

        [Test]
        public void Print_Correct_Output()
        {
            StringBuilder sb = new StringBuilder();

            string[] words = new string[] { "CAt", "TcA", "cta", "bos", "obs", "sob", "water" };
            string[] anagrams_set = new string[] { "cat, tca, cta", "bos, obs, sob" };
            Hashing hashmap = new Hashing(words);
            Anagram2 anagrams = new Anagram2(hashmap);

            TextWriter sw = new StringWriter();
            Console.SetOut(sw);

            anagrams.Print(sw);

            string output = sw.ToString();


            Assert.AreEqual(string.Join(Environment.NewLine, anagrams_set) + "\r\n", output);


        }

    }
}