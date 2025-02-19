using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode226_InvertTree_Easy
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if(root is null) return null;

            TreeNode temp = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);

            return root;
        }

        // dfs: 前序遍历
        public TreeNode InvertTree1(TreeNode root)
        {
            if(root is null) return null;

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree1(root.left);
            InvertTree1(root.right);

            return root;
        }

        // bfs：站在本层操作下一层
        public TreeNode InvertTree2(TreeNode root)
        {
            if(root is null) return null;

            Queue<TreeNode> queue = [];
            // 初始化
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                int size = queue.Count;
                while(size-- > 0)
                {
                    TreeNode current = queue.Dequeue();

                    TreeNode temp = current.left;
                    current.left = current.right;
                    current.right = temp;

                    if(current.left is not null) queue.Enqueue(current.left);
                    if(current.right is not null) queue.Enqueue(current.right);
                }
            }
            return root;
        }
    }
}
