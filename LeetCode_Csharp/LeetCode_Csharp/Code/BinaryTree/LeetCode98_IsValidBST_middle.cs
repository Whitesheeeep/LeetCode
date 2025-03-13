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
            // if( !FakeBST(root)) return false;
            // 之后发现后面的 RMostLAndLRmostL 会包含 FakeBST 的功能，所以不需要再调用 FakeBST
            
            return RMostLAndLRmostL(root);

        }

        private bool FakeBST(TreeNode root)
        {
            // 前序
            if (root is null) return true;
            if (root.left is not null && root.left.val >= root.val) return false;
            if (root.right is not null && root.right.val <= root.val) return false;


            return FakeBST(root.left) && FakeBST(root.right);
        }


        #region 前序遍历
        bool RMostLAndLRmostL(TreeNode root)
        {
            if(root is null) return true;
            TreeNode deepestRL = root.right;
            while(deepestRL is not null)
            {
                if(deepestRL.val <= root.val) return false;
                deepestRL = deepestRL.left;
            }
            

            TreeNode deepestLR = root.left;
            while(deepestLR is not null)
            {
                if(deepestLR.val >= root.val) return false;
                deepestLR = deepestLR.right;
            }
            


            return RMostLAndLRmostL(root.left) && RMostLAndLRmostL(root.right);
        }
        #endregion 前序遍历


        TreeNode pre = null;
        #region 中序遍历
        public bool IsValidBST2(TreeNode root)
        {
            if(root is null) return true;
            bool left = IsValidBST2(root.left);
            if(pre is not null && pre.val >= root.val) return false;
            pre = root;
            bool right = IsValidBST2(root.right);
            return left && right;
        }
        // 对应的迭代写法
        public bool IsValidBST2_Iteration(TreeNode root)
        {
            if(root is null) return true;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode pre = null;
            while(stack.Count > 0 || root is not null)
            {
                while(root is not null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if(pre is not null && pre.val >= root.val) return false;
                pre = root;
                root = root.right;
            }
            return true;
        }

        long preValue = long.MinValue;
        public bool IsValidBST3(TreeNode root)
        {
            if(root is null) return true;
            if(!IsValidBST3(root.left)) return false;
            if(root.val <= preValue) return false;
            preValue = root.val;
            return IsValidBST3(root.right);
        }
        #endregion 中序遍历


    }
}
