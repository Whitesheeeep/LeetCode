#include <iostream>
#include <vector>

using namespace std;

int main() {
  int n, m, u, v, w, Q, start, end;
  cin >> n >> m;

  vector<vector<vector<int>>> graph(
      n + 1, vector<vector<int>>(n + 1, vector<int>(n + 1, 10005)));

  while (m--) {
    cin >> u >> v >> w;
    graph[u][v][0] = w;
    graph[v][u][0] = w;
  }

  for (int k = 1; k <= n; k++) {
    for (int i = 1; i <= n; i++) {
      for (int j = 1; j <= n; j++) {
        
      }
    }
  }

  cin >> Q;
  while (Q--) {
    cin >> start >> end;
  }
}
