using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode77_Combine_middle
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> res = new();
            List<int> path = [];
            BackTracking(n, k, res, path, 1);
            return res;
        }


        /// <param name="left"> 用于标识从传入的数字开始有效的索引</param>
        private void BackTracking(int n, int k, List<IList<int>> res, List<int> path, int left)
        {
            // 终止条件
            if (path.Count == k)
            {
                res.Add([.. path]);
                return;
            }

            for (int i = left; i <= n; i++)
            // 剪枝
            // for(int i = left; i <= n - (k - path.Count) + 1; i++)
            {
                path.Add(i);
                BackTracking(n, k, res, path, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
