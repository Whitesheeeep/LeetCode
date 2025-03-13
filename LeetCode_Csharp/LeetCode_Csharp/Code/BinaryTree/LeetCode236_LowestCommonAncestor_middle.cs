using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode236_LowestCommonAncestor_middle
    {
    #region 思路1：先找到两个节点的路径，然后比较路径。
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Stack<TreeNode> resultP = new Stack<TreeNode>();
            Stack<TreeNode> resultQ = new Stack<TreeNode>();
            resultP = GetPath(root, p);
            resultQ = GetPath(root, q);

            // 两个节点均在树中存在
            // 对于路径更长的先走
            // 预处理
            while(resultP.Count > resultQ.Count)
            {
                resultP.Pop();
            }
            while(resultQ.Count > resultP.Count)
            {
                resultQ.Pop();
            }

            while(resultP.Peek() != resultQ.Peek())
            {
                resultP.Pop();
                resultQ.Pop();
            }
            return resultP.Peek();

        }

        public Stack<TreeNode> GetPath(TreeNode root, TreeNode target)
        {
            Stack<TreeNode> path = new Stack<TreeNode>();
            FindPath( root, target, path);
            return path;
        }
        
        // 问题：path 会在回溯的时候被修改导致结果出问题
        public void GetPathHelper(TreeNode root, TreeNode target, Stack<TreeNode> path, Queue<TreeNode> result)
        {
            if(root is null) return;
            path.Push(root);

            if(root == target)
            {
                foreach(var node in path)
                {
                    result.Enqueue(node);
                }
                return;
            }

            if(root.left is not null)
            {
                GetPathHelper(root.left, target, path, result);
                path.Pop();
            }
            if(root.right is not null)
            {
                GetPathHelper(root.right, target, path, result);
                path.Pop();
            }
        }

        private bool FindPath(TreeNode root, TreeNode target, Stack<TreeNode> path)
        {
            if (root == null) return false;

            path.Push(root);

            if (root == target) return true;

            if (FindPath(root.left, target, path)) return true;
            if (FindPath(root.right, target, path)) return true;

            path.Pop();
            return false;
        }
    #endregion 思路1：先找到两个节点的路径，然后比较路径。
    
    #region 思路二：后续遍历（后序遍历是天然的回溯），自底向上找（回溯），找左右子树中是否存在，如果在左右子树找到 p、q 直接返回 root，一级一级向上返回root
        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root is null) return root;
            if(root == p || root == q) return root;

            TreeNode left = LowestCommonAncestor2(root.left, p, q);
            TreeNode right = LowestCommonAncestor2(root.right, p, q);

            if(left is not null && right is not null) return root;
            else if(left is not null && right is null) return left;
            else if(left is null && right is not null) return right;
            else return null;

        }
    #endregion 思路二：后续遍历，自底向上找，找左右子树中是否存在，如果在左右子树找到 p、q 直接返回 root，一级一级向上返回root
    }
}
