using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode222_CountNodes_Easy
    {
        // 前序遍历，递归实现
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        public int CountNodes2(TreeNode root)
        {
            if(root is null) return 0;

            Stack<TreeNode> stack = new Stack<TreeNode>();

            // 初始化
            int count = 0;

            TreeNode temp = root;
            while(temp is not null || stack.Count > 0)
            {
                while(temp is not null)
                {
                    stack.Push(temp);
                    count++;
                    temp = temp.left;
                }

                temp = stack.Pop();
                temp = temp.right;
            }
            return count;
        }

        // 第三种方法，利用完全二叉树和完美二叉树的性质
        // 完美二叉树的节点数 = 2^h - 1
        public int CountNodes3(TreeNode root)
        {
            // 递归终止条件
            if(root is null) return 0;

            // 计算左右子树的高度
            int leftHeight = 0;
            int rightHeight = 0;
            TreeNode left = root.left;
            TreeNode right = root.right;

            while(left is not null)
            {
                leftHeight++;
                left = left.left;
            }

            while(right is not null)
            {
                rightHeight++;
                right = right.right;
            }
            // 左右子树高度计算完成

            // 如果左右子树的高度相等，说明是完美二叉树
            if(leftHeight == rightHeight)
            {
                // 2^h - 1，但是注意 << 位运算符优先级比减号低
                return (2 << leftHeight) - 1;
            }

            return 1 + CountNodes3(root.left) + CountNodes3(root.right);
        }
    }
}
