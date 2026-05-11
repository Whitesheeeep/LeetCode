#include <algorithm>
#include <climits>
#include <iostream>
#include <vector>

using namespace std;

int eraseOverlapIntervals(vector<vector<int>>& intervals){
    int res = 0;

    sort(intervals.begin(), intervals.end(), [](const vector<int>& interval1, const vector<int>& interval2){
        if (interval1[0] == interval2[0]) {
            return interval1[1] < interval2[1];
        }
        return interval1[0] < interval2[0];
    });

    int left = intervals[0][0], right = intervals[0][1];
    for (int i = 1; i < intervals.size(); i++) {
        int start = intervals[i][0], end = intervals[i][1];
        if (start >= right) {
            left = start;
            right = end;
        }
        else {
            res++;
            left = start;
            right = min(end, right);
        }
    }

    return res;
}

int main(){
    // int n, start, end;
    // cin >> n;
    // vector<vector<int>> intervals;
    // while (n--) {
    //     cin >> start >> end;
    //     intervals.push_back({start, end});
    // }

    vector<vector<int>> test1{{1,2}, {2,3}};
    cout << (eraseOverlapIntervals(test1) == 0);

    vector<vector<int>> test2{{1,2}, {1,3}};
    cout << (eraseOverlapIntervals(test2) == 1);

    vector<vector<int>> test3{{1,2}, {1,3}, {2,4}};
    cout << (eraseOverlapIntervals(test2) == 1);
}
