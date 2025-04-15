using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode47_PermuteUnique_middle
    {
        List<int> path;
        List<IList<int>> res;
        int[] used;
        // bool[] layerUsed; layerUsed 是多余的
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            if(nums.Length == 0) return [];
            path = new();
            res = new();
            used = new int[nums.Length];
            // layerUsed = new bool[nums.Length];
            Array.Sort(nums);
            BackTracking(nums);
            return res;
        }

        private void BackTracking(in int[] nums)
        {
            if(path.Count == nums.Length)
            {
                res.Add([..path]);
                return;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if(i > 0 && nums[i-1] == nums[i] && used[i-1] == 0 || used[i] == 1) continue;// || 前半部分树层去重，后半部分用于舍去已经选取过的，或者说树枝去重

                used[i] = 1;
                // layerUsed[i] = true;
                path.Add(nums[i]);
                BackTracking(nums);
                used[i] = 0;
                // layerUsed[i] = false;
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
