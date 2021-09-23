using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Anagrams
{
    public class Anagram
    {

        public static string[] ConvertTxToArray(string path)
        {
            var allLines = File.ReadAllLines(path);
            var words = allLines
                .Where(x => x != string.Empty)
                .ToArray();

            return words;
        }


        public static string[] FindAllAnagrams(string[] words)
        {
        
            var dic = new Dictionary<string, string>();

            foreach (var word in words.Where(x => x.Length > 1))
            {
                string ordered = new string(word.OrderBy(c => c).ToArray());

                if (dic.ContainsKey(ordered))
                {
                    dic[ordered] += " " + word;
                }
                else
                {
                    dic[ordered] = word;
                }
            }

            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }

    }
}
