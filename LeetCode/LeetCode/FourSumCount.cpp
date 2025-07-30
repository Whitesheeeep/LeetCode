// #include <vector>
// #include <unordered_set>
// #include <unordered_map>
//
// using namespace std;
//
// class Solution {
// public:
// 	int fourSumCount(vector<int>& nums1, vector<int>& nums2, vector<int>& nums3, vector<int>& nums4) {
// 		int res = 0;
// 		unordered_map<int, int> firstSum;
// 		unordered_map<int, int> secondSum;
// 		int len = nums1.size();
// 		for (int i = 0; i < len; i++)
// 		{
// 			for (int j = 0; j < len; j++)
// 			{
//
// 				firstSum[nums1[i] + nums2[j]] ++;
// 			}
// 		
// 		}
//
// 		for (int i : firstSum)
// 		{
// 			if (secondSum.count(-i)) res++;
// 		}
//
// 		return res;
// 	}
// };