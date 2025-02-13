using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode_Csharp.LinkedList;

namespace LeetCode_Csharp.Code.BinaryTree
{

    // 后序遍历，左右根
    // 实现方式不要想复杂，发现 根左右 是前序比那里，容易实现，那么根右左只是在实现前序的时候更换指针，
    // 也很容易实现，而且反转一下就是左右根后序遍历了。因此只要把前序遍历改一下最后反转一下就好来了。
    public class LeetCode145_PostorderTraversal_Easy
    {
        // 递归实现
        public IList<int> PostorderTraversal(TreeNode<int> root) 
        {
            List<int> res = [];
            if(root is null) return res;
            res.AddRange(PostorderTraversal(root.left));
            res.AddRange(PostorderTraversal(root.right));
            res.Add(root.val);
            return res;
        }

        #region  迭代实现
        // 迭代实现：实现方法 1
        public IList<int> PostorderTraversal2(TreeNode<int> root)
        {
            List<int> res = [];
            Stack<TreeNode<int>> stack = [];
            TreeNode<int> current = root;
            if(root is null) return res;

            while(current is not null || stack.Count > 0)
            {
                // 这里while 可以用 if 代替，此时下面那个 if 改成 else，如下所示
                /* if(current is not null)
                {
                    stack.Push(current);
                    res.Add(current.val);
                    current = current.right;
                }
                else 
                {
                    // 转向右子树
                    current = stack.Pop();
                    current = current.left;
                } */
                while(current is not null)
                {
                    stack.Push(current);
                    res.Add(current.val);
                    current = current.right;
                }
                if(stack.Count > 0)
                {
                    // 转向右子树
                    current = stack.Pop();
                    current = current.left;
                }
            }
            res.Reverse();
            return res;
        }
        
        // 迭代实现：方法 2
        public IList<int> PostorderTraversal3(TreeNode<int> root)
        {
            List<int> res = [];
            if(root is null) return res;

            Stack<TreeNode<int>> stack = [];
            TreeNode<int> current = root;
            stack.Push(current);
            while(stack.Count > 0)
            {
                current = stack.Pop();
                res.Add(current.val);
                if(current.left is not null) stack.Push(current.left);
                if(current.right is not null) stack.Push(current.right);
            }
            // 将结果反转：时间复杂度：O(n)
            res.Reverse();
            return res;
        }
        #endregion 迭代实现
    }
}
