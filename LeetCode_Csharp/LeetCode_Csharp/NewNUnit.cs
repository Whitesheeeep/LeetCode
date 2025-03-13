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
            LeetCode_Csharp.Code.BinaryTree.LeetCode236_LowestCommonAncestor_middle test = new LeetCode_Csharp.Code.BinaryTree.LeetCode236_LowestCommonAncestor_middle();
            TreeNode root = new TreeNode(3);
            TreeNode p = new TreeNode(5);
            TreeNode q = new TreeNode(1);
            root.left = p;
            root.right = q;
            p.left = new TreeNode(6);
            p.right = new TreeNode(2);
            p.right.left = new TreeNode(7);
            p.right.right = new TreeNode(4);
            q.left = new TreeNode(0);
            q.right = new TreeNode(8);
            TreeNode result = test.LowestCommonAncestor(root, p, p.right.right);
            Assert.AreEqual(5, result.val);


        }
    }
}
