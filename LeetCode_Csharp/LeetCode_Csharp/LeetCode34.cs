using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp
{
    public partial class Solution
    {
        //Solution 1
        public int[] SearchRange(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    int start = mid;
                    int end = mid;
                    //找到之后顺着mid向两边找，但是如果整个数组都是target的话，复杂度会变成O(n)
                    while (start > 0 && nums[start - 1] == target) start--;
                    while (end < nums.Length - 1 && nums[end + 1] == target) end++;
                    return new int[] { start, end };
                }
                else if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return [-1, -1];
        }

        //Solution 2
        /*进行两次二分查找，分别找到左边界和右边界，但是相较于方法一，
         *这种方法选择在找到 target 后，继续采用二分法向左向右搜索边界，时间复杂度为 O(logn)。  
         */
        public int[] SearchRange_2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int first = -1;
            int last = -1;

            bool flag = true;
            int temp = -1;
            // 找第一个等于target的位置
            while (left <= right) {
                int middle = (left + right) / 2;
                if (nums[middle] == target) {
                    first = middle;
                    right = middle - 1; //重点
                    if(flag){
                        temp = middle;
                        flag = false;
                    }
                } else if (nums[middle] > target) {
                    right = middle - 1;
                } else {
                    left = middle + 1;
                }   
            }

            // 最后一个等于target的位置
            left = 0;
            right = temp;
            while (left <= right) {
                int middle = (left + right) / 2;
                if (nums[middle] == target) {
                    last = middle;
                    left = middle + 1; //重点
                } else if (nums[middle] > target) {
                    right = middle - 1;
                } else {
                    left = middle + 1;
                }
            }

            return new int[]{first, last};
        }


    }
}