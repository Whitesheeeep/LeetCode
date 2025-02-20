using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode257_BinaryTreePaths_Easy
    {
        public IList<string> BinaryTreePaths(TreeNode root) 
        {
            StringBuilder sb = new StringBuilder();
            List<string> res = new List<string>();

            if(root is null) return res;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            while(current is not null || stack.Count > 0)
            {
                while(current is not null)
                {
                    stack.Push(current);
                    if(sb.Length > 0) sb.Append("->");
                    sb.Append(current.val);
                    current = current.left;
                }

                current = stack.Pop();

                // Error：这里只会删去叶子结点的字符和对应的箭头，但是不会删去非叶子结点的字符和箭头
                // 如果是叶子节点
                /* if(current.left is null && current.right is null)
                {
                    res.Add(sb.ToString());
                    // 回溯字符串
                    if(sb.Length > 3)
                    {
                        int len = current.val.ToString().Length + 2;// 2是"->"的长度
                        sb.Remove(sb.Length - len,len);
                    }
                } */


                current = current.right;
            }
            return res;
        }

        // 问题：字符串如何回溯
        public IList<string> BinaryTreePaths1(TreeNode root)
        {
            List<string> res = [];
            if(root is null) return res;
            StringBuilder sb = new StringBuilder();
            return res;
            
        }
    }
}
