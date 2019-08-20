using NUnit.Framework;
using TaskSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSort.Tests
{
    [TestFixture()]
    public class JaggedSortTests
    {
        JaggedSort JaggedSort = new JaggedSort(new int[][]{
            new int[] { 1, 2, 3, 4, 5 },
            new int[]{ 7, 6, 26, 134 },
            new int[]{ -1, -26, 2, -3, 4, 5, 0 },
            new int[]{ 1, 2, 3, 4, 5, 61, 345, 132 }
            });

        [TestCase(true )]
        public void BubbleSortWithSumTest_Decrement(bool decr)
        {
            int[][] actual = JaggedSort.BubbleSortWithSum(decr);
            int[][] expected = {new int [] { 1, 2, 3, 4, 5, 61, 345, 132},
                new int []{ 7, 6, 26, 134},
                new int []{  1, 2, 3, 4, 5},
                new int []{ -1, -26, 2, -3, 4, 5, 0 } };           
            Assert.AreEqual(expected, actual);
        }


        [TestCase(true)]
        public void BubbleSortWithMaxTest_Decrement(bool decr)
        {
            int[][] actual = JaggedSort.BubbleSortWithMax(decr);
            int[][] expected = {new int [] { 1, 2, 3, 4, 5, 61, 345, 132},
                new int []{ 7, 6, 26, 134},
                new int []{ -1, -26, 2, -3, 4, 5, 0},
                new int []{ 1, 2, 3, 4, 5} };
            Assert.AreEqual(expected, actual);
        }


        [TestCase(true)]
        public void BubbleSortWithMinTest_Decrement(bool decr)
        {
            int[][] actual = JaggedSort.BubbleSortWithSum(decr);
            int[][] expected = {new int [] { 7, 6, 26, 134},
                new int []{ 1, 2, 3, 4, 5, 61, 345, 132},
                new int []{1, 2, 3, 4, 5},
                new int []{  -1, -26, 2, -3, 4, 5, 0} };
            Assert.AreEqual(expected, actual);
        }
    }
}