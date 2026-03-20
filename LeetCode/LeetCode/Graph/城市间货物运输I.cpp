#include <climits>
#include <iostream>
#include <list>
#include <vector>

using namespace std;

struct Edge{
    int to;
    int w;
};

int main()
{
    int n,m,s,t,v;
    cin >> n >> m;

    vector<list<Edge>> graph(n + 1, list<Edge>());
    vector<int> minDis(n + 1, INT_MAX);
    
    while (m--) {
        cin >> s >> t >> v;
        graph[s].push_back({t,v});
    }

    // 初始化
    minDis[1] = 0;
    for (int i = 1; i < n; i++) {
        // 松弛
        for (Edge edge : graph[i]) {
            if (minDis[i] != INT_MAX && minDis[i] + edge.w < minDis[edge.to]){
                minDis[edge.to] = minDis[i] + edge.w;
            }
        }
    }

    if (minDis[n] == INT_MAX) cout << "unconnected" << endl;
    else cout << minDis[n] << endl;
}
