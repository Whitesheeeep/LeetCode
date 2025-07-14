using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode416_CanPartition_middle
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            foreach (int i in nums) sum += i;
            if (sum % 2 == 1) return false;
            // dp[i][j] 表示：从 0 ~ i 中选取的数字的总和 * 2 与 j 的距离的最小值，带正负号
            int[,] dp = new int[nums.Length, sum / 2 + 1];

            // 初始化直接使用 0 即可

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < sum / 2 + 1; j++)
                {
                    if (j - nums[i] < 0) dp[i, j] = dp[i - 1, j];
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - nums[i]] + nums[i]);
                }
            }

            if (dp[nums.Length - 1, sum / 2] == sum / 2) return true;
            return false;
        }

        public bool CanPartitionSingle(int[] nums)
        {
            int sum = 0;
            foreach (int i in nums) sum += i;
            if (sum % 2 == 1) return false;

            // 01 背包问题，dp 数组使用一维进行处理
            // 表示每一个物品，背包空间为 j 时，选择那几个0 到本层的数字能够获得最大元素和
            // 但是实际上此时价值也是对应的重量，就刚好就是对应的值
            // 也就赚换成了能否刚好填充背包
            // 也就是只有两种情况：1. 刚好填充 2. 没有填充 （填充过头不可能，因为重量与价值等价，而重量不能超过背包，因此价值也不可能超过）
            int[] dp = new int[sum / 2 + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = sum / 2; j >= nums[i]; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);
                }
            }

            if (dp[sum / 2] == sum / 2) return true;
            return false;
        }
    }
}
