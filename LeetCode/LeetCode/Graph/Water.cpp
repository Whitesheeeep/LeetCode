#include <iostream>
#include <vector>
#include <queue>
#include <unordered_set>

using namespace std;

int dir[4][2] = {0, 1, 1, 0, 0, -1, -1, 0};

// 逆流来找到答案
void waterFlow(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int curX, int curY)
{
    // if (visited[curX][curY]) return;

    // visited[curX][curY] = true;

    // for (int i = 0; i < 4; i++) {
    //     int nextx = curX + dir[i][0];
    //     int nexty = curY + dir[i][1];
    //     if (nextx < 0 || nextx >= grid.size() || nexty < 0 || nexty >= grid[0].size()) continue;
    //     if (grid[curX][curY] > grid[nextx][nexty]) continue; // 注意：这里是从低向高遍历

    //     waterFlow (grid, visited, nextx, nexty);
    // }
    // return;
    if(visited[curX][curY]) return;
    
    queue<pair<int, int>> nodeQueue;
    nodeQueue.push({curX, curY});
    visited[curX][curY] = true;
    while (!nodeQueue.empty())
    {
        auto node = nodeQueue.front();
        nodeQueue.pop();
        for (int i = 0; i < 4; i++)
        { 
            int nextx = node.first + dir[i][0];
            int nexty = node.second + dir[i][1];
            // 避开的条件
            if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size() || grid[nextx][nexty] < grid[node.first][node.second] || visited[nextx][nexty])
                continue;
            // 判断是否达到条件
            visited[nextx][nexty] = true;
            nodeQueue.push({nextx,nexty});
        }
    }
}



int main()
{
    // 输入
    int n, m;
    cin >> n >> m;

    vector<vector<int>> grid(n, vector<int>(m, 0));
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cin >> grid[i][j];
        }
    }

    vector<vector<bool>> firstBorder(n, vector<bool>(m, false));
    vector<vector<bool>> secondBorder(n, vector<bool>(m, false));
    // 第一个边界查找
    for (int i = 0; i < n; i++)
    {
        waterFlow(grid, firstBorder, i, 0);
        waterFlow(grid, secondBorder, i, m - 1);
    }
    for (int j = 0; j < m; j++)
    {
        waterFlow(grid, firstBorder, 0, j);
        waterFlow(grid, secondBorder, n - 1, j);
    }

    // 输出
    for(int i = 0; i < n; i++)
    {
        for(int j =0; j < m; j++)
        {
            if(firstBorder[i][j] && secondBorder[i][j])
                cout << i << " " << j << endl;
        }
    }
}
