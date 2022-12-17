using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
// Task 5
// Reverese a string
namespace CodingInterview
{
    public class Class5
    {

        private static string ReverseSentence(string input_sequence) {
            var sequence_array = input_sequence.Split(" ");
            var sequence_array_reversed = sequence_array.Reverse();
            var result = "";
            foreach(var element in sequence_array_reversed)
            {
                result += element + " ";
            }
            return result.Trim();
        }


        [Test]
        [TestCase("How are you?", "you? are How")]
        public void CheckIsInReverseSequence(string input, string expected_value)
        {
            Assert.AreEqual(ReverseSentence(input), expected_value);
        }

    }

}