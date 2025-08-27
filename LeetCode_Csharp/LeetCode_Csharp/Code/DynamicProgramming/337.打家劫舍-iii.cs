/*
 * @lc app=leetcode.cn id=337 lang=csharp
 *
 * [337] 打家劫舍 III
 */

// @lc code=start

using System.Diagnostics;
using LeetCode_Csharp.Code.BinaryTree;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public partial class Solution
{
    public int Rob(TreeNode root)
    {
        var res = DFS(root);
        return Math.Max(res[0], res[1]);
    }

    public List<int> DFS(TreeNode root)
    {
        if (root == null) return [0, 0];

        // 0 是偷，1 是不偷
        List<int> left = DFS(root.left);
        List<int> right = DFS(root.right);

        // 偷
        int stolen = root.val + left[1] + right[1];
        // 不偷
        int nonstolen = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);


        return [stolen, nonstolen];
    }

    // 深搜超时，不好处理斜树
    // 具体原因是：有重复计算，DFS(left) 里面就已经计算了 DFS(left.left), DFS(left.right)
    // 优化方法：进行记忆化搜索
    /* public int Rob(TreeNode root)
    {
        return DFS(root);
    }

    public int DFS(TreeNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return root.val;

        int money_noself = DFS(root.left) + DFS(root.right);
        // 根节点偷
        int money_self;
        if (root.left == null || root.right == null)
        {
            var node = root.left ?? root.right;
            money_self = root.val + DFS(node.left) + DFS(node.right);
        }
        else
        {
            money_self = root.val + DFS(root.left.left) + DFS(root.left.right)
            + DFS(root.right.left) + DFS(root.right.right);
        }
        return Math.Max(money_noself, money_self);
    } */


    // 理解题意错误，这个只针对只有头结点有两个孩子的情况，而题目要求的是只有一个父亲，这就表明倒数第二层，可能存在两个孩子
    /* public int Rob(TreeNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return root.val;

        // root 不偷
        int money_NoRoot = RobMax(root.left) + RobMax(root.right);
        // root 偷
        int money_YesRoot = 0;
        if (root.left == null) money_YesRoot = RobMax(Grand(root));
        else if (root.right == null) money_YesRoot = RobMax(Grand(root));
        else
        {
            TreeNode leftChild = root.left.left ?? root.left.right;
            TreeNode rightChild = root.right.left ?? root.right.right;
            money_YesRoot = root.val +  Math.Max(RobMax(leftChild), RobMax(rightChild));

        }

        return Math.Max(money_NoRoot, money_YesRoot);
    }

    public int RobMax(TreeNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return root.val;

        int stolenMoney = Math.Max(RobMax(root.left ?? root.right),
            RobMax(Grand(root)) + root.val);
        
        return stolenMoney;
    }

    public TreeNode Grand(TreeNode root)
    {
        if (root.left != null) return root.left.left ?? root.left.right;
        else return root.right.left ?? root.right.right;
    } */
}
// @lc code=end

