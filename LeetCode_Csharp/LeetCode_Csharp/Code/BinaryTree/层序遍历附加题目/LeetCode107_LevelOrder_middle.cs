using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree.层序遍历附加题目
{
    public class LeetCode107_LevelOrder_middle
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode<int> root) 
        {
            if(root is null) return [];

            List<IList<int>> res = [];
            Queue<TreeNode<int>> queue = [];
            
            // 初始化
            queue.Enqueue(root);
            int size = 1;
            while(queue.Count > 0)
            {
                // 记录当前层的节点个数
                size = queue.Count;
                // 记录当前层的节点值
                List<int> level = [];
                while(size-- > 0)
                {
                    TreeNode<int> node = queue.Dequeue();
                    level.Add(node.val);
                    if(node.left is not null) queue.Enqueue(node.left);
                    if(node.right is not null) queue.Enqueue(node.right);
                }
                res.Add(level);
            }
            res.Reverse();
            return res;
        }
    }
}
