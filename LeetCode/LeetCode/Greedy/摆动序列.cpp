#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

class Solution{
public:
    int countWiggle(vector<int>& nums){
        if (nums.size() <= 1) return 1;

        int res = 1;
        int prediff = 0, curdiff = 0;

        for (int i = 0; i < nums.size() - 1; i++){
            curdiff = nums[i + 1] - nums[i];
            if ((prediff <= 0 && curdiff > 0) || (prediff >= 0 && curdiff < 0))
            {
                res++;
                prediff = curdiff;
            }
        }

        return res;
    }

    int wiggleMaxLength(vector<int>& nums)
    {
        return countWiggle(nums);
    }
};

int main()
{
    // int n,k;
    // cin >> n;
    // vector<int> nums;
    // while (n--) {
    //     cin >> k;
    //     nums.push_back(k);
    // }

    vector<int> nums {33,53,12,64,50,41,45,21,97,35,47,92,39,0,93,55,40,46,69,42,6,95,51,68,72,9,32,84,34,64,6,2,26,98,3,43,30,60,3,68,82,9,97,19,27,98,99,4,30,96,37,9,78,43,64,4,65,30,84,90,87,64,18,50,60,1,40,32,48,50,76,100,57,29,63,53,46,57,93,98,42,80,82,9,41,55,69,84,82,79,30,79,18,97,67,23,52,38,74,15};
    cout << nums.size() << endl;


    Solution* sln = new Solution();
    cout << sln->wiggleMaxLength(nums);
}
