#include <iostream>
#include <vector>
#include <climits>

#include "GraphAlgorithm.h"
#include <queue>

using namespace std;

int start = 0;
int endNode = 0;
int main()
{
    int n, m;
    cin >> n >> m;

    endNode = n;
    vector<vector<int>> grid; // 两层数组，但是第二层装载的是边，first 是 from，second 是 to，third 是 weight

    for (int i = 0; i < m; i++)
    {
        int f, t, w; // from,to,weight
        cin >> f >> t >> w;
        grid.push_back({f, t, w});
    }

    vector<int> minDist(n + 1, INT_MAX);
    minDist[start] = 0;

}

void Algorithm::Bellman_ford(const vector<vector<int>> &grid, vector<int> &minDist)
{
    // 松弛 n - 1遍，此处的 n 是指 grid.size()
    for (int i = 0; i < grid.size(); i++)
    {
        for (auto e : grid)
        {
            int from = e[0];
            int to = e[1];
            int weight = e[2];
            if (minDist[from] != INT_MAX && minDist[from] + weight < minDist[to])
            {
                minDist[to] = minDist[from] + weight;
            }
        }
    }

    if (minDist[endNode] == INT_MAX)
        cout << -1 << endl;
    else
        cout << minDist[endNode] << endl;
}

void Algorithm::SPFA()
{
    int n, m;
    cin >> n >> m;

    vector<vector<Edge>> grid;
    vector<bool> isInQueue(n + 1);

    for (int i = 0; i < m; i++)
    {
        int f, t, w;
        cin >> f >> t >> w;
        grid[f].push_back(Edge(t, w));
    }

    int start = 1, end = n;
    vector<int> minDist(n + 1, INT_MAX);
    minDist[start] = 0;

    queue<int> que;
    que.push(start);

    while (!que.empty())
    {
        auto v = que.front();
        que.pop(); // 将要进行处理的点
        isInQueue[v] = false;

        for (Edge e : grid[v])
        {
            if (minDist[v] + e.weight < minDist[e.to])
            {
                minDist[e.to] = minDist[v] + e.weight;
                if (!isInQueue[e.to]) // 已经在队列中的元素就没必要重复添加了
                {
                    que.push(e.to);
                    isInQueue[e.to] = true;
                }
            }
        }
    }
    if (minDist[end] == INT_MAX)
        cout << "unconnected" << endl; // 不能到达终点
    else
        cout << minDist[end] << endl; // 到达终点最短路径
}
