#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

int findMinArrowShots(vector<vector<int>>& points){
    // 排序
    sort(points.begin(), points.end(), [](vector<int>& points1, vector<int>& points2){
        if (points1[0] == points2[0]) {
            return points1[1] < points2[1];
        }
        return points1[0] < points2[0];
    });
    
    int res = 1;
    int left = INT_MIN, right = INT_MAX;
    for (int i = 0; i < points.size(); i++) {
        int start = points[i][0], end = points[i][1];
        if (start > right) {
            res++;
            left = start;
            right = end;
        }
        else {
            // 缩小窗口
            left = start;
            right = min(right, end);
        }
    }

    return res;
}

int main(){
    // int n, start, end;
    // cin >> n;
    // vector<vector<int>> points;
    // while (n--) {
    //     cin >> start >> end;
    //     points.push_back({start, end});
    // }

    vector<vector<int>> test1{{1,2}, {2,3},{3,4}};
    vector<vector<int>> test2{{1,2}, {2,3},{4,4}};
    cout << (findMinArrowShots(test1) == 2);
    cout << (findMinArrowShots(test2) == 2);


}
