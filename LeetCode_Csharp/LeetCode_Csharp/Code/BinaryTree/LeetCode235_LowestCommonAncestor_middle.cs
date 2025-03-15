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
            // 从上往下搜
            if(root.val > p.val && root.val > q.val) return LowestCommonAncestor(root.left, p, q);
            if(root.val < p.val && root.val < q.val) return LowestCommonAncestor(root.right, p, q);

            return root;
        }
    }
}
