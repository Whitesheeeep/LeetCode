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
        bool[] used;
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            path = new List<int>();
            res = new List<IList<int>>();
            used = new bool[nums.Length];
            if(nums.Length == 0) return res;
            if(nums.Length == 1) return [nums];

            BackTracking(nums, 0);
            return res;
        }

        private void BackTracking(int[] nums, int startIndex)
        {

            for(int i = startIndex; i < nums.Length; i++)
            {
                // 树层去重
                if(i > 0 && nums[i] == nums[i-1] && used[i-1] == false) continue;
                if(path.Count > 0 && nums[i] < path.Last()) continue;
                path.Add(nums[i]);
                if(path.Count > 1) res.Add([..path]);
                used[i] = true;
                BackTracking(nums, i + 1);
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }
    }
}


