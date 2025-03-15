using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode450_DeleteNode_middle
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root is null) return root;

            if (root.val > key) root.left = DeleteNode(root.left, key);
            else if (root.val < key) root.right = DeleteNode(root.right, key);
            else // 找到了要删除的节点
            {
                if (root.left is null && root.right is null) return null;
                else if (root.left is null || root.right is null) return root.left is null ? root.right : root.left;
                else // 要删除的节点，左右子树都有, 有两种方式，找左子树的最右边的结点（左子树的最大值）或者找右子树的最左边的结点（右子树的最小值）
                {
                    TreeNode cur = root.right;
                    while (cur.left is not null) cur = cur.left;
                    root.val = cur.val;
                    root.right = DeleteNode(root.right, cur.val);
                }
            }
            return root;
        }
    }
}
