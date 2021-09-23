using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Anagrams
{
    public class Anagram2
    {
        public Dictionary<string, List<string>> anagrams;
        public string longest_key = "";
        public int anagrams_sets_quantity = 0;
        public int anagram_words_count = 0;

        public Anagram2(Hashing dic)
        {
            anagrams = dic.anagrams;
        }
        public void Print(TextWriter sw)
        {
            foreach (var set in anagrams)
            {
                anagram_words_count += set.Value.Count;
                anagrams_sets_quantity++;
                sw.WriteLine(string.Join(", ", set.Value));

                if (set.Key.Length > longest_key.Length)
                    longest_key = set.Key;
            }
        }
    }

    public class Hashing
    {
        public Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

        public Hashing()
        {

        }

        public Hashing(string[] lines)
        {
            SortWords(lines);
        }

        private void SortWords(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string word = lines[i].ToLower();
                char[] characters = word.ToCharArray();
                Array.Sort(characters);
                string sorted_word = new string(characters);

                if (words.ContainsKey(sorted_word))
                {
                    if (!words[sorted_word].Contains(word))
                    {
                        words[sorted_word].Add(word);
                    }
                    if (words[sorted_word].Count > 1)
                    {
                        anagrams[sorted_word] = words[sorted_word];
                    }
                }
                else
                {
                    words.Add(sorted_word, new List<string>());
                    words[sorted_word].Add(word);
                }
            }
        }
    }

    public class Archivo
    {
        private string[] Internal_Arr = null;

        public Archivo()
        {
            Internal_Arr = new string[] { };
        }
        public Archivo(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"El archivo \"{path}\" no pudo ser encotnrado");
            }

            StreamReader sr = new StreamReader(path);
            string line;
            List<string> list_string = new List<string>();

            while ((line = sr.ReadLine()) != null)
            {
                list_string.Add(line);
            }

            this.Internal_Arr = list_string.ToArray();

        }
        public string[] get_array()
        {
            return this.Internal_Arr;
        }

    }
}
