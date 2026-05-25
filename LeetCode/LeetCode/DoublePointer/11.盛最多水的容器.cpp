#include <iostream>
#include <vector>

using namespace std;

int maxWater(vector<int>& height){
    if (height.size() <= 1) {
        return 0;
    }

    int res = 0;
    int left = 0, right = height.size() - 1;
    while (left < right) {
        int temp;
        if (height[left] < height[right]) {
            temp = (right - left) * height[left];
            left++;
        }
        else {
            temp = (right - left) * height[right];
            right--;
        }
        res = max(res, temp);
        
    }
    return res;
}

void test(vector<int> nums){
    cout << "Test Start ===========" << endl;
    cout << maxWater(nums) << endl;
    cout << "Test End ===========" << endl << endl;
}

int main(){
    test(vector<int>{2,4,1,1,4,1,2});
}
