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
            BackTracking(candidates, target, curSum, path, res, 0);

            // 去重操作
            // 思想：快慢指针，快指针往后递增，慢指针始终指向一开始的，只有查到快慢指针指向的数组组合不同时移动慢指针到快指针处。
            // 加入一个 startIndex 就可以解决，上述思想将问题复杂化了
            
            return res;
        }

        public void BackTracking(int[] nums, int target, int curSum, List<int> path, List<IList<int>> res, int startIndex)
        {
            if (curSum > target) return;
            if (curSum == target)
            {
                res.Add([.. path]);
                return;
            }

            // 剪枝优化
            // 对总集合排序之后，如果下一层的sum（就是本层的 sum + candidates[i]）已经大于target，就可以结束本轮for循环的遍历。
            // https://programmercarl.com/0039.%E7%BB%84%E5%90%88%E6%80%BB%E5%92%8C.html#%E6%80%9D%E8%B7%AF
            for (int i = 0; i < nums.Length; i++)
            {
                // curSum += nums[leftStartIndex];
                path.Add(nums[i]);

                BackTracking(nums, target, curSum + nums[i], path, res, i);
                
                

                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
