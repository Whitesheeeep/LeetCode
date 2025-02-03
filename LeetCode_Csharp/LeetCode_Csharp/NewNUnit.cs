using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode_Csharp.DoublePointer;
using NUnit.Framework;
using NUnit;
using LeetCode_Csharp.MinLengthOfChildList;
using LeetCode_Csharp.GenerateMatrix;
using LeetCode_Csharp.LinkedList;
using System.Diagnostics.CodeAnalysis;
using static LeetCode_Csharp.StackAndQueue.LeetCode232_QueueBasedOnStack_Easy;
using LeetCode_Csharp.Code.StackAndQueue;
using LeetCode_Csharp.Code.HashTable;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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
            LeetCode18_FourSum_middle leetCode18_FourSum_Middle = new();
            int[] nums = [1000000000,1000000000,1000000000,1000000000];
            int target = -294967296;
            var res = leetCode18_FourSum_Middle.FourSum(nums, target);
            int[][] expected =[];
            
            Assert.AreEqual(expected, res);

        }
    }
}
