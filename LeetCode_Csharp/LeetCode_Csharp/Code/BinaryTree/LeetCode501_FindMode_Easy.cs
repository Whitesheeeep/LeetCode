using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BinaryTree
{
    public class LeetCode501_FindMode_Easy
    {
        TreeNode pre = null;
        int count = 0, maxCount = 0;
        List<int> result = new List<int>();
        public int[] FindMode(TreeNode root)
        {
            // 复杂的方法一，这不能体现出二叉搜索树的特性
            // if(root is null) return [];
            // 问题：怎么存储每个数字对应的出现次数
            // 解决：使用Dictionary<int, int>来存储每个数字对应的出现次数
            // 问题：怎么找到出现次数最多的数字
            // 解决：遍历Dictionary<int, int>找到出现次数最多的数字
            // 遍历时间复杂度：O(n)
            // List<int> result = [];
            // Dictionary<int, int> appearCount = new Dictionary<int, int>();

            // 方法二，利用二叉搜索树的性质，中序遍历是有序的，众数一定是邻接节点的

            FindModeHelper(root);
            return result.ToArray();
        }


        public void FindModeHelper(TreeNode root)
        {
            if(root is null) return;

            FindModeHelper(root.left);

            if(pre is null) count = 1;
            else if(pre.val == root.val) count++;
            else count = 1; // pre.val != root.val
            pre= root;
            if(count == maxCount) result.Add(root.val);
            else if(count > maxCount)
            {
                result.Clear();
                result.Add(root.val);
                maxCount = count;
            }
            FindModeHelper(root.right);
        }
    }
}
