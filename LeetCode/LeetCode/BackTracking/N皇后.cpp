#include <cstdlib>
#include <iostream>
#include <string>
#include <unordered_map>
#include <vector>

using namespace std;

class Solution{
public:
    int num;
    void backTracking(int row, unordered_map<int, int>& used, vector<vector<string>>& res, vector<string>& path)
    {
        if (row == num)
        {
            res.push_back(path);
            return;
        }

        for (int col = 0; col < num; col++) {
            if (used.find(col) != used.end()) continue;
            // 判断斜方向
            bool flag = false;
            for (auto kvp : used) {
                if (abs(kvp.first - col) == row - kvp.second)
                {
                    flag = true;        
                    break;
                }
            }
            if (flag) continue;

            path[row][col] = 'Q';
            used[col] = row;
            backTracking(row + 1, used, res, path);
            path[row][col] = '.';
            used.erase(col);
        }
    }

    vector<vector<string>> solveNQueens(int n){
        num = n;

        vector<vector<string>> res;
        string str;
        for (int i = 0; i < n; i++) {
            str += ".";
        }
        vector<string> path(n, str);
        unordered_map<int, int> used; // 先 col，再 row

        backTracking(0, used, res, path);

        return res;
    }
};


int main()
{
    int n;
    cin >> n;
    Solution* sln = new Solution();

    auto res = sln->solveNQueens(n);

    for (auto vec : res) {
        for (string str : vec) {
            cout << str << endl;
        }
        cout << endl;
    }
}
