using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode45_Jump_middle
    {
        // 相较于跳 1，跳 2 要求返回最小的跳跃次数
        // 并且跳 2 必能达到最后一个索引位置，无序判断是否能够跳跃到最后一位索引
        public int Jump(int[] nums)
        {
            if (nums.Length == 1) return 0;
            int count = 0;
            // 初始化
            int cover = nums[0];
            int temp = cover;// 指向能移动到的最大位置
            for (int i = 1; i < nums.Length; i++)
            {
                // 处理逻辑
                if(nums[i] + i > temp)
                {
                    temp = nums[i] + i;
                }
                if(i >= cover || i == nums.Length - 1) // 跳
                {
                    cover = temp;
                    count++;
                }
            }
            return count;
        }
    }
}
