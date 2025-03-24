using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode39_CombinationSum_middle
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (candidates.Length == 0) return [];
            int curSum = 0;
            List<int> path = [];
            List<IList<int>> res = new();
            BackTracking(candidates, target, curSum, path, res);

            // 去重操作
            // 思想：快慢指针，快指针往后递增，慢指针始终指向一开始的，只有查到快慢指针指向的数组组合不同时移动慢指针到快指针处。
            return res;
        }

        public void BackTracking(int[] nums, int target, int curSum, List<int> path, List<IList<int>> res)
        {
            if (curSum > target) return;
            if (curSum == target)
            {
                res.Add([.. path]);
                return;
            }


            for (int i = 0; i < nums.Length; i++)
            {
                // curSum += nums[leftStartIndex];
                path.Add(nums[i]);

                BackTracking(nums, target, curSum + nums[i], path, res);

                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
