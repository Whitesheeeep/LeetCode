using System;

namespace LeetCode_Csharp.Code.DoublePointer
{
    public class LeetCode27_RemoveElement_Easy
    {
        // 时间复杂度：O(n)
        // 空间复杂度：O(1)
        public int RemoveElement(int[] nums, int val)
        {
            // 双指针：快指针遍历数组，慢指针指向下一个非 val 的元素
            int slow = 0;
            for(int fast = 0; fast < nums.Length; fast++)
            {
                if(nums[fast] != val)
                {
                    nums[slow++] = nums[fast];
                }
                
            }
            return slow;
        }
    }
}
