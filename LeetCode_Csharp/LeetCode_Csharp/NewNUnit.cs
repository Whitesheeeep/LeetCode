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
using LeetCode_Csharp.Code.String;
using System.Text;
using System.Diagnostics;
using LeetCode_Csharp.Code.BinaryTree;
using LeetCode_Csharp.Code.BackTracking;

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
            LeetCode40_CombinationSum2_middle test = new();
            int[] testArray = [1,2,5];
            var res = test.CombinationSum2(testArray, 8);
            var res2 = new int[][]{
                [1,2,5]
            };
            Assert.AreEqual(res, res2);
        }
    }
}
