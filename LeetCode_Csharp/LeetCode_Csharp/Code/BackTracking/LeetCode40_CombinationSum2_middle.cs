using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode40_CombinationSum2_middle
    {
        List<int> path = new();
        List<IList<int>> res = new();
        // 相较于 CombinationSum，本题没有要求数组中各个数字不相同，也就是说，会有重复的数字出现
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);


            BackTracking(candidates, target, 0, 0);
            return res;


        }

        private void BackTracking(int[] nums, int target, int startIndex, int curSum)
        {
            if (curSum > target) return;
            else if (curSum == target)
            {
                res.Add([.. path]);
                return;
            }

            for (int i = startIndex; i < nums.Length && curSum + nums[i] <= target; i++)
            {
                // 另一种去重：if (i > start && candidates[i] == candidates[i - 1]) continue;
                // 还有一种去重：used
                int temp = nums[i];
                path.Add(temp);
                BackTracking(nums, target, i + 1, curSum + temp);
                // 去重，在这去重的思路：用 nums[i] 的 path 的可能性都找过了，没必要再次使用 nums[i]，因此直接找到最后不为 nums[i] 的继续进行
                while (i < nums.Length && nums[i] == temp)
                {
                    i++;
                }
                i--;
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
