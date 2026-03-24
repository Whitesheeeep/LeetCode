#include <climits>
#include <iostream>
#include <vector>

using namespace std;

struct Edge
{
    int to, w;
    Edge(int to, int w): to(to), w(w){}
};

int main()
{
    int n,m,s,t,v,src,dst,k;
    cin >> n >> m;
    vector<vector<Edge>> graph(n + 1, vector<Edge>());
    vector<int> minDis(n + 1, INT_MAX);
    vector<int> minDis_copy;

    while (m--) {
        cin >> s >> t >> v;
        graph[s].push_back(Edge(t,v));
    }
    cin >> src >> dst >> k;
    minDis[src] = 0;

    for (int i = 0; i <= k; i++)
    {
        minDis_copy = minDis;
        for (int j = 1; j <= n; j++){
            for (Edge edge : graph[j]) {
                if (minDis_copy[j] != INT_MAX && minDis_copy[j] + edge.w < minDis[edge.to]){
                    minDis[edge.to] = minDis_copy[j] + edge.w;
                }
            }
        }
    }

    if (minDis[dst] == INT_MAX) cout << "unreachable" << endl;
    else cout << minDis[dst] << endl;
}
