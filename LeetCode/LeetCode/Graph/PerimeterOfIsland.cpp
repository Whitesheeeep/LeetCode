#include <iostream>
#include <vector>
#include <queue>

using namespace std;

int dir[4][2] = {0, 1, 1, 0, 0, -1, -1, 0};

int countPerimeter(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int i, int j)
{
    int res{0};
    queue<pair<int, int>> nodeQueue;
    nodeQueue.push({i, j});
    visited[i][j] = true;
    while (!nodeQueue.empty())
    {
        auto node = nodeQueue.front();
        nodeQueue.pop();

        for (int i = 0; i < 4; i++)
        {
            int nextx = node.first + dir[i][0];
            int nexty = node.second + dir[i][1];
            if (nextx < 0 || nexty < 0 || nextx >= grid.size() || nexty >= grid[0].size() || grid[nextx][nexty] == 0)
            {
                res++;
                continue;
            }
            if (visited[nextx][nexty])
                continue;

            nodeQueue.push({nextx, nexty});
            visited[nextx][nexty] = true;
        }
    }

    return res;
}

int countPerimeterDFS(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int x, int y)
{
    int res = 0;
    if (visited[x][y])
        return 0;
    if (x < 0 || y < 0 || x >= grid.size() || y >= grid[0].size() || grid[x][y] == 0)
    {
        return 1;
    }

    visited[x][y] = true;
    for (int i = 0; i < 4; i++)
    {
        int nextx = x + dir[i][0];
        int nexty = y + dir[i][1];
        int count = countPerimeterDFS(grid, visited, nextx, nexty);
        res += count;
    }
    return res;
}

// 此题岛屿只有一个
int main()
{
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
    vector<vector<bool>> visited(n, vector<bool>(m, false));

    int perimeter = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (grid[i][j] && !visited[i][j])
            {
                perimeter = countPerimeterDFS(grid, visited, i, j);
                // cout << perimeter <<endl;
            }
        }
    }

    cout << perimeter << endl;

    return 0;
}
