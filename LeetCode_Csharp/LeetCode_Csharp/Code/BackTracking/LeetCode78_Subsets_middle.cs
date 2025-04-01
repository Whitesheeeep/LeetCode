using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode78_Subsets_middle
    {
        List<int> path;
        List<IList<int>> res;
        public IList<IList<int>> Subsets(int[] nums)
        {
            path = new();
            res = new();
            for (int i = 0; i <= nums.Length; i++)
                BackTracking(nums, i, 0);
            return res;
        }

        #region Solution1
        private void BackTracking(int[] nums, int k, int startindex)
        {
            if (path.Count == k)
            {
                res.Add([.. path]);
                return;
            }

            for (int i = startindex; i < nums.Length; i++)
            {
                path.Add(nums[i]);
                BackTracking(nums, k, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }
        #endregion Solution1

        #region Solution2
        private void BackTracking(int[] nums, int startindex)
        {
            // res.Add([..path]); 在这进行 Add 也可，相当于在出节点的时候 Add，结果是一样的
            if (startindex >= nums.Length) return;

            for (int i = startindex; i < nums.Length; i++)
            {
                path.Add(nums[i]);
                res.Add([.. path]);
                BackTracking(nums, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }
        #endregion Solution2
    }
}
