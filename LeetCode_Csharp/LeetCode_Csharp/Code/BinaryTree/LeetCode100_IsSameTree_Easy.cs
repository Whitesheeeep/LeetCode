using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode100_IsSameTree_Easy
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p is null && q is null) return true;
            if (p is null || q is null) return false;
            if (p.val != q.val) return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        public bool IsSameTree2(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(p);
            queue.Enqueue(q);
            while (queue.Count > 0)
            {
                TreeNode node_1 = queue.Dequeue();
                TreeNode node_2 = queue.Dequeue();
                if (node_1 is null && node_2 is null) continue;
                if (node_1 is null || node_2 is null) return false;
                if (node_1.val != node_2.val) return false;
                queue.Enqueue(node_1.left);
                queue.Enqueue(node_2.left);
                queue.Enqueue(node_1.right);
                queue.Enqueue(node_2.right);
            }
            return true;
        }
    }
}
