#include <climits>
#include <iostream>
#include <queue>
#include <vector>

using namespace std;

struct Edge {
  int to, w;
  Edge(int to, int w) : to(to), w(w) {}
};

int main() {
  int n, m, s, t, v, src, dst, k;
  cin >> n >> m;
  vector<vector<Edge>> graph(n + 1, vector<Edge>());
  vector<int> minDis(n + 1, INT_MAX);
  vector<int> minDis_copy;

  while (m--) {
    cin >> s >> t >> v;
    graph[s].push_back(Edge(t, v));
  }
  cin >> src >> dst >> k;
  minDis[src] = 0;
  
  queue<int> que;
  que.push(src);

  k++;
  while (k-- && !que.empty()) {
    minDis_copy = minDis;
    int num = que.size();
    while (num--) {
      auto node = que.front(); que.pop();
      for (Edge edge : graph[node]){
        if (minDis_copy[node] != INT_MAX &&  minDis_copy[node] + edge.w < minDis[edge.to])
        {
          minDis[edge.to] = minDis_copy[node] + edge.w;
          que.push(edge.to);
        }
      }
    }
  }

  
  

  if (minDis[dst] == INT_MAX)
    cout << "unreachable" << endl;
  else
    cout << minDis[dst] << endl;
}
