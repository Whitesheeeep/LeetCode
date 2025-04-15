using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode46_Permute_middle
    {
        List<int> path;
        List<IList<int>> res;
        public IList<IList<int>> Permute(int[] nums)
        {
            path = new();
            res = new();
            BackTracking(nums);
            return res;
        }

        private void BackTracking(int[] nums)
        {
            int[] used = new int[nums.Length];

            if(path.Count == nums.Length)
            {
                res.Add([..path]);
                return;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if(used[i] == 1) continue;
                path.Add(nums[i]);
                used[i] = 1;
                BackTracking(nums);
                path.RemoveAt(path.Count - 1);
                used[i] = 0;
            }
        }
    }
}
