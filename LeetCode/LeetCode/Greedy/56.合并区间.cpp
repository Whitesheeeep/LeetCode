#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

vector<vector<int>> merge(vector<vector<int>>& intervals){
    sort(intervals.begin(), intervals.end(), [](vector<int>& a, vector<int>& b){
        if (a[0] == b[0]) {
            return a[1] < b[1];
        }
        return a[0] < b[0];
    });

    vector<vector<int>> res;
    int left = intervals[0][0], right = intervals[0][1];
    for (int i = 1; i < intervals.size(); i++) {
        int start = intervals[i][0], end = intervals[i][1];
        if (start > right) {
            res.push_back({left, right});
            left = start;
            right = end;
        }
        else {
            right = max(right, end);
        }
    }
    res.push_back({left, right});
    // for (int i = 0; i < res.size(); i++) {
    //     cout << "res: " << res[i][0] << " " << res[i][1] << endl;
    // }
    return res;
}

int main(){
    vector<vector<int>> test1{{1,2}, {2,3}};
    cout << (merge(test1) == vector<vector<int>>{{1,3}});
}
