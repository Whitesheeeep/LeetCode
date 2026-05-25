#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int maxLines(vector<int>& nums1, vector<int>& nums2){
    vector<vector<int>> dp(nums1.size() + 1, vector<int>(nums2.size() + 1, 0));

    int result = 0;
    for (int i = 1; i <= nums1.size(); i++) {
        for (int j = 1; j <= nums2.size(); j++) {
            if (nums1[i-1] == nums2[j-1]) {
                dp[i][j] = dp[i-1][j-1] + 1;
            }
            else {
                dp[i][j] = max(dp[i-1][j], dp[i][j-1]);
            }
            result = max(result, dp[i][j]);
        }
    }
    return result;
}


int testNum = 1;
void test(vector<int> nums1, vector<int> nums2){
    cout << "test Start: " << testNum << endl;
    cout << "res " << endl;
    cout << maxLines(nums1, nums2);
    cout << "test End: " << testNum << endl << endl;;
}

int main(){

}
