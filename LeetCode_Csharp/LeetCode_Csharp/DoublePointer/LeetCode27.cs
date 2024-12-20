using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp
{
    public class LeetCode27
    {
        //双指针删除元素：快指针遍历数组，慢指针记录非val的元素
        //或者说，快指针指向的元素不等于val时，慢指针指向新数组的位置坐标
        public int RemoveElement(int[] nums, int val)
        {
            int slow = 0;
            for(int fast = 0; fast < nums.Length; fast ++)
                if(nums[fast] != val) nums[slow++] = nums[fast];
            return slow;
        }
    }
}