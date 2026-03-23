#include <climits>
#include <iostream>
#include <list>
#include <queue>
#include <vector>

using namespace std;

struct Edge
{
    int to;
    int w;
};

int main()
{
    int n,m,s,t,v;
    cin >> n >> m;
    vector<list<Edge>> graph(n  + 1, list<Edge>());
    vector<int> minDis(n  + 1, INT_MAX);

    while (m--) {
        cin >> s >> t >> v;
        graph[s].push_back({t,v});
    }

    // 初始化
    minDis[1] = 0;
    queue<int> que;
    que.push(1);
    
    while (!que.empty()) {
        // 松弛
        auto vertex = que.front(); que.pop();
        for (Edge edge : graph[vertex]) {
            if (minDis[vertex] != INT_MAX && minDis[vertex] + edge.w < minDis[edge.to])
            {
                minDis[edge.to] = minDis[vertex] + edge.w;
                que.push(edge.to);
            }
        }
    }

    if (minDis[n] == INT_MAX) cout << "unconnected" << endl;
    else cout << minDis[n] << endl;
}
