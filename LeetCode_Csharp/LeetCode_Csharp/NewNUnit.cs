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
            int[] nums = new int[] { 3, 2, 1, 6, 0, 5 };
            foreach(var item in nums)
            {
                Console.Write(item + " ");
            }
            System.Console.WriteLine();
            int[] indexOfMax = new int[nums.Length];
            // 插入排序同时得到最大值的索引 但是 插排会导致前面的 indexArray 发生变化导致 bug
            // 解决方案：移动数组的同时，也要移动 indexArray
            for(int i = 1; i < nums.Length; i++)
            {
                int temp = nums[i];

                int j = i;
                for(; j > 0 && nums[j - 1] > temp; j--)
                {
                    nums[j] = nums[j - 1];
                    indexOfMax[j] = indexOfMax[j - 1];
                }
                nums[j] = temp;
                indexOfMax[j] = i;
            }
            foreach(var item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach(var item in indexOfMax)
            {
                Console.Write(item + " ");
            }

        }
    }
}
