public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        if(nums.Length == 0) return 0;
        else
        {
            if(target < nums[0]) return 0;
            else if(target > nums[nums.Length - 1]) return nums.Length;
        }
        // binary search       
        int left = 0;
        int right = nums.Length;
        int mid;
        while (left < right)
        {
            mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;
            else if (nums[mid] < target) left = mid + 1;
            else right = mid;
        }
        return left;
    }
}