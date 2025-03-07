using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode700_SearchBST_Easy
    {
        #region bfs
        // bfs
        public TreeNode SearchBST(TreeNode root, int val) 
        {
            if(root is null) return null;
            // 前序
            if(root.val == val) return root;
            if(root.val > val) return SearchBST(root.left, val);
            if(root.val < val) return SearchBST(root.right, val);
            return null;
        }
        #endregion

        #region dfs
        // dfs
        public TreeNode SearchBST_dfs(TreeNode root, int val) 
        {
            if(root is null) return null;

            Queue<TreeNode> queue = [];
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if(node.val == val) return node;
                if(node.left is not null && node.val > val) queue.Enqueue(node.left);
                if(node.right is not null && node.val < val) queue.Enqueue(node.right);
            }
            return null;
        }

        // 迭代法的更简单写法
        public TreeNode SearchBST_dfs2(TreeNode root, int val) 
        {
            if(root is null || root.val == val) return root;

            while(root is not null)
            {
                if(root.val == val) return root;
                if(root.val > val) root = root.left;
                if(root.val < val) root = root.right;
            }
            return null;
            
        }
        #endregion
    }
}
