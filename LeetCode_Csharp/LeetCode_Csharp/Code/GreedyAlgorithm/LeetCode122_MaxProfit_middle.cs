using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode122_MaxProfit_middle
    {
        /*
        本题的贪心：
        我们从 i 到 0 的的利润可以拆开成每一天的利润，然后对小于的 0的不收集，就当做没有购买
        然后只收集大的，这样就能找到局部的最优解，从而退出全局的最优解。
        */
        public int MaxProfit(int[] prices)
        {
            int bonus = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                if(prices[i] >  prices[i-1]) bonus += prices[i] - prices[i-1];
            }
            return bonus;
        }
    }
}
