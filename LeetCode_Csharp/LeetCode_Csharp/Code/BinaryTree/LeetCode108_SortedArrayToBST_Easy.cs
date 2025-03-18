using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode108_SortedArrayToBST_Easy
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if(nums.Length == 0) return null;
            return BuildTree(ref nums,0,nums.Length - 1);

        }

        private TreeNode BuildTree(ref int[] ints, int left, int right)
        {
            if(right < left) return null;

            int middleIndex = (right - left) / 2 + left;
            TreeNode root = new TreeNode(ints[middleIndex]);
            root.left = BuildTree(ref ints, left, middleIndex - 1);
            root.right = BuildTree(ref ints, middleIndex + 1 ,right);
            return root;
        }

        // 迭代法可以看代码随想录，用三个队列存储左右边界和树节点

    }
}
