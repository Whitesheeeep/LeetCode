using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode617_MergeTrees_easy
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return null;
            if (root1 == null) return root2;
            if (root2 == null) return root1;

            // 两个树都不为空
            TreeNode root = new TreeNode(root1.val + root2.val);
            root.left = MergeTrees(root1.left, root2.left);
            root.right = MergeTrees(root1.right, root2.right);
            return root;
        }

        public TreeNode MergeTrees2(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return null;
            if (root1 == null) return root2;
            if (root2 == null) return root1;

            // 两个树都不为空
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root1);
            queue.Enqueue(root2);
            while (queue.Count > 0)
            {
                TreeNode node1 = queue.Dequeue();
                TreeNode node2 = queue.Dequeue();
                node1.val += node2.val;
                if (node1.left is not null && node2.left is not null)
                {
                    queue.Enqueue(node1.left);
                    queue.Enqueue(node2.left);
                }

                if (node1.right is not null && node2.right is not null)
                {
                    queue.Enqueue(node1.right);
                    queue.Enqueue(node2.right);
                }

                if (node1.left is null && node2.left is not null)
                {
                    node1.left = node2.left;
                }
                if (node1.right is null && node2.right is not null)
                {
                    node1.right = node2.right;
                }
            }
            return root1;
        }
    }
}
