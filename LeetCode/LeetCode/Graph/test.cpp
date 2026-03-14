#include <iostream>
#include <vector>
#include <queue>

using namespace std;

int dir[4][2] = {-1, 0, 0, -1, 1, 0, 0, 1};
vector<pair<int, int>> res;


void countLandArea(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int x, int y)
{
    queue<pair<int, int>> que;
    que.push({x, y});
    visited[x][y] = true;
    while (!que.empty())
    {
        auto cur = que.front();
        que.pop();
        for (int i = 0; i < 4; i++)
        {
            int nextx = cur.first + dir[i][0];
            int nexty = cur.second + dir[i][1];
            if (nextx < 0 || nextx >= grid.size() || nexty < 0 || nexty >= grid[0].size() || grid[nextx][nexty] == 0 || visited[nextx][nexty])
                continue;
            visited[nextx][nexty] = true;
            que.push({nextx, nexty});
        }
    }
}

int countLandAreaBfs(const vector<vector<int>> &grid, vector<vector<bool>> &visited, int x, int y)
{
    int res = 1;
    for (int i = 0; i < 4; i++)
    {
        int nextx = x + dir[i][0];
        int nexty = y + dir[i][1];
        if (nextx < 0 || nextx >= grid.size() || nexty < 0 || nexty >= grid[0].size() || grid[nextx][nexty] == 0 || visited[nextx][nexty])
            continue;
        visited[nextx][nexty] = true;
        res += countLandAreaBfs(grid, visited, nextx, nexty);
        // cout << res << endl;
    }
    return res;
}

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
    int maxArea = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (visited[i][j] || grid[i][j] == 0)
                continue;
            visited[i][j] = true;
            int temp = countLandAreaBfs(grid, visited, i, j);
            maxArea = max(temp, maxArea);
        }
    }
    cout << maxArea << endl;
    return 0;
}
