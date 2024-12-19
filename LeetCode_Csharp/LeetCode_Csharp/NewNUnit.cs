using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

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
            Solution s = new Solution();
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            LeetCode69 leetCode69 = new LeetCode69();
            
            Assert.AreEqual(46340, leetCode69.MySqrt(2147483647));
        }
    }
}