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
            IList<IList<string>> tickets = [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]];
            LeetCode332_FindItinerary_tough test = new();
            var item = test.FindItinerary(tickets);
            IList<string> res = ["JFK","ATL","JFK","SFO","ATL","SFO"];
            System.Console.WriteLine(test.CompareStringList(["JFK","ATL","SFO","ATL","JFK","SFO"],["JFK","ATL","JFK","SFO","ATL","SFO"])); 

            
        }
    }
}


