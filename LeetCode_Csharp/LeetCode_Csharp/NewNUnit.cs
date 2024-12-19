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
            LeetCode_Csharp.Solution solution = new LeetCode_Csharp.Solution();

            Assert.AreEqual(true, solution.IsPerfectSquqre_2(16));
            Assert.AreEqual(true, solution.IsPerfectSquqre_2(25));
            Assert.AreEqual(true, solution.IsPerfectSquqre_2(64));
            Assert.AreEqual(false, solution.IsPerfectSquqre_2(195));
            
        }
    }
}