using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree.层序遍历附加题目
{
    public class LeetCode199_RigthSideView_middle
    {
        public  IList<int> RigthSideView(TreeNode<int> root)
        {
            if(root is null) return [];

            List<int> res = [];
            // 初始化
            Queue<TreeNode<int>> queue = [];
            queue.Enqueue(root);

            // 层序遍历，但是只输出最后的节点
            while(queue.Count > 0)
            {
                int size = queue.Count;
                while(size-- > 0)
                {
                    TreeNode<int> node = queue.Dequeue();
                    if(size == 0) res.Add(node.val);
                    if(node.left is not null) queue.Enqueue(node.left);
                    if(node.right is not null) queue.Enqueue(node.right);
                }
            }
            return res;
        }
    }
}
