using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCodee538_ConvertBST_middle
    {
        TreeNode pre = null;
        public TreeNode ConvertBST(TreeNode root)
        {
            if(root is null) return null;
            // 反中序遍历
            ConvertBST(root.right);
            if(pre is not null) root.val += pre.val;
            pre = root;
            ConvertBST(root.left);
            return root;
        }

        public TreeNode ConvertBST_Iteration(TreeNode root)
        {
            if(root is null) return null;
            
            int pre = 0;
            TreeNode cur = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(cur);
            
            while(stack.Count > 0 || cur is not null)
            {
                while(cur is not null)
                {
                    stack.Push(cur);
                    cur = cur.right;
                }

                cur = stack.Pop();
                cur.val += pre;
                pre = cur.val;
                cur = cur.left;
            }
            return root;
        }
    }
}
