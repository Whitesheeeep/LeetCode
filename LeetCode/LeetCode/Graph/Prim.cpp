#include <iostream>
#include <vector>
#include <climits>
#include <queue>

using namespace std;

int main()
{
    int n,m; //顶点数，边数
    cin >> n >> m;
    vector<vector<int>> graph(n + 1, vector<int>(n + 1, 10001));
    

    for(int i = 0; i < m; i++)
    {
        int a,b,w;
        cin >> a >> b >> w;
        graph[a][b] = w;
        graph[b][a] = w;
    }

    vector<int> minDist(n + 1, 10001);
    vector<bool> inMST(n + 1, false);
    vector<int> parent(n+1, -1);

    for(int i = 1; i <= n; i++)
    {
        int cur = -1;
        int minVal = INT_MAX;
        // 查找距离 MST 最短距离的节点
        for(int j = 1; j <= n; j++)
        {
            if(!inMST[j] && minDist[j] < minVal)
            {
                minVal = minDist[j];
                cur = j;
            }
        }
        // 加入到 MST 
        inMST[cur] = true;

        // 更新加入到 MST 周边节点的最短距离
        for(int j = 0; j <= n; j++)
        {
            if(!inMST[j] && graph[cur][j] < minDist[j])
            {
                minDist[j] = graph[cur][j];
                parent[j] = cur;
            }
        }
    }

    int  result = 0;
    for(int i = 2; i <= n; i++)
    {
        result += minDist[i];
    }
    cout << result << endl;
    for(int i = 1; i <= n; i++)
    {
        cout << parent[i] << " " << inMST[i] << endl;
    }
    
}

struct Edge {
    int to;
    int weight;
};

struct Node {
    int weight, u, parent;
    bool operator>(const Node& other) const {
        return weight > other.weight;
    }
};

int prim(int n, vector<vector<Edge>>& graph, vector<pair<int,int>>& mstEdges) {
    vector<bool> inMST(n, false);
    priority_queue<Node, vector<Node>, greater<Node>> pq;

    // 从 0 号顶点开始
    pq.push({0, 0, -1}); // {边权, 当前点, 父节点}
    int mstWeight = 0;
    int edgesUsed = 0;

    while (!pq.empty() && edgesUsed < n) {
        auto cur = pq.top(); pq.pop();
        int w = cur.weight, u = cur.u, parent = cur.parent;

        if (inMST[u]) continue;
        inMST[u] = true;
        mstWeight += w;
        edgesUsed++;

        if (parent != -1) {
            mstEdges.push_back({parent, u}); // 记录生成树的边
        }

        for (auto &e : graph[u]) {
            if (!inMST[e.to]) {
                pq.push({e.weight, e.to, u});
            }
        }
    }

    return mstWeight;
}

int main_2() {
    int n, m;
    cin >> n >> m;  // n个点 m条边
    vector<vector<Edge>> graph(n);
    for (int i = 0; i < m; i++) {
        int u, v, w;
        cin >> u >> v >> w;
        graph[u].push_back({v, w});
        graph[v].push_back({u, w}); // 无向图
    }

    vector<pair<int,int>> mstEdges;
    int totalWeight = prim(n, graph, mstEdges);

    cout << "MST 权值和: " << totalWeight << endl;
    cout << "MST 边集合:" << endl;
    for (auto [u, v] : mstEdges) {
        cout << u << " - " << v << endl;
    }
}
