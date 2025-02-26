using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode404_SumOfLeftLeaves_Easy
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            if(root is null) return 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int result = 0;

            // 初始化
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                int size = queue.Count;
                while(size-- >0)
                {
                    TreeNode current = queue.Dequeue();
                    if(current.left is null && current.right is null) result += current.left.val;
                    if(current.left is not null) queue.Enqueue(current.left);
                    if(current.right is not null) queue.Enqueue(current.right);
                }
            }
            return result;
        }
    }
}
