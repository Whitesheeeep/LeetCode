using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode98_IsValidBST_middle
    {
        public bool IsValidBST(TreeNode root)
        {
            // 极端情况
            if (root is null) return true;
            if( !FakeBST(root)) return false;
            
            return RMostLAndLRmostL(root);

        }

        private bool FakeBST(TreeNode root)
        {
            // 前序
            if (root.left is not null && root.left.val >= root.val) return false;
            if (root.right is not null && root.right.val <= root.val) return false;

            return IsValidBST(root.left) && IsValidBST(root.right);
        }

        bool RMostLAndLRmostL(TreeNode root)
        {
            if(root is null) return true;
            TreeNode deepestRL = root.right;
            while(deepestRL.left is not null)
            {
                deepestRL = deepestRL.left;
            }
            if(deepestRL.val <= root.val) return false;

            TreeNode deepestLR = root.left;
            while(deepestLR.right is not null)
            {
                deepestLR = deepestLR.right;
            }
            if(deepestLR.val >= root.val) return false;


            return RMostLAndLRmostL(root.left) && RMostLAndLRmostL(root.right);
        }
    }
}
