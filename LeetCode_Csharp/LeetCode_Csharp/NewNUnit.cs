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
            ReverseLinkedList reverseLinkedList = new ReverseLinkedList();
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            ListNode result = reverseLinkedList.ReverseList(head);
            
            
        }
    }
}
