#include <iostream>
#include <vector>
#include <queue>
#include <unordered_map>
#include <unordered_set>

using namespace std;

int dir[4][2] = {0, 1, 1, 0, 0, -1, -1, 0};

void maxLandCountBFS(vector<vector<int>> &grid, vector<vector<bool>> &visited, unordered_map<int, int> &landSize, int x, int y, const int marker)
{
    if (grid[x][y] == 0)
        return;

    queue<pair<int, int>> nodeQueue;
    nodeQueue.push({x, y});
    visited[x][y] = true;
    landSize[marker]++;
    grid[x][y] = marker;
    while (!nodeQueue.empty())
    {
        auto node = nodeQueue.front();
        nodeQueue.pop();
        for (int i = 0; i < 4; i++)
        {
            int nextx = node.first + dir[i][0];
            int nexty = node.second + dir[i][1];
            if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size() || visited[nextx][nexty] || grid[nextx][nexty] == 0)
                continue;
            nodeQueue.push({nextx, nexty});
            visited[nextx][nexty] = true;
            landSize[marker]++;
            grid[nextx][nexty] = marker;
        }
    }
}

void maxLandCountDFS(vector<vector<int>> &grid, vector<vector<bool>> &visited, unordered_map<int, int> &landSize, int x, int y, const int marker)
{
    if(visited[x][y] || !grid[x][y]) return;
    visited[x][y] = true;
    grid[x][y] = marker;
    landSize[marker]++;

    for(int i = 0;i < 4; i++)
    {
        int nextx = x + dir[i][0];
        int nexty = y + dir[i][1];
        if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size())
            continue;
        maxLandCountDFS(grid, visited, landSize, nextx, nexty, marker);
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

    // 处理
    int maxLandCount = 0;
    vector<vector<bool>> visited(n, vector<bool>(m, false));
    /// first - 岛屿编号, second - 岛屿大小
    unordered_map<int, int> landSize;
    int marker = 1;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (grid[i][j] == 1 && !visited[i][j])
            {
                maxLandCountDFS(grid, visited, landSize, i, j, marker);
                marker++;
            }
        }
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << grid[i][j] << " ";
            if (j == m - 1)
                cout << endl;
        }
    }

    unordered_set<int> visitedMarker;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (grid[i][j] == 0 && !visited[i][j])
            {
                visitedMarker.clear();
                int count = 1;
                visited[i][j] = true;
                for (int k = 0; k < 4; k++)
                {
                    int nextx = i + dir[k][0];
                    int nexty = j + dir[k][1];
                    if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size() || grid[nextx][nexty] == 0)
                        continue;
                    if(visitedMarker.find(grid[nextx][nexty]) == visitedMarker.end())
                    {
                        visitedMarker.insert(grid[nextx][nexty]);
                        count += landSize[grid[nextx][nexty]];
                    }
                }
                maxLandCount = max(maxLandCount, count);
            }
            else if (grid[i][j])
                maxLandCount = max(maxLandCount, landSize[grid[i][j]]);
        }
    }

    // 输出
    cout << maxLandCount << endl;

    return 0;
}
