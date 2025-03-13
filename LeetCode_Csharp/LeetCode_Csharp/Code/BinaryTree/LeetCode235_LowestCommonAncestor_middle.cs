using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode235_LowestCommonAncestor_middle
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root is null) return root;
            if(root == p || root == q) return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if(left is not null && right is not null) return root;
            else if(left is not null && right is null) return left;
            else if(left is null && right is not null) return right;
            else return null;
        }
    }
}
