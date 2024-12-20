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
            LeetCode844 leetCode884 = new LeetCode844();
            Assert.AreEqual(true, leetCode884.BackSpaceCompare("ab#c", "ad#c"));
            
        }
    }
}