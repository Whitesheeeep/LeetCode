using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode216_CombinationSum3_middle
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            List<int> path = [];
            List<IList<int>> res = new();
            int curSum = 0;
            BackTracking(k, n, path, res, 1, curSum);
            return res;
        }

        private void BackTracking(int k, int n, List<int> path, List<IList<int>> res, int start, int curSum)
        {
            if(curSum > n) return;

            if (path.Count == k)
            {
                if(curSum == n)
                {
                    res.Add([.. path]);
                    return;
                }
            }

            for (int i = start; i <= 9 - (k - path.Count) + 1; i++)
            {
                path.Add(i);
                curSum += i;
                BackTracking(k, n, path, res, i + 1, curSum);
                curSum -= i;
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
