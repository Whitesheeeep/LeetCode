using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.DoublePointer
{
    public class LeetCode977
    {
        public int[] SortedSquares(int[] nums)
        {
            int[] results = new int[nums.Length];
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                if(Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    results[right - left] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    results[right - left] = nums[right] * nums[right];
                    right--;
                }
            }
            return results;
        }
    }
}