using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode701_InsertIntoBST_middle
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if(root is null) return new TreeNode(val);

            if(root.val > val) root.left = InsertIntoBST(root.left, val);
            else root.right = InsertIntoBST(root.right, val);

            return root;
        }

        // 迭代的方式插入节点
        public TreeNode InsertIntoBST_Iteration(TreeNode root, int val)
        {
            if(root is null) return new TreeNode(val);

            TreeNode cur = root;
            TreeNode pre = null;
            
            // 找到插入位置，BST 的查找
            while(cur is not null)
            {
                pre = cur;
                if(cur.val > val) cur = cur.left;
                else cur = cur.right;
            }

            TreeNode newnode = new TreeNode(val);
            if(pre.val > val) pre.left = newnode;
            else pre.right = newnode;
            return root;
        }
    }
}
