#include <iostream>
#include <vector>

class LeetCode438_FindAnagrams_middle {
public:
    int SearchInsert(std::vector<int>& nums, int target);
};

int LeetCode438_FindAnagrams_middle::SearchInsert(std::vector<int>& nums, int target)
{
    if (nums.size() == 0) return 0;
    else
    {
        if (target < nums[0]) return 0;
        else if (target > nums[nums.size() - 1]) return nums.size();
    }
    // binary search       
    int left = 0;
    int right = nums.size();
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