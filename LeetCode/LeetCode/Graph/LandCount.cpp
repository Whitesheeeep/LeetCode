#include <iostream>
#include <vector>
#include <queue>

using namespace std;

int countIslandBFS(const vector<vector<int>> &grid, int n, int m);
void findIslandDFS(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int n, int m);
void findIslandBFS(const vector<vector<int>> &grid, vector<vector<int>> &visited, int n, int m);
int islandCount(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int curX, int curY);

int dir[4][2] = {0, 1, 1, 0, 0, -1, -1, 0};

int main()
{
    // 获取岛屿
    int n, m; // n 行 m 列
    cin >> n >> m;

    // 表格
    vector<vector<int>> grid(n, vector<int>(m, 0));

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cin >> grid[i][j];
        }
    }

    vector<vector<bool>> visited(n, vector<bool>(m, false));
    int res = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (!visited[i][j] && grid[i][j] == 1)
            {
                res += islandCount(grid, visited, i , j);
                cout<< res << endl;
            }
        }
    }

    cout << res << endl;

    return 0;
}

/// @brief 计算有多少独立岛屿
/// @param grid 使用的地图
/// @param n n 行
/// @param m m 列
/// @return 独立岛屿的数量
int countIslandBFS(const vector<vector<int>> &grid, int n, int m)
{
    vector<vector<bool>> visited(n, vector<bool>(m, false));
    int res(0);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (grid[i][j] && !visited[i][j])
            {
                visited[i][j] = true;
                res++;
                findIslandDFS(grid, visited, i, j);
            }
        }
    }
    return res;
}

int islandCount(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int curX, int curY)
{
    int res = 0;
    queue<pair<int, int>> nodeQueue;
    nodeQueue.push({curX, curY});
    visited[curX][curY] = true;
    bool isIsland = true;
    if(curX == 0 || curX == grid.size() -1 || curY == 0 || curY == grid[0].size() -1)
    {
        res = 0;
        isIsland = false;
    }
    else
        res++;
    while (!nodeQueue.empty())
    {
        auto node = nodeQueue.front();
        nodeQueue.pop();
        for (int i = 0; i < 4; i++)
        {
            int nextx = node.first + dir[i][0];
            int nexty = node.second + dir[i][1];
            if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size() || grid[nextx][nexty] == 0 || visited[nextx][nexty])
                continue;
            nodeQueue.push({nextx, nexty});
            visited[nextx][nexty] = true;
            if(grid[nextx][nexty] == 1 && isIsland)
            {
                if ((nextx == 0 || nexty == 0 || nextx == grid.size() - 1 || nexty == grid[0].size() - 1)) // 如果陆地遍历到边缘了
                    {
                        res = 0;
                        isIsland = false;
                    }
                else
                    res++;
            }
            
        }
    }
    return res;
}

void findIslandDFS(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int n, int m)
{
    int maxRow = grid.size();
    int maxColume = grid[0].size();

    for (int i = 0; i < 4; i++)
    {
        int nextx = n + dir[i][0];
        int nexty = m + dir[i][1];
        if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size() || !grid[nextx][nexty] || visited[nextx][nexty])
            continue;
        visited[nextx][nexty] = true;
        // path.push_back({n,m});
        findIslandDFS(grid, visited, nextx, nexty);
    }
}

void findIslandBFS(const vector<vector<int>> &grid, vector<vector<int>> &visited, int n, int m)
{
    queue<pair<int, int>> nodeQueue;
    nodeQueue.push({n, m});
    visited[n][m] = true;
    while (!nodeQueue.empty())
    {
        auto node = nodeQueue.front();
        nodeQueue.pop();
        for (int i = 0; i < 4; i++)
        {
            int nextx = node.first + dir[i][0];
            int nexty = node.second + dir[i][1];
            if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size() || !grid[nextx][nexty] || visited[nextx][nexty])
                continue;
            visited[nextx][nexty] = true;
            nodeQueue.push({nextx, nexty});
        }
    }
}
