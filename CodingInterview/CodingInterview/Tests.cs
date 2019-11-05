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
    }
}