#include <iostream>
#include <vector>
#include <unordered_map>
#include <climits>
#include <list>
#include <queue>

using namespace std;

class MyComparsion{
    public:
    bool operator()(const pair<int, int>& lhs, const pair<int, int>& rhs)
    {
        return lhs.second > rhs.second;
    }
};

struct Edge
{
    int to;
    int weight;

    Edge(int t, int w): to(t), weight(w){}
};

/// @brief
/// @param graph 图
/// @param path 生成的路径
void Dijkstra(vector<vector<int>> &graph, vector<int> &path, vector<int> &dist, vector<bool> &visited);
void Dijkstra_MinHeap(vector<list<Edge>>& graph, vector<int>& path, vector<int>& dist, vector<bool>& visited);


int main()
{
    int n, m; // n 个顶点，m 个边
    cin >> n >> m;
    vector<vector<int>> graph(n + 1, vector<int>(n + 1, 0));
    for (int i = 0; i < m; i++)
    {
        int s, e, v;
        cin >> s >> e >> v;
        graph[s][e] = v; // s -> e：v
    }

    vector<int> path(n + 1, -1);
    vector<int> minDist(n + 1, INT_MAX);
    vector<bool> visited(n + 1, false);
    minDist[1] = 0;
    visited[1] = true;
    for (int i = 1; i < n + 1; i++)
    {
        if (graph[1][i] > 0)
        {
            minDist[i] = graph[1][i];
            path[i] = 1;
        }
    }
    Dijkstra(graph, path, minDist, visited);

    // 输出路径
    // for(int i = 1; i < n + 1; i++)
    // {
    //     cout << path[i] << "->" << i << ": " << minDist[i] <<endl;
    // }

    int res = (minDist[n] == INT_MAX) ? -1 : minDist[n];
    cout << res << endl;
    return 0;
}

// 数组搜索，时间复杂度：O(n^2)
void Dijkstra(vector<vector<int>> &graph, vector<int> &path, vector<int> &dist, vector<bool> &visited)
{
    int n = graph.size();
    while (true)
    {
        int minV = 0;
        int d = INT_MAX;
        for (int i = 1; i < n; i++)
        {
            if (!visited[i] && dist[i] < d)
            {
                minV = i;
                d = dist[i];
            }
        }

        if (!minV)
            break;

        visited[minV] = true;
        for (int i = 1; i < n; i++)
        {
            if (!visited[i] && graph[minV][i] != 0 && dist[minV] + graph[minV][i] < dist[i])
            {
                dist[i] = dist[minV] + graph[minV][i];
                path[i] = minV;
            }
        }
    }
}

// 在内部处理初始化
void Dijkstra_MinHeap(vector<list<Edge>> &graph, vector<int> &path, vector<int> &dist, vector<bool> &visited)
{
    priority_queue<pair<int,int>, vector<pair<int,int>>, MyComparsion> pq;
    pq.push(pair<int,int>(1,0));

    while (!pq.empty())
    {
        auto cur = pq.top(); pq.pop();
        if(visited[cur.first]) continue;
        visited[cur.first] = true;
        // 更新当前的距离源点的距离
        for(Edge e : graph[cur.first])
        {
            if(!visited[e.to] && dist[cur.first] + e.weight < dist[e.to])
            {
                dist[e.to] = dist[cur.first] + e.weight;
                pq.push(pair<int,int>(e.to, dist[e.to]));
                path[e.to] = cur.first;
            }
        }
    }

    if(dist[graph.size()-1] == INT_MAX) cout << -1 << endl;
    else cout << dist[graph.size()-1] << endl;
    
}
