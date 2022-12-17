using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
//Task 3
// Write a program to calculate fibonacci
namespace CodingInterview
{
    public class Class3
    {

        private static int GetFibonacciRecursive(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return GetFibonacciRecursive(n - 1) + GetFibonacciRecursive(n - 2);
        }

        private static int GetFibonacciIterative(int n)
        {
            var fibonacci_first = 0;
            var fibonacci_second = 1;
            foreach (var i in Enumerable.Range(1, n))
            {
                fibonacci_first = fibonacci_second;
                fibonacci_second = fibonacci_first + fibonacci_second;
            }
            return fibonacci_first;
        }

        [Test]
        public void CheckFibonacciRecursiveSmall()
        {
            var Expected = 13;
            var n = 7;
            Assert.AreEqual(GetFibonacciRecursive(n), Expected);
        }

        [Test]
        public void CheckFibonacciRecursiveBigger()
        {
            var Expected = 20;
            var n = 6765;
            Assert.AreEqual(GetFibonacciRecursive(n), Expected);
        }

        [Test]
        public void CheckFibonacciIterativeSmall()
        {
            var Expected = 13;
            var n = 7;
            Assert.AreEqual(GetFibonacciIterative(n), Expected);
        }

        [Test]
        public void CheckFibonacciIterativeBigger()
        {
            var Expected = 20;
            var n = 6765;
            Assert.AreEqual(GetFibonacciIterative(n), Expected);
        }
    }

}