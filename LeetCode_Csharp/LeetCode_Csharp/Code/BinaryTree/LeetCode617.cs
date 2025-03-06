using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode617
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2) 
        {
            if(root1 == null && root2 == null) return null;
            if(root1 == null) return root2;
            if(root2 == null) return root1;

            // 两个树都不为空
            TreeNode root = new TreeNode(root1.val + root2.val);
            root.left = MergeTrees(root1.left, root2.left);
            root.right = MergeTrees(root1.right, root2.right);
            return root;
        }

        public TreeNode MergeTrees2(TreeNode root1, TreeNode root2)
        {
            if(root1 == null && root2 == null) return null;
            if(root1 == null) return root2;
            if(root2 == null) return root1;

            // 两个树都不为空
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = null;
            TreeNode node = root;
            queue.Enqueue(root1);
            queue.Enqueue(root2);
            while(queue.Count > 0)
            {
                int size = queue.Count;
                while(size > 0)
                {
                    size -= 2;
                    TreeNode node1 = queue.Dequeue();
                    TreeNode node2 = queue.Dequeue();
                    if(node1 == null && node2 == null) continue;
                    if(node1 == null)
                    {
                        node.val = node2.val;
                        continue;
                    }
                    
                    
                }
            }
            return root;
        }
    }
}
