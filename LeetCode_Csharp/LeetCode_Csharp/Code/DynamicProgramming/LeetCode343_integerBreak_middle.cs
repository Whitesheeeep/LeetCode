using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode343_integerBreak_middle
    {
        public int IntegerBreak(int n)
        {
            // dp 为一维的，dp[i] 表示：拆分数字 i，可以得到的最大乘积为 dp[i]
            int[] dp = new int[n + 1];
            // 初始化 dp，0 和 1 没有初始化意义，因此直接从 2 开始
            dp[2] = 1;
            // dp 转移方程 以及 确定遍历顺序：从小往大遍历，因为拆分大数时，只能由比它更小的数构成
            for (int i = 3; i <= n; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    dp[i] = Math.Max((j * (i - j)), Math.Max(j * dp[i - j], dp[i]));
                }
                /* 如果要用 for(int j = ; j<=i/2; j++)
                    需要注意这里 j = 1 而不是上面的 j = 2，反例 ：3
                 */
            }
            return dp[n];



        }
    }
}
