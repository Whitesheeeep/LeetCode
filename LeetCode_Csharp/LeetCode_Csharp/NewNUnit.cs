using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode_Csharp.DoublePointer;
using NUnit.Framework;
using NUnit;

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
            int[] ints = { 0,1};
            LeetCode283 leetCode283 = new LeetCode283();
            leetCode283.MoveZeros(ints);
            Assert.AreEqual(new int[]{1,0}, ints);
            
        }
    }
}