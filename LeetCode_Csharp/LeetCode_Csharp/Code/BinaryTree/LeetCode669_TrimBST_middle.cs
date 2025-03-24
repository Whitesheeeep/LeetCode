using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode669_TrimBST_middle
    {
        // 依旧是二叉搜索树的性质
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if(root is null) return root;

            if(root.val < low) return TrimBST(root.right, low, high);
            if(root.val > high) return TrimBST(root.left, low, high);

            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);
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
