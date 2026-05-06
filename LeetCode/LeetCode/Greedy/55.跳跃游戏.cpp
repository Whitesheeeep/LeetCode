#include <iostream>
#include <vector>

using namespace std;

bool canJump(vector<int>& nums){
	int left = 0, right = 0;

	while (true) {
		int maxIndex = 0;
		for (int i = left; i <= right; i++) {
			maxIndex = max(maxIndex, i + nums[i]);
		}
		
		if (maxIndex >= nums.size() - 1) {
			return true;
		}
		else if (maxIndex <= right) {
			break;
		}

		// 更新窗口
		left = right + 1;
		right = maxIndex;
	}

	return false;
}

bool canJump_Dynamic(vector<int>& nums)
{
	// dp[i] 表示 
}

int  main(){
	int n, k;
	cin >> n;
	vector<int> nums;
	while (n--) {
		cin >> k;
		nums.push_back(k);
	}
	
	cout << canJump(nums);
}
