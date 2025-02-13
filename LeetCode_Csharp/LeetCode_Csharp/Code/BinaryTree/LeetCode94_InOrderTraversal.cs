using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode94_InOrderTraversal
    {
        // 迭代实现
        public IList<int> InorderTraversal(TreeNode<int> root)
        {
            List<int> res = [];
            Stack<TreeNode<int>> stack = [];
            TreeNode<int> current = root;
            if(root is null) return res;
            while(current is not null || stack.Count > 0)
            {
                while(current is not null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                if(stack.Count > 0)
                {
                    current = stack.Pop();
                    res.Add(current.val);
                    current = current.right;
                }
            }
            return res;
        }
    }
}
