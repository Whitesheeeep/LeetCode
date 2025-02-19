using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode101_IsSymmetric_Easy
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root is null) return true;
            return CheckSymmetry(root.left, root.right);
        }

        // 后续遍历
        /* 
        不要看到 result = node_1.val == node_2.val 就认为是前序遍历，
        这里并没有返回结果而是继续判断左右子树，所以最后先是左右判断后返回结果，
        之后才能得到中结点是否满足题意，所以是后续遍历
         */
        public bool CheckSymmetry(TreeNode node_1, TreeNode node_2)
        {
            if (node_1 is null && node_2 is null) return true;
            if (node_1 is null || node_2 is null) return false;
            if (node_1.val != node_2.val) return false;
            bool result, res_left, res_right;
            result = node_1.val == node_2.val;
            res_left = CheckSymmetry(node_1.left, node_2.right);
            res_right = CheckSymmetry(node_1.right, node_2.left);
            return result && res_left && res_right;
        }
        
        // bfs
        /* 
        成对的节点入队，然后出队时成对的节点进行比较，
        之后再将成对的节点入队，直到队列为空
        为空即树所有的节点都比较完毕
         */
        public bool IsSymmetric2(TreeNode root)
        {
            if (root is null) return true;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count > 0)
            {
                TreeNode node_1 = queue.Dequeue();
                TreeNode node_2 = queue.Dequeue();
                if (node_1 is null && node_2 is null) continue;
                if (node_1 is null || node_2 is null) return false;
                if (node_1.val != node_2.val) return false;
                queue.Enqueue(node_1.left);
                queue.Enqueue(node_2.right);
                queue.Enqueue(node_1.right);
                queue.Enqueue(node_2.left);
            }
            return true;   
        }
    }
}
