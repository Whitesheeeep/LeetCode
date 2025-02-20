using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree.层序遍历附加题目
{
    public class LeetCode_IsBalanced_Easy
    {
        public bool IsBalanced(TreeNode root)
        {
            if(root is null ) return true;
            
            int rootHeight = GetHeight(root);
            if(rootHeight == -1) return false;
            return true;

        }

        // 后序遍历
        public int GetHeight(TreeNode root)
        {
            if(root is null) return 0;
            int left = GetHeight(root.left);
            int right = GetHeight(root.right);
            // 如果左右子树的高度差大于1，或者左右子树有一个不平衡，返回-1
            if(left == -1 || right == -1 || Math.Abs(left - right) > 1) return -1;
            return Math.Max(left, right) + 1;
        }
    }
}
