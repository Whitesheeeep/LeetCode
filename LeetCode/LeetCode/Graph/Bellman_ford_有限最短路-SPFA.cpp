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
  vector<int> count(n + 1, 0);
  vector<bool> inQue(n + 1, false);
  que.push(1);
  count[1]++;
  inQue[1] = true;

  while (!que.empty()) {
    int num = que.size();

    while (num--) {
      auto node = que.front();
      que.pop();
      inQue[node] = false;
      for (Edge edge : graph[node]) {
        if (minDis[node] + edge.w < minDis[edge.to]) {
          minDis[edge.to] = minDis[node] + edge.w;
          if (!inQue[edge.to])
          {
            que.push(edge.to);
            inQue[edge.to] = true;
            count[edge.to]++;
            if (count[edge.to] == k + 1)
            {
                if (minDis[dst] != INT_MAX)
                    cout << minDis[dst] << endl;
                else
                    cout << "unreachable" << endl;
            }
          }
        }
      }
    }
  }

  if (minDis[dst] == INT_MAX)
    cout << "unreachable" << endl;
  else
    cout << minDis[dst] << endl;
}
