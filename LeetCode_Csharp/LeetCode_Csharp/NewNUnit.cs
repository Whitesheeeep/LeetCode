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
            List<IList<int>> res = new();
            List<int> path = [];
            path.Add(0);
            path.Add(1);
            res.Add(path);
            path.RemoveAt(1);
            foreach(var item in res)
            {
                foreach(int i in item)
                    System.Console.WriteLine(i);
            }


        }
    }
}
