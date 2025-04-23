using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode53_MaxSubArray_middle
    {
        public int MaxSubArray(int[] nums)
        {
            // 只要前面的和不小于 0，对于后者就不是拖累，就可以继续贪心
            int sum = int.MinValue;
            int temp = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                temp += nums[i];
                if(temp > sum) sum = temp; // 动态更新，保持为最大

                if(temp <= 0) temp = 0;
            }
            return sum;
        }
    }
}
