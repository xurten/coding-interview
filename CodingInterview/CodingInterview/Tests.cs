using NUnit.Framework;
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
            return arrayOfNumbers.Where(element => element != elementToRemove)
                .ToArray();
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
    }
}