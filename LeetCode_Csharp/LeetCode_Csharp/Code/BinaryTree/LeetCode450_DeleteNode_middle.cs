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

        public TreeNode DeleteNode_Iteration(TreeNode root, int key)
        {
            if(root is null) return root;

            TreeNode cur = root, pre = null;
            // 找到要删除的节点
            while(cur is not null)
            {
                if(cur.val == key) break;
                pre = cur;
                if(cur.val > key) cur = cur.left;
                else cur = cur.right;
            }

            if(pre is null) return DeleteOneNode( cur);

            // 这个地方是判断cur是pre的左节点还是右节点
            // if(pre.left == cur) pre.left = DeleteOneNode(cur);
            // if(pre.right == cur) pre.right = DeleteOneNode(cur);
            if(pre.left is not null && pre.left.val == key) pre.left = DeleteOneNode(cur);
            if(pre.right is not null && pre.right.val == key) pre.right = DeleteOneNode(cur);
            return root;
        }

        // 删除一个节点
        // 这个是直接将一边的树直接嫁接到另一边的树
        private TreeNode DeleteOneNode(TreeNode treeNode)
        {
            if(treeNode is null) return null;
            if(treeNode.left is null) return treeNode.right;
            if(treeNode.right is null) return treeNode.left;

            TreeNode cur = treeNode.right;
            while(cur.left is not null) cur = cur.left;
            cur.left = treeNode.left;
            return treeNode.right;
        }
    }
}
