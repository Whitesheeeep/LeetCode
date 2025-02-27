using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode106_BuildTree_middle
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder) 
        {
            if(inorder.Length == 0 || postorder.Length == 0) return null;

            return BuildTreeByInAndPost(null, inorder, postorder);
        }

        public TreeNode BuildTreeByInAndPost(TreeNode treeNode, int[] inorder, int[] postorder)
        {
            if(inorder.Length == 0 || postorder.Length == 0) return null;
            if(inorder.Length == 1 || postorder.Length == 1) return new TreeNode(inorder[0]);

            TreeNode root = new TreeNode(postorder[postorder.Length - 1]);
            // IndexOf 的时间复杂度为 O(n)，可以优化为 O(1)
            int rootIndex = Array.IndexOf(inorder, root.val);
            int[] leftInorder = inorder[..rootIndex];
            int[] rightInorder = inorder[(rootIndex + 1)..];
            root.left = BuildTreeByInAndPost(root, leftInorder, postorder[..leftInorder.Length]);
            root.right = BuildTreeByInAndPost(root, rightInorder, postorder[leftInorder.Length..^1]);
            return root;
        }

        // 使用索引来优化，这样就不用每一次都去复制数组中的数据，减少了时间复杂度
        public TreeNode BuildTreeByInAndPost_Index(TreeNode treeNode, ref int[] inorder, int startIndex , int endIndex, 
        ref int[] postorder, int leftength)
        {
            if(startIndex > endIndex) return null;
            if(startIndex == endIndex) return new TreeNode(inorder[startIndex]);

            TreeNode root = new TreeNode(postorder[leftength]);
            int rootIndex = Array.IndexOf(inorder, root.val);
            root.left = BuildTreeByInAndPost_Index(root, ref inorder, startIndex, rootIndex - 1, ref postorder, leftength - 1);
            root.right = BuildTreeByInAndPost_Index(root, ref inorder, rootIndex + 1, endIndex, ref postorder, leftength - 1);
            return root;
        }
    }
}
