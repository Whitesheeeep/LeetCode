#include <iostream>
#include <unordered_map>
#include <utility>
#include <vector>

using namespace std;

template<typename T>
void debugVec(vector<T> vec)
{
    for (T a : vec) {
        cout << a << " ";
    }
    cout << endl;
}

template<typename T1, typename T2>
void debugMap(unordered_map<T1, T2> map)
{
    for (pair<T1, T2> p : map) {
        cout << p.first << "  " << p.second << " ";
    }
    cout << endl;
}

int getTarget(vector<int>& nums1, vector<int>& nums2, vector<int>& nums3, vector<int>& nums4)
{
    // key: 和， value：构成这个和的组合数
    unordered_map<int, int> sumMap_1;
    // 预计算 nums1 + nums2
    for (int i = 0; i < nums1.size(); i++) {
        for (int j = 0; j < nums2.size(); j++) {
            int sum = nums1[i] + nums2[j];
            // 找到了
            if (sumMap_1.find(sum) != sumMap_1.end()) {
                sumMap_1[sum]++;
            }
            else {
                sumMap_1[sum] = 1;
            }
        }
    }

    // debug vec
    // debugMap(sumMap_1);

    int res= 0;
    for (int i = 0; i < nums3.size(); i++) {
        for (int j = 0; j < nums4.size(); j++) {
            int sum = nums3[i] + nums4[j];
            if (sumMap_1.find(-sum) != sumMap_1.end())
            {
                res += sumMap_1[-sum];
            }
        }
    }
    return res;
}

int main(){

}
