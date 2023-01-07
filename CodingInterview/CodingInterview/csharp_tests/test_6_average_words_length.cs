using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using NUnit.Framework;
// Task 6
// Write a program calculate average words length
namespace CodingInterview
{
    public class Class6
    {

        private static string RemoveSpecialCharacters(string message)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 ]");
            return regex.Replace(message, "");
        }

        private static double AverageWordsLength(string message)
        {
            var messageWithoutSpecialCharacters = RemoveSpecialCharacters(message);
            var words = messageWithoutSpecialCharacters.Split(' ');
            var wordLengthSum = 0;
            foreach (var word in words)
            {
                wordLengthSum = wordLengthSum + word.Length;
            }
            var response = (double)wordLengthSum / words.Length;
            return Math.Round(response, 2);
        }


        [Test]
        [TestCase("Hi all, my name is Tom...I am originally from Australia.", 4.2)]
        [TestCase("I need to work very hard to learn more about algorithms in Python!", 4.08)]
        public void CheckAverageWordsLength(string input, double expected_value)
        {
            Assert.AreEqual(AverageWordsLength(input), expected_value);
        }

    }

}