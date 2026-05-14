#include <iostream>
#include <vector>

using namespace std;

int findPaths(vector<vector<int>> &grid) {
    // f(x, y) 表示到达 x, y 有多少不同的路径
    // 情况：
    // 1. 从上面来的，f(x, y - 1)
    // 2. 从左边来的，f(x - 1, y)
    vector<vector<int>> paths(grid.size(), vector<int>(grid[0].size(), 0));

    for (int i = 0; i < grid.size(); i++) {
        if (!grid[i][0]) {
            paths[i][0] = 1;
        } else {
            break;
        }
    }
    for (int i = 0; i < grid[0].size(); i++) {
        if (!grid[0][i]) {
            paths[0][i] = 1;
        } else {
            break;
        }
    }

    for (int row = 1; row < grid.size(); row++) {
        for (int col = 1; col < grid[0].size(); col++) {
            if (grid[row][col]) {
                continue;
            }
            if (!grid[row - 1][col] && !grid[row][col - 1]) {
                paths[row][col] = paths[row - 1][col] + paths[row][col - 1];
            } else {
                paths[row][col] = grid[row - 1][col] ? paths[row][col - 1]
                                                     : paths[row - 1][col];
            }
        }
    }
    return paths[grid.size() - 1][grid[0].size() - 1];
}

int main() {
    /* while (true)
    {int n, m;
    cin >> n >> m;
    cout << findPaths(m, n) << endl;} */

    vector<vector<int>> test1{{0}};
    int a = findPaths(test1);
    cout << a << endl;

    vector<vector<int>> test2{{0, 1}, {0, 0}};
    int b = findPaths(test2);
    cout << b << endl;

    vector<vector<int>> test3{{0, 0, 0}, {0, 1, 0}, {0, 0, 0}};
    int c = findPaths(test3);
    cout << c << endl;
}
