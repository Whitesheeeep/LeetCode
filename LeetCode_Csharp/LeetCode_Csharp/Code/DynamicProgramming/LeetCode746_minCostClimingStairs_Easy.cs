using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode746_minCostClimingStairs_Easy
    {
        public int minCostClimingStairs(int[] cost)
        {
            if (cost.Length == 1) return 0;
            int[] dp = new int[cost.Length];
            dp[0] = 0; dp[1] = 0;
            for (int i = 2; i < cost.Length; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }
            return Math.Min(dp[cost.Length - 2] + cost[cost.Length - 2], dp[cost.Length - 1] + cost[^1]);
        }
    }
}
