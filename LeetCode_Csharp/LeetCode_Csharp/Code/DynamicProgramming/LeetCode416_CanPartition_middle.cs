using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode416_CanPartition_middle
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            foreach (int i in nums) sum += i;

            // dp[i][j] 表示：从 0 ~ i 中选取的数字的总和 * 2 与 j 的距离的最小值，带正负号
            int[,] dp = new int[nums.Length, sum + 1];
            // 初始化
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < sum + 1; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }
            // 初始化只拿物品 0 的情况
            for (int i = 0; i < sum + 1; i++)
            {
                dp[0, i] = Math.Abs(nums[0] * 2 - i) < dp[0, i] ? nums[0] : dp[0, i];
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < sum + 1; j++)
                {
                    // 如果拿了这个数超过了 j 那就直接用左上角的数
                    if (j - nums[i] * 2 < 0) dp[i, j] = dp[i - 1, j];
                    else
                    {
                        dp[i, j] = Math.Abs(dp[i - 1, j] * 2 - j) < Math.Abs((dp[i - 1, j - 1] + nums[i]) * 2 - j) ? dp[i - 1, j] : dp[i - 1, j - 1] + nums[i];
                        if (dp[i, j] * 2 -sum == 0) return true;
                    }
                }
            }
            return false;
        }
    }
}
