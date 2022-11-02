using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
// Task 4
// Write a program to determine If the given year is a Leap year.
namespace CodingInterview
{
    public class Class4
    {

        private static bool IsLeapYear(int year) {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }


        [Test]
        [TestCase(2000)]
        [TestCase(2016)]
        [TestCase(2020)]
        [TestCase(2024)]
        [TestCase(2400)]
        public void CheckIsLeapYear(int year)
        {
            Assert.AreEqual(IsLeapYear(year), true);
        }

        [Test]
        [TestCase(1800)]
        [TestCase(1900)]
        [TestCase(2100)]
        [TestCase(2200)]
        [TestCase(2300)]
        public void CheckIsNotLeapYear(int year)
        {
            Assert.AreEqual(IsLeapYear(year), false);
        }

    }

}