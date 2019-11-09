using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterview
{
    public class Tests
    {
        int[] RemoveDuplicates(int[] arrayOfNumbers)
        {
            var numbers = new HashSet<int>();
            for(int index = 0; index < arrayOfNumbers.Length; index++)
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
            for(int index = 0; index < arrayOfNumbers.Length; index++)
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

        int GetTrappingRainWater(int[] elevationMap)
        {
            if (elevationMap == null || elevationMap.Length == 0)
                return 0;
            int waterToDrop = 0;
            int level = 0;
            int left = 0;
            int right = elevationMap.Length - 1;
            while(left < right)
            {
                int lower = elevationMap[elevationMap[left] < elevationMap[right] ? left++ : right--];
                level = Math.Max(lower, level);
                waterToDrop += level - lower;
                Console.WriteLine($"left{left} right{right} lower {lower} level {level} waterToDrop {waterToDrop}");
            }
            return waterToDrop;
        }

        [Test]
        public void RemoveDuplicatesFromSortedArray_1()
        {
            var sortedArrayWithDuplicates = new int[] { 1, 3, 3, 6, 8, 8, 9 };
            var expectedSortedArrayWithoutDuplicates = new int[] { 1, 3, 6, 8, 9 };

            var sortedArrayWithoutDuplicatesCalculated = RemoveDuplicates(sortedArrayWithDuplicates);

            Assert.AreEqual(expectedSortedArrayWithoutDuplicates, sortedArrayWithoutDuplicatesCalculated);
        }

        [Test]
        public void RemoveDuplicatesFromSortedArray_2()
        {
            var sortedArrayWithDuplicates = new int[] { 1, 3, 3, 3, 6, 8, 8, 9, 9, 9 };
            var expectedSortedArrayWithTwoDuplicates = new int[] { 1, 3, 3, 6, 8, 8, 9, 9 };

            var sortedArrayWithTwoDuplicatesCalculated = LeaveTwoDuplicates(sortedArrayWithDuplicates);

            Assert.AreEqual(expectedSortedArrayWithTwoDuplicates, sortedArrayWithTwoDuplicatesCalculated);
        }

        [Test]
        public void RemoveElement_3()
        {
            var arrayWithElements = new int[] { 1, 5, 3, 3, 6, 1, 8, 3, 9, 7 };
            var expectedArrayWithElements = new int[] { 1, 5, 6, 1, 8, 9, 7 };
            var elementToRemove = 3;

            var arrayWithRemoveElement = RemoveElement(arrayWithElements, elementToRemove);

            Assert.AreEqual(expectedArrayWithElements, arrayWithRemoveElement);
        }

        [Test]
        public void MoveZeros_4()
        {
            var arrayWithZeros = new int[] { 1, 0, 5, 0, 0, 3};
            var expectedArrayWithZerosInTheEnd = new int[] { 1, 5, 3, 0, 0, 0 };

            var arrayWithRemoveElement = MoveZeros(arrayWithZeros);

            Assert.AreEqual(expectedArrayWithZerosInTheEnd, arrayWithRemoveElement);
        }

        [Test]
        public void TrappingRainWater_6()
        {
            var elevationMap = new int[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var expectedValue = 6;

            var rainWaterValue = GetTrappingRainWater(elevationMap);

            Assert.AreEqual(expectedValue, rainWaterValue);
        }
    }
}