using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterview
{
    public class Tests
    {
        private static int[] RemoveDuplicates(IReadOnlyList<int> arrayOfNumbers)
        {
            var numbers = new HashSet<int>();
            foreach (var element in arrayOfNumbers)
            {
                numbers.Add(element);
            }
            return numbers.ToArray();
        }

        private static int[] LeaveTwoDuplicates(IReadOnlyCollection<int> arrayOfNumbers)
        {
            var numbers = new HashSet<int>();
            var numbersWithTwoDuplicates = new List<int>();
            foreach (var element in arrayOfNumbers)
            {
                numbers.Add(element);
            }

            for (var index = 0; index < numbers.Count; index++)
            {
                var actualValue = numbers.ElementAt(index);
                if (arrayOfNumbers.Count(element => element == actualValue) >= 2)
                {
                    numbersWithTwoDuplicates.Add(actualValue);
                }
                numbersWithTwoDuplicates.Add(actualValue);
            }
            return numbersWithTwoDuplicates.ToArray();
        }

        private static int[] RemoveElement(IReadOnlyCollection<int> arrayOfNumbers, int elementToRemove)
        {
            return arrayOfNumbers
                .Where(element => element != elementToRemove)
                .ToArray();
        }

        private static int[] MoveZeros(IReadOnlyList<int> arrayOfNumbers)
        {
            var zeroCount = 0;
            var listOfElements = new List<int>();
            foreach (var actualElement in arrayOfNumbers)
            {
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

        private static int[] GetProductofArrayExceptSelf(IReadOnlyList<int> inputArray)
        {
            if (inputArray == null || inputArray.Count == 0)
                throw new ArgumentNullException(nameof(inputArray), "inputArray needs to have elements");

            return inputArray
                .Select(arrayElement => inputArray.Where(element => element != arrayElement)
                .Aggregate((firstElement, secondElement) => firstElement * secondElement))
                .ToArray();
        }

        private static int[] GetMinimumSizeSubarraySum(IReadOnlyList<int> inputArray, int n)
        {
            var listOfSums = new List<int>();
            var listOfNumbers = new List<int>();
            var sum = 0;
            for (var subArraySize = 2; subArraySize <= inputArray.Count - 1; subArraySize++)
            {
                for (var index = 0; index <= inputArray.Count - 1; index++)
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
                    }
                }
            }
            return null;
        }

        private static string[] GetSummaryRanges(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
                throw new ArgumentNullException(nameof(inputArray), "inputArray needs to have elements");

            var listOfAnswers = new List<string>();

            for (var index = 0; index < inputArray.Length; index++)
            {
                var firstString = string.Empty;
                var isFounded = false;
                for (var insideIndex = index; insideIndex < inputArray.Length; insideIndex++)
                {
                    if (insideIndex + 1 < inputArray.Length && (inputArray[insideIndex + 1] - inputArray[insideIndex] == 1))
                    {
                        if (!isFounded)
                        {
                            firstString = $"{inputArray[insideIndex]}";
                        }
                        isFounded = true;
                    }
                    else
                    {
                        if (isFounded)
                        {
                            var endString = inputArray[insideIndex].ToString();
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

        private static string[] GetMissingRanges(int lower, int upper, IReadOnlyCollection<int> inputArray)
        {
            if (inputArray == null || inputArray.Count == 0)
                throw new ArgumentNullException(nameof(inputArray), "InputArray needs to have elements");

            if (lower > upper && lower >= 0 && upper >= 0)
                throw new ArgumentException("Correct arguments");

            var negativeList = Enumerable.Range(lower, upper - lower + 1)
               .Where(element => inputArray.All(item => item != element));

            return GetSummaryRanges(negativeList.ToArray());
        }

        private static int[][] GetMergeIntervals()
        {
            return null;
        }

        private static bool CheckIfStringIsPalindrome(string message)
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
            var alphabeticMessageString = string.Join("", alphabeticMessageArray).ToLower();
            return alphabeticMessageString;
        }

        private static bool CheckIfArrayContainsDuplicatedElements(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
                throw new ArgumentNullException(nameof(inputArray), "inputArray needs to have elements");

            var hashSet = new HashSet<int>();
            foreach (var element in inputArray)
            {
                if (hashSet.Contains(element))
                {
                    return true;
                }
                hashSet.Add(element);
            }
            return false;
        }

        private static bool CheckIfUgly(int number)
        {
            if(number < 0)
                throw new ArgumentException(nameof(number), "number should be positive");

            switch (number)
            {
                case 0:
                    return false;
                case 1:
                    return true;
            }

            while (number >= 0)
            {
                switch (number)
                {
                    case 0:
                        return false;
                    case 1:
                        return true;
                }

                if (number % 2 == 0)
                {
                    number /= 2;
                    continue;
                }

                if (number % 3 == 0)
                {
                    number /= 3;
                    continue;
                }

                if (number % 5 == 0)
                {
                    number /= 5;
                    continue;
                }
                return false;

            }
            return false;
        }

        public int[] GenerateUglyNumbersArray(int count)
        {
            var list = new HashSet<int> {1};
            for (var index = 1; index <= count; index++)
            {
                list.Add(index * 2);
                list.Add(index * 3);
                list.Add(index * 5);
            }

            var newList = list.ToList();
            newList.Sort();
            return newList.Take(count).ToArray();
        }

       [Test]
        public void RemoveDuplicatesFromSortedArray_1()
        {
            //given
            var sortedArrayWithDuplicates = new [] { 1, 3, 3, 6, 8, 8, 9 };
            var expectedSortedArrayWithoutDuplicates = new [] { 1, 3, 6, 8, 9 };
            //when
            var sortedArrayWithoutDuplicatesCalculated = RemoveDuplicates(sortedArrayWithDuplicates);
            //then
            Assert.AreEqual(expectedSortedArrayWithoutDuplicates, sortedArrayWithoutDuplicatesCalculated);
        }

        [Test]
        public void RemoveDuplicatesFromSortedArray_2()
        {
            //given
            var sortedArrayWithDuplicates = new [] { 1, 3, 3, 3, 6, 8, 8, 9, 9, 9 };
            var expectedSortedArrayWithTwoDuplicates = new [] { 1, 3, 3, 6, 8, 8, 9, 9 };
            //when
            var sortedArrayWithTwoDuplicatesCalculated = LeaveTwoDuplicates(sortedArrayWithDuplicates);
            //then
            Assert.AreEqual(expectedSortedArrayWithTwoDuplicates, sortedArrayWithTwoDuplicatesCalculated);
        }

        [Test]
        public void RemoveElement_3()
        {
            //given
            var arrayWithElements = new [] { 1, 5, 3, 3, 6, 1, 8, 3, 9, 7 };
            var expectedArrayWithElements = new [] { 1, 5, 6, 1, 8, 9, 7 };
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
            var arrayWithZeros = new [] { 1, 0, 5, 0, 0, 3 };
            var expectedArrayWithZerosInTheEnd = new [] { 1, 5, 3, 0, 0, 0 };
            //when
            var arrayWithRemoveElement = MoveZeros(arrayWithZeros);
            //then
            Assert.AreEqual(expectedArrayWithZerosInTheEnd, arrayWithRemoveElement);
        }

        [Test]
        public void ProductofArrayExceptSelf_7()
        {
            //given
            var inputArray = new [] { 1, 2, 3, 4 };
            var expectedArray = new [] { 24, 12, 8, 6 };
            //when
            var outputArray = GetProductofArrayExceptSelf(inputArray);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void MinimumSizeSubarraySum_8()
        {
            //given
            var inputArray = new [] { 2, 3, 1, 2, 4, 3 };
            int n = 7;
            var expectedArray = new [] { 4, 3 };
            //when
            var outputArray = GetMinimumSizeSubarraySum(inputArray, n);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void SummaryRanges_9()
        {
            //given
            var inputArray = new [] { 0, 1, 2, 4, 5, 7 };
            var expectedArray = new [] { "0->2", "4->5", "7" };
            //when
            var outputArray = GetSummaryRanges(inputArray);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void MissingRanges_10()
        {
            //given
            var inputArray = new [] { 0, 1, 3, 50, 75 };
            int lower = 0;
            int upper = 99;
            var expectedArray = new [] { "2", "4->49", "51->74", "76->99" };
            //when
            var outputArray = GetMissingRanges(lower, upper, inputArray);
            //then
            Assert.AreEqual(expectedArray, outputArray);
        }

        [Test]
        public void MergeIntervals_11()
        {
            //given
            var expectedArray = new[]
            {
                new [] { 1, 6 },
                new [] { 8, 10 },
                new [] { 15, 18 }
            };
            //when
            var outputArray = GetMergeIntervals();
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

        [Test]
        [TestCase(new[] { 0, 1, 2, 4, 4, 5, 7 }, true)]
        [TestCase(new[] { 0, 1, 2, 4, 5, 7 }, false)]
        public void ContainsDuplicates_82(int []inputArray, bool isDuplicateElement)
        {
            //given
            //when
            var containsDuplicateStatus = CheckIfArrayContainsDuplicatedElements(inputArray);
            //then
            Assert.AreEqual(isDuplicateElement, containsDuplicateStatus);
        }

        [Test]
        [TestCase(8, true)]
        [TestCase(7, false)]
        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(10, true)]
        [TestCase(13, false)]
        public void CheckUglyNumbers_99(int number, bool isUgly)
        {
            //given
            //when
            var uglyStatus = CheckIfUgly(number);
            //then
            Assert.AreEqual(isUgly, uglyStatus);
        }

        [Test]
        [TestCase(10, new []{ 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 })]
        public void CheckUglyNumbers2_100(int numberOfUglyNumbers, int[] arrayWithUglyNumbers)
        {
            //given
            //when
            var arrayWithUglyNumbersGenerated = GenerateUglyNumbersArray(numberOfUglyNumbers);
            //then
            Assert.AreEqual(arrayWithUglyNumbers, arrayWithUglyNumbersGenerated);
        }
    }
}