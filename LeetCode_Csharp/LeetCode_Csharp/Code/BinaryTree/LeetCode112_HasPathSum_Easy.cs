using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode112_HasPathSum_Easy
    {
        // 回溯的再次使用，与 LeetCode 257 一样
        public bool HasPathSum(TreeNode root, int targetSum) 
        {
            int sum = 0;
            if (root is null) return false;
            return DFS(root, sum, in targetSum);
        }
        
        public bool DFS(TreeNode treeNode, int sum, in int targetSum)
        {
            sum += treeNode.val;
            if(treeNode.left is null && treeNode.right is null && sum!= targetSum) return false;
            if(treeNode.left is null && treeNode.right is null && sum == targetSum) return true;
            
            bool left = false, right = false;
            if(treeNode.left is not null) left = DFS(treeNode.left, sum, in targetSum);
            if(left is true) return true;
            if(treeNode.right is not null) right = DFS(treeNode.right, sum, in targetSum);
            if(right is true) return true;
            return false;
        }
    }
}
