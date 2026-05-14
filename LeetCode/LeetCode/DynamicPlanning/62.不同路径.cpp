#include <iostream>
#include <vector>

using namespace std;

int findPaths(int m, int n){
    // f(x, y) 表示到达 x, y 有多少不同的路径
    // 情况：
    // 1. 从上面来的，f(x, y - 1)
    // 2. 从左边来的，f(x - 1, y)
    vector<vector<int>> paths(m, vector<int>(n, 0));
    for (int i = 0; i < n; i++) {
        paths[0][i] = 1;
    }

    for (int i = 0; i < m; i++) {
        paths[i][0] = 1;
    }

    for (int i = 1; i < m; i++) {
        for (int j = 1; j < n; j++) {
            paths[i][j] = paths[i - 1][j] + paths[i][j - 1];
        }
    }
    return paths[m - 1][n - 1];
}

int main(){
    while (true)
    {int n, m;
    cin >> n >> m;
    cout << findPaths(m, n) << endl;}
}
