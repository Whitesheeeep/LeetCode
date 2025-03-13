using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode530_GetMinimumDifference_Easy
    {
        TreeNode pre = null;
        int min = int.MaxValue;
        public int GetMinimumDifference(TreeNode root)
        {
            // 易错点：误以为最小绝对差值就是根于左右孩子的绝对值差，其实根与左孩子的右孩子的差值也可能是最小的，或者说与右孩子的左孩子的差值也可能是最小的
            // if(root is null) return int.MaxValue;
            // int min = int.MaxValue;

            // if(root.left is null && root.right is null) return min;

            // if(root.left is not null) min = min > Math.Abs(root.val - root.left.val) ? Math.Abs(root.val - root.left.val) : min;
            // if(root.right is not null) min = min > Math.Abs(root.val - root.right.val) ? Math.Abs(root.val - root.right.val) : min;

            // int left = GetMinimumDifference(root.left);
            // int right = GetMinimumDifference(root.right);   

            // min = min > left ? left : min;
            // min = min > right ? right : min;
            // return min;
            if (root is null) return min;
            int left = GetMinimumDifference(root.left);

            if (pre is not null) min = min > Math.Abs(root.val - pre.val) ? Math.Abs(root.val - pre.val) : min;
            pre = root;
            int right = GetMinimumDifference(root.right);
            return Math.Min(min, Math.Min(left, right));
        }
    }
}
