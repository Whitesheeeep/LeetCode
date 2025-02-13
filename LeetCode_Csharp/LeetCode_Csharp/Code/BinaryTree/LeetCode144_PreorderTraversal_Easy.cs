using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode144_PreorderTraversal_Easy
    {
        #region 递归实现
        public IList<int> PreorderTraversal(TreeNode<int> root)
        {
            List<int> result = [];
            if (root == null)
            {
                return result;
            }
            result.Add(root.val);
            // AddRange(IEnumerable<T> collection) 表示将一个集合中的元素添加到另一个集合中
            result.AddRange(PreorderTraversal(root.left));
            result.AddRange(PreorderTraversal(root.right));
            return result;
        }
        #endregion  递归实现

        #region 迭代实现
        // 迭代实现
        public IList<int> PreorderTraversal2(TreeNode<int> root)
        {
            List<int> res = [];
            Stack<TreeNode<int>> stack = [];
            if(root == null) return res;

            TreeNode<int> current = root;
            while(current != null || stack.Count > 0)
            {
                while(current != null)
                {
                    stack.Push(current);
                    res.Add(current.val);
                    current = current.left;
                }

                if(stack.Count > 0)
                {
                    current = stack.Pop();
                    current = current.right;
                }
            }

            return res;
        }

        // 迭代实现：方法 2
        public IList<int> PreorderTraversal3(TreeNode<int> root)
        {
            List<int> res = [];
            if(root == null) return res;

            Stack<TreeNode<int>> stack = [];
            TreeNode<int> current = root;
            stack.Push(current);

            while(stack.Count > 0)
            {
                current = stack.Pop();
                res.Add(current.val);
                if(current.right != null) stack.Push(current.right);
                if(current.left != null) stack.Push(current.left);
            }
            return res;
        }
        #endregion 迭代实现
    }
}
