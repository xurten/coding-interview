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

        [Test]
        public void RemoveDuplicatesFromSortedArray_1()
        {
            var sortedArrayWithDuplicates = new int[] { 1, 3, 3, 6, 8, 8, 9 };
            var expectedSortedArrayWithoutDuplicates = new int[] { 1, 3, 6, 8, 9 };

            var sortedArrayWithoutDuplicatesCalculated = RemoveDuplicates(sortedArrayWithDuplicates);

            Assert.AreEqual(expectedSortedArrayWithoutDuplicates, sortedArrayWithoutDuplicatesCalculated);
        }
    }
}