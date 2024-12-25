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
            MyQueue myQueue= new MyQueue();
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Peek();
            myQueue.Pop();
            myQueue.Empty();
            
            
        }
    }
}
