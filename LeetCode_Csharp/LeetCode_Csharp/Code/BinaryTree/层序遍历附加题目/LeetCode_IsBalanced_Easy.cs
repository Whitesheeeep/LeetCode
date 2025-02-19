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

            // 判断左右子树的高度差是否大于1
            // 计算左右子树的高度
            int left = GetHeight(root.left);

            // 判断左右子树是否是平衡二叉树

        }

        private int GetHeight(TreeNode<int> left)
        {
            
        }
    }
}
