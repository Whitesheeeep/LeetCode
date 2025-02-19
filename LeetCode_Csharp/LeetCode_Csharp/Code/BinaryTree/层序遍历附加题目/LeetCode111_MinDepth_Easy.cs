using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree.层序遍历附加题目
{
    public class LeetCode111_MinDepth_Easy
    {
        public int MinDepth(TreeNode root)
        {
            if(root is null) return 0;

            Queue<TreeNode> queue = [];

            // 初始化
            TreeNode current = root;
            queue.Enqueue(current);
            int depth = 0;

            while(queue.Count > 0)
            {
                int size = queue.Count;
                depth++;
                while (size-- > 0)
                {
                    current = queue.Dequeue();
                    if(current.left is not null) queue.Enqueue(current.left);
                    if(current.right is not null) queue.Enqueue(current.right);
                    if(current.left is null && current.right is null) return depth;
                }
            }
            return depth;
        }

        // 递归
        public int MinDepth2(TreeNode root)
        {
            if(root is null) return 0;
            if(root.left is null) return MinDepth2(root.right) + 1;
            if(root.right is null) return MinDepth2(root.left) + 1;
            return Math.Min(MinDepth2(root.left), MinDepth2(root.right)) + 1;
            
            /* 
            int minDepth, l_Depth, r_Depth;
            if(root is null) return 0;
            l_Depth = MinDepth(root.left);
            r_Depth = MinDepth(root.right);
            if(l_Depth == 0 || r_Depth == 0)
            {
                minDepth = l_Depth == 0 ? r_Depth : l_Depth;``
                return minDepth + 1;
            }
            minDepth = l_Depth < r_Depth ? l_Depth : r_Depth;
            return minDepth+1;
         */
            
        }
    }
}
