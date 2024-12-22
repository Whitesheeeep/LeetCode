using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode_Csharp.DoublePointer;
using NUnit.Framework;
using NUnit;
using LeetCode_Csharp.MinLengthOfChildList;

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
            LeetCode904 leetCode904 = new LeetCode904();
            int[] fruits = {1, 2, 1};
            Assert.AreEqual(3, leetCode904.TotalFruit(fruits));
            Assert.AreEqual(3, leetCode904.TotalFruit(new int[] {0, 1, 2, 2}));
            Assert.AreEqual(4, leetCode904.TotalFruit(new int[] {1, 2, 3, 2, 2}));
            Assert.AreEqual(5, leetCode904.TotalFruit(new int[] {3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4}));
            
        }
    }
}