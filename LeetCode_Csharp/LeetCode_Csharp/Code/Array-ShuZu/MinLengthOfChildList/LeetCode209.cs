using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp
{
    public class LeetCode209
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            int start = 0;
            int minL = int.MaxValue;
            int sum = 0;
            for(int end = 0; end < nums.Length; end++)
            {
                sum += nums[end];
                while(sum >= target)
                {
                    minL = Math.Min(minL, end - start + 1);
                    sum -= nums[start];
                    start++;
                }
                
            }
            return minL == int.MaxValue ? 0 : minL;
        }
    }
}