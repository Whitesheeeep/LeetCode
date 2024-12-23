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
            LeetCode54_SpiralOrder_middle spiralOrder = new LeetCode54_SpiralOrder_middle();
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3 };
            matrix[1] = new int[] { 4, 5, 6 };
            matrix[2] = new int[] { 7, 8, 9 };
            var res = spiralOrder.SpiralOrder(matrix);
            Assert.AreEqual(res, new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 });
            
            
            
        }
    }
}
