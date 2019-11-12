using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterview
{
    public class Tests
    {
        int[] RemoveDuplicates(int[] arrayOfNumbers)
        {
            var numbers = new HashSet<int>();
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                numbers.Add(arrayOfNumbers[index]);
            }
            return numbers.ToArray();
        }

        int[] LeaveTwoDuplicates(int[] arrayOfNumbers)
        {
            var numbers = new HashSet<int>();
            var numbersWithTwoDuplicates = new List<int>();
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                numbers.Add(arrayOfNumbers[index]);
            }

            for (int index = 0; index < numbers.Count; index++)
            {
                var actualValue = numbers.ElementAt(index);
                if (arrayOfNumbers.Where(element => element == actualValue).Count() >= 2)
                {
                    numbersWithTwoDuplicates.Add(actualValue);
                }
                numbersWithTwoDuplicates.Add(actualValue);
            }
            return numbersWithTwoDuplicates.ToArray();
        }

        int[] RemoveElement(int[] arrayOfNumbers, int elementToRemove)
        {
            return arrayOfNumbers
                .Where(element => element != elementToRemove)
                .ToArray();
        }

        int[] MoveZeros(int[] arrayOfNumbers)
        {
            var zeroCount = 0;
            var listOfElements = new List<int>();
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                var actualElement = arrayOfNumbers[index];
                if (actualElement == 0)
                {
                    zeroCount++;
                }
                else
                {
                    listOfElements.Add(actualElement);
                }
            }
            listOfElements
                .AddRange(Enumerable.Range(1, zeroCount)
                .Select(x => 0));
            return listOfElements.ToArray();
        }

        int[] GetProductofArrayExceptSelf(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
                throw new ArgumentNullException("inputArray needs to have elements");
            var outputArray = new List<int>();
            for (int index = 0; index < inputArray.Length; index++)
            {
                outputArray.Add(inputArray
                    .Where(element => element != inputArray[index])
                    .Aggregate((firstElement, secondElement) => firstElement * secondElement));
            }
            return outputArray.ToArray();
        }

        int[] GetMinimumSizeSubarraySum(int[] inputArray, int n)
        {
            var listOfSums = new List<int>();
            var listOfNumbers = new List<int>();
            var sum = 0;
            for (int subArraySize = 2; subArraySize <= inputArray.Length - 1; subArraySize++)
            {
                for (int index = 0; index <= inputArray.Length - 1; index++)
                {
                    sum += inputArray[index];
                    listOfNumbers.Add(inputArray[index]);
                    if (index % subArraySize == 1 && index != 0)
                    {
                        if (sum >= n)
                        {
                            listOfNumbers.ForEach(element => Console.Write(element + " "));
                            Console.WriteLine($"sum = {sum}");
                            return listOfNumbers.ToArray();
                        }
                        listOfSums.Add(sum);
                        sum = 0;
                        listOfNumbers.Clear();
                        continue;
                    }
                }
            }
            return null;
        }

        string[] GetSummaryRanges(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
                throw new ArgumentNullException("inputArray needs to have elements");

            var listOfAnswers = new List<string>();

            for (int index = 0; index < inputArray.Length; index++)
            {
                var firstString = string.Empty;
                bool found = false;
                for (int insideIndex = index; insideIndex < inputArray.Length; insideIndex++)
                {
                    if (insideIndex + 1 < inputArray.Length && (inputArray[insideIndex + 1] - inputArray[insideIndex] == 1))
                    {
                        if (!found)
                        {
                            firstString = $"{inputArray[insideIndex]}";
                        }
                        found = true;
                    }
                    else
                    {
                        if (found)
                        {
                            string endString = inputArray[insideIndex].ToString();
                            listOfAnswers.Add($"{firstString}->{endString}");
                            index = insideIndex;
                            break;
                        }
                        else
                        {
                            listOfAnswers.Add($"{inputArray[insideIndex]}");
                        }
                    }
                }
            }
            return listOfAnswers.ToArray();
        }

        string[] GetMissingRanges(int lower, int upper, int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
                throw new ArgumentNullException("InputArray needs to have elements");

            if (lower > upper && lower >= 0 && upper >= 0)
                throw new ArgumentException("Correct arguments");

            var negativeList = Enumerable.Range(lower, upper - lower + 1)
               .Where(element => !inputArray.Any(item => item == element));

            return GetSummaryRanges(negativeList.ToArray());
        }

        int[][] GetMergeIntervals(int[][] inputArray)
        {
            //given
            //var inputArray = new int[][] {
            //    new int[] { 1, 3 },
            //    new int[] { 2, 6 },
            //    new int[] { 8, 10 },
            //    new int[] { 15, 18 }
            //};
            //var expectedArray = new int[][] {
            //    new int[] { 1, 6 },
            //    new int[] { 8, 10 },
            //    new int[] { 15, 18 }
            //};

            for (var index = 1; index < inputArray.Length; index += 2)
            {

            }
            return inputArray;
        }

        public bool CheckIfStringIsPalindrome(string message)
        {
            if (string.IsNullOrEmpty(message))
                return false;
            var alphabeticMessageString = GetAlphabeticString(message);
            for (var index = 0; index < alphabeticMessageString.Length / 2; index++)
            {
                if (alphabeticMessageString[index] != alphabeticMessageString[alphabeticMessageString.Length - 1 - index])
                {
                    return false;
                }
            }
            return true;
        }

        private static string GetAlphabeticString(string message)
        {
            var alphabeticMessageArray = message.ToCharArray().Where(element => (element >= 'a' && element <= 'z') || (element >= 'A' && element <= 'Z'));
            string alphabeticMessageString = string.Join("", alphabeticMessageArray).ToLower();
            return alphabeticMessageString;
        }

        [Test]
        public void RemoveDuplicatesFromSortedArray_1()
        {
            //given
            var sortedArrayWithDuplicates = new int[] { 1, 3, 3, 6, 8, 8, 9 };
            var expectedSortedArrayWithoutDuplicates = new int[] { 1, 3, 6, 8, 9 };
            //when
            var sortedArrayWithoutDuplicatesCalculated = RemoveDuplicates(sortedArrayWithDuplicates);
            //then
            Assert.AreEqual(expectedSortedArrayWithoutDuplicates, sortedArrayWithoutDuplicatesCalculated);
        }

        [Test]
        public void RemoveDuplicatesFromSortedArray_2()
        {
            //given
            var sortedArrayWithDuplicates = new int[] { 1, 3, 3, 3, 6, 8, 8, 9, 9, 9 };
            var expectedSortedArrayWithTwoDuplicates = new int[] { 1, 3, 3, 6, 8, 8, 9, 9 };
            //when
            var sortedArrayWithTwoDuplicatesCalculated = LeaveTwoDuplicates(sortedArrayWithDuplicates);
            //then
            Assert.AreEqual(expectedSortedArrayWithTwoDuplicates, sortedArrayWithTwoDuplicatesCalculated);
        }

        [Test]
        public void RemoveElement_3()
        {
            //given
            var arrayWithElements = new int[] { 1, 5, 3, 3, 6, 1, 8, 3, 9, 7 };
            var expectedArrayWithElements = new int[] { 1, 5, 6, 1, 8, 9, 7 };
            var elementToRemove = 3;
            //when
            var arrayWithRemoveElement = RemoveElement(arrayWithElements, elementToRemove);
            //then
            Assert.AreEqual(expectedArrayWithElements, arrayWithRemoveElement);
        }

        [Test]
        public void MoveZeros_4()
        {
            //given
            var arrayWithZeros = new int[] { 1, 0, 5, 0, 0, 3 };
            var expectedArrayWithZerosInTheEnd = new int[] { 1, 5, 3, 0, 0, 0 };
            //when
            var arrayWithRemoveElement = MoveZeros(arrayWithZeros);
            //then
            Assert.AreEqual(expectedArrayWithZerosInTheEnd, arrayWithRemoveElement);
        }

        [Test]
        public void ProductofArrayExceptSelf_7()
        {
            //given
            var inputArray = new int[] { 1, 2, 3, 4 };
            var expectedArray = new int[] { 24, 12, 8, 6 };
            //when
            var outputArray = GetProductofArrayExceptSelf(inputArray);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void MinimumSizeSubarraySum_8()
        {
            //given
            var inputArray = new int[] { 2, 3, 1, 2, 4, 3 };
            int n = 7;
            var expectedArray = new int[] { 4, 3 };
            //when
            var outputArray = GetMinimumSizeSubarraySum(inputArray, n);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void SummaryRanges_9()
        {
            //given
            var inputArray = new int[] { 0, 1, 2, 4, 5, 7 };
            var expectedArray = new string[] { "0->2", "4->5", "7" };
            //when
            var outputArray = GetSummaryRanges(inputArray);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void MissingRanges_10()
        {
            //given
            var inputArray = new int[] { 0, 1, 3, 50, 75 };
            int lower = 0;
            int upper = 99;
            var expectedArray = new string[] { "2", "4->49", "51->74", "76->99" };
            //when
            var outputArray = GetMissingRanges(lower, upper, inputArray);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void MergeIntervals_11()
        {
            //given
            var inputArray = new int[][] {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            var expectedArray = new int[][] {
                new int[] { 1, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            //when
            var outputArray = GetMergeIntervals(inputArray);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void ValidPalindrome_22()
        {
            //given
            var inputString = "Red rum, sir, is murder";
            //when
            var isPalindrome = CheckIfStringIsPalindrome(inputString);
            //then
            Assert.AreEqual(true, isPalindrome);
        }
    }
}