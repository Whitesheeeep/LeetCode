using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode654_ConstructMaximumBinaryTree_middle
    {
        #region 错误示例
        // 仍然错误：递归的过程中无法知道最大值的索引，不能直接用 sortedNums 作为最大值依据
        public TreeNode ConstructMaximumBinaryTree_Error(int[] nums) 
        {
            if(nums.Length == 0) return null;
            if(nums.Length == 1) return new TreeNode(nums[0]);

            int[] sortedNums = nums;
            int[] indexOfMax = new int[nums.Length];
            // 插入排序同时得到最大值的索引 但是 插排会导致前面的 indexArray 发生变化导致 bug
            // 解决方案：移动数组的同时，也要移动 indexArray
            for(int i = 1; i < sortedNums.Length; i++)
            {
                int temp = sortedNums[i];

                int j = i;
                for(; j > 0 && sortedNums[j - 1] > temp; j--)
                {
                    sortedNums[j] = sortedNums[j - 1];
                    indexOfMax[j] = indexOfMax[j - 1];
                }
                sortedNums[j] = temp;
                indexOfMax[j] = i;
            }
            return BuildMaxTree(in nums, in sortedNums ,in indexOfMax, 0, nums.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums">构造所使用的数组</param>
        /// <param name="start">数组中的起始索引</param>
        /// <param name="end">数组中的结束索引</param>
        /// <returns>头结点</returns>
        public TreeNode BuildMaxTree(in int[] nums, in int[] sortedNums, in int[] indexArray, int start, int end)
        {
            if(start > end) return null;
            if(start == end) return new TreeNode(nums[start]);

            TreeNode root = new TreeNode(sortedNums[end]);
            root.left = BuildMaxTree(in nums, in sortedNums, in indexArray, start, indexArray[end] - 1);
            root.right = BuildMaxTree(in nums, in sortedNums, in indexArray, indexArray[end] + 1, end - 1);
            return root;
        }
        #endregion 错误示例

        public TreeNode ConstructMaximumBinaryTree(int[] nums) 
        {
            if (nums.Length == 0) return null;
            int rootValue = nums.Max();
            TreeNode root = new TreeNode(rootValue);
            int rootIndex = Array.IndexOf(nums, rootValue);

            root.left = ConstructMaximumBinaryTree(nums.Take(rootIndex).ToArray());
            root.right = ConstructMaximumBinaryTree(nums.Skip(rootIndex + 1).ToArray());
            return root;
        }
    }
}
