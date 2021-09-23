using Anagrams;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AnagramsTest
{
    public class Tests
    {

        [Test]
        public void FindAllAnagrams_NoWords_ReturnsEmptyResult()
        {
            var result = Anagram.FindAllAnagrams(new string[0]);

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

       

    }
}