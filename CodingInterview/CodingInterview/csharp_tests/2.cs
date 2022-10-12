using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
//Task 2
// Write a program to display the list of even numbers.
namespace CodingInterview
{
    public class Class2
    {

        private static List<int> GetEvenNumbers(int n)
        {
            var asList = Enumerable
                .Range(1, n)
                .ToList()
                .FindAll(e => e % 2 == 0)
                .ToList();
            asList.ForEach(i => Console.Write("{0}\t", i));
            return asList;
        }

        [Test]
        public void CheckEvenNumbers()
        {
            var ExpectedEvenList = new List<int>() {2,4,6,8};
            var n = 9;
            Assert.AreEqual(GetEvenNumbers(n), ExpectedEvenList);
        }
    }

}