using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode1005_LargestSumAfterKNugations_Easy
    {
        // 更加容易理解的写法。就不必像后面的写法想这么多细节。
        public int LargestSumAfterKNegations(int[] nums, int k)
        {
            Array.Sort(nums, (a, b) => -Math.Abs(a).CompareTo(Math.Abs(b))); // 升序排列
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0 && k > 0) // 负数变成正数
                {
                    nums[i] = -nums[i];
                    k--;
                }
            }
            if(k % 2 == 1) nums[nums.Length - 1] *= -1; // 如果 k 还剩下奇数次，最后一个数变成负数
            return nums.Sum(); // 求和
        }

        public int LargestSumAfterKNegations2(int[] nums, int k)
        {
            Array.Sort(nums);
            int index = 0; // 记录距离 0 最近的 index
            for (int i = 0; i < nums.Length && k > 0; i++, k--)
            {
                if (nums[i] > 0) //到正数两种情况：1. 一开始就是正数 2. 有负数，但是负数是顺着往下的，有没有 0 的限制，那就到正数了
                {
                    if(i == 0)   
                    {
                        nums[i] = k % 2 == 0 ? nums[i] : -nums[i];
                    }
                    else
                    {
                        if(nums[i-1] > nums[i])
                        {
                            nums[i] = k % 2 == 0 ? nums[i] : -nums[i];
                            index = i;
                        }
                        else 
                        {
                            nums[i - 1] = k % 2 == 0 ? nums[i - 1] : -nums[i -1];
                            index = i - 1;
                        }
                    }
                    break;
                }
                else if (nums[i] == 0)
                {
                    break;
                }
                else
                {
                    if(i == nums.Length - 1)
                    {
                        nums[i] = k % 2 == 0 ? nums[i] : -nums[i];
                        break;
                    }
                    nums[i] = -nums[i];
                }
            }



            return nums.Sum();
        }
    }
}
