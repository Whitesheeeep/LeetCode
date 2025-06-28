using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode96_NumTrees_middle
    {
        public int NumTrees(int n)
        {
            // dp 的意义，dp[i] 表示：节点值为 i 时候的二叉搜索树的种数
            int[] dp = new int[n + 1];
            // dp 初始化
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                // j 表示以哪一个数字为 root 的时候
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j] == 0? dp[j - 1] + dp[i - j]:dp[j - 1] * dp[i - j];
                }
            }
            return dp[n];
        }
    }
}
