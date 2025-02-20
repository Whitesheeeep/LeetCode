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
            List<TreeNode> treeNodes = new();
            List<string> result = new();
            // if(root is null) return result;
            DFS(root, treeNodes, result);
            return result; 

        }

        // 第一部分：递归函数，递归函数的参数，递归函数的返回值
        // treeNodes：存储当前路径上的所有节点，同时用于回溯
        // result：存储结果
        public void DFS(TreeNode node, List<TreeNode> treeNodes, List<string> result)
        {
            if(node is null) return;
            treeNodes.Add(node);
            // 第二部分：递归终止条件
            // 如果当前节点是叶子节点，将当前路径上的所有节点的值拼接成字符串，添加到结果中
            if(node.left is null && node.right is null)
            {
                StringBuilder sb = new();
                for(int i = 0; i < treeNodes.Count; i++)
                {
                    sb.Append(treeNodes[i].val);
                    if(i < treeNodes.Count - 1)
                    {
                        sb.Append("->");
                    }
                }
                result.Add(sb.ToString());
                return;
            }

            // 第三部分：递归函数的逻辑
            // 如果当前节点不是叶子节点，将当前节点添加到路径中，继续递归左右子节点
            // 注意回溯，回溯与递归同时进行
            // 注意条件，有可能左子结点为空，所以要判断左子结点是否为空
            if(node.left is not null)
            {
                DFS(node.left, treeNodes, result);
                // 回溯
                treeNodes.RemoveAt(treeNodes.Count - 1);
            }
            if(node.right is not null)
            {
                DFS(node.right, treeNodes, result);
                // 回溯
                treeNodes.RemoveAt(treeNodes.Count - 1);
            }
        }


        #region 精简代码
        public IList<string> BinaryTreePaths2(TreeNode root)
        {
            string str = "";
            List<string> result = new();
            
            Traversal(root, str, result);
            return result; 
        }

        public void Traversal(TreeNode node, string str, List<string> result)
        {
            if(node is null) return;
            str += node.val;
            if(node.left is null && node.right is null)
            {
                result.Add(str);
                return;
            }
            if(node.left is not null) Traversal(node.left, str + "->" , result);
            if(node.right is not null) Traversal(node.right, str + "->" , result);
        }
        #endregion 精简代码

        #region 尝试区代码
        public IList<string> BinaryTreePaths_T1(TreeNode root) 
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
        public IList<string> BinaryTreePaths_T2(TreeNode root)
        {
            List<string> res = [];
            if(root is null) return res;
            StringBuilder sb = new StringBuilder();
            return res;
            
        }
        #endregion 尝试区代码
    }
}
