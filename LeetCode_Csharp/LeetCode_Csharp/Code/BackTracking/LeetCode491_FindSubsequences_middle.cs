using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode491_FindSubsequences_middle
    {
        List<int> path;
        List<IList<int>> res;
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            path = new List<int>();
            res = new List<IList<int>>();
            if(nums.Length < 2) return res;
            BackTracking(nums, 0);
            return res;
        }

        private void BackTracking(int[] nums, int startIndex)
        {
            // 这就可以在每层进行检测，从而达到树层去重
            HashSet<int> used = new();

            for(int i = startIndex; i < nums.Length; i++)
            {
                // 树层去重
                // 在此处进行去重（或者说是剪枝）的操作的前提是数组进行了排序，但是在此题是不能进行排序的
                // 用字典记录进行去重？
                // 用 HastSet 即可
                if(path.Count > 0 && nums[i] < path.Last() || used.Contains(nums[i])) continue;

                path.Add(nums[i]);
                used.Add(nums[i]);
                if(path.Count > 1) res.Add([..path]);

                BackTracking(nums, i + 1);
                path.RemoveAt(path.Count - 1);

            }
        }
    }
}


