using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode513_FindBottomLeftValue_middle
    {
        #region bfs
        public int  FindBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> treeNodes = [];
            int res = 0;

            treeNodes.Enqueue(root);
            while(treeNodes.Count>0)
            {
                int size = treeNodes.Count;
                int tmp = size;
                while(size-->0)
                {
                    TreeNode temp = treeNodes.Dequeue();
                    if(size+1 == tmp) res = temp.val;
                    if(temp.left is not null) treeNodes.Enqueue(temp.left);
                    if(temp.right is not null) treeNodes.Enqueue(temp.right);
                }
            }
            return res;
        }
        #endregion bfs

        #region dfs
        public int FindBottomLeftValue_dfs(TreeNode root)
        {
            int curH = 0, curVal = 0;
            DFS(root, 0, ref curVal, ref curH);
            return curVal;
        }

        public void DFS(TreeNode treeNode, int height, ref int curVal, ref int curH)
        {
            if(treeNode is null) return;

            height++;
            DFS(treeNode.left, height,ref curVal,ref curH);
            DFS(treeNode.right, height,ref curVal,ref curH);
            if(height > curH)
            {
                curH = height;
                curVal = treeNode.val;
            }
        }
        #endregion dfs
    }
}
