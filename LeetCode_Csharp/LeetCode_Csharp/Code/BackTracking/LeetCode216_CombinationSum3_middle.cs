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

        }

        private void BackTracking(int k, int n, List<int> path, List<IList<int>> res, int start)
        {
            if(path.Count == k)
            {
                res.Add([..path]);
                return;
            }

            for(int i = start; i < 9 -(k - path.Count)+1; i++)
            {
                
            }
        }
    }
}
