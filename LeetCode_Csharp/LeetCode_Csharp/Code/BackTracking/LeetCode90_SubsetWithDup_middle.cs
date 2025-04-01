using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode90_SubsetWithDup_middle
    {
        List<int> path;
        List<IList<int>> res;
        int[] used;
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            path = new();
            res = new();
            used = new int[nums.Length];
            res.Add([]);
            Array.Sort(nums);
            BackTracking(nums, 0);
            return res;
        }

        private void BackTracking(int[] nums, int startIndex)
        {
            if(startIndex >= nums.Length) return;


            for(int i = startIndex; i < nums.Length; i++)
            {
                if(i > 0 && nums[i-1] == nums[i] && used[i-1] == 0) continue;
                path.Add(nums[i]);
                res.Add([..path]);
                used[i] = 1;
                BackTracking(nums, i + 1);
                path.RemoveAt(path.Count - 1);
                used[i] = 0;
            }
        }
    }
}
