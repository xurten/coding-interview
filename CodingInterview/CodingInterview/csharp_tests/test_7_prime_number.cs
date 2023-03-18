using System;
using NUnit.Framework;

// Task 7
// Write a program to check if a number is a prime number
namespace CodingInterview
{
    public class Class7
    {
        public static bool Is_Prime(int number)
        {
            var prime_status = true;
            for(var k = 2;k < Math.Round((decimal)number / 2); k++)
            {
                if(number % k == 0)
                {
                    prime_status = false;
                    break;
                }
            }
            return prime_status;
        }

        [Test]
        [TestCase(13, true)]
        [TestCase(2000, false)]
        public void CheckIsPrime(int input, bool expected_value)
        {
            Assert.AreEqual(Is_Prime(input), expected_value);
        }
    }
}

