#include <algorithm>
#include <iostream>
#include <unordered_map>
#include <vector>

using namespace std;

int longestSequence(vector<int> &nums) {
  // key: 数字，value：构成的长度, 0 表示比key 大的连续序列长度，1 表示比 key 小的连续序列长度
  unordered_map<int, vector<int>> numSequenceMap;
  int res = 1;
  for (int i = 0; i < nums.size(); i++) {
    if (numSequenceMap.find(nums[i]) == numSequenceMap.end()) {
        numSequenceMap[nums[i]] = {0,0};
    }
    if (numSequenceMap.find(nums[i] - 1) == numSequenceMap.end()) {
        numSequenceMap[nums[i]][1] = 1;
    }
    else {
        numSequenceMap[nums[i]][1] = numSequenceMap[nums[i] - 1][1] + 1;
        // res = max(res, numSequenceMap[nums[i]][1]);
    }

    if (numSequenceMap.find(nums[i] + 1) == numSequenceMap.end()) {
        numSequenceMap[nums[i]][0] = 1;
    }
    else {
        numSequenceMap[nums[i]][0] = numSequenceMap[nums[i] + 1][0] + 1;
    }

    if (numSequenceMap.find(nums[i] - 1) != numSequenceMap.end()) {
        numSequenceMap[nums[i] - 1][0] += numSequenceMap[nums[i]][0]; 
        res = max(numSequenceMap[nums[i] - 1][0], res);
    }
    if (numSequenceMap.find(nums[i] + 1) != numSequenceMap.end()) {
        numSequenceMap[nums[i] + 1][1] += numSequenceMap[nums[i]][1]; 
        res = max(numSequenceMap[nums[i] + 1][1], res);
    }

    res = max(res, numSequenceMap[nums[i]][0] + numSequenceMap[nums[i]][1] - 1);

    for (auto p : numSequenceMap) {
        cout << p.first << " " << "biggerLen: " << p.second[0] << " smaller: " << p.second[1] << endl;
    }
    cout << "==" << endl;
  }
  return res;
}

int testCount = 1;
void test(vector<int> nums) {
  cout << "Test Start " << testCount << "==============" << endl;
  cout << longestSequence(nums) << endl;
  cout << "Test End " << testCount << "==============" << endl << endl;
}

int main() {
  test(vector<int>{1, 2, 3, 4});
  test(vector<int>{4, 3, 2, 1});
  test(vector<int>{0,3,7,2,5,8,4,6,0,1});
}
