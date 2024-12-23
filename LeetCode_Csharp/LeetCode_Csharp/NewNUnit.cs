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
            LeetCode76_MinWindow2 leetCode76_MinWindow2 = new LeetCode76_MinWindow2();
            string s = "ADOBECODEBANC";
            string t = "ABC";
            string result = leetCode76_MinWindow2.MinWindow(s, t);
            Assert.AreEqual("BANC", result);
            
            
            
        }
    }
}