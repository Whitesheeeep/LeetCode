using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode134_CanCompleteCircuit_middle
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int[] count_Furthest = new int[gas.Length];
            int maxCount = 0, tempCount = 0; // maxCount 记录最多走出去几站，tempCount 记录现在走出去几站了
            int index = 0/* , tempIndex = 0 */;// index 用于记录走得最多的车站的索引，tempIndex 用于锚定开始走的车站
            int rmin_gas = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                int rmin_gas_here = gas[i - 1] - cost[i];
                if (rmin_gas_here > 0) // 可以往前走了
                {
                    int tempIndex = i;
                    while(tempCount < gas.Length)
                    {
                        tempCount++;
                        tempIndex++;
                        if(tempIndex == gas.Length) tempIndex = 0;
                        rmin_gas_here += gas[tempIndex] - cost[tempIndex];
                        if(rmin_gas_here <= 0)
                        {
                            if(tempCount == gas.Length) return tempIndex - tempCount < 0 ? gas.Length - tempIndex + tempCount : tempIndex - tempCount;
                            break;
                        }
                    }
                }
            }

            return -1;
        }
    }
}
