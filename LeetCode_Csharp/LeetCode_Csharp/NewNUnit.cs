using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode_Csharp.DoublePointer;
using NUnit.Framework;
using NUnit;
using LeetCode_Csharp.MinLengthOfChildList;
using LeetCode_Csharp.GenerateMatrix;

namespace LeetCode_Csharp
{
    public class NewNUnit
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            LeetCode59_GenerateMatrix_middle leetCode59 = new LeetCode59_GenerateMatrix_middle();
            int[][] res = leetCode59.GenerateMatrix(3);
            int[][] expected = new int[3][];
            expected[0] = new int[] {1, 2, 3};
            expected[1] = new int[] {8, 9, 4};
            expected[2] = new int[] {7, 6, 5};
            Assert.AreEqual(expected, res);
            
            
        }
    }
}
