#include <iostream>
#include <queue>
#include <vector>

using namespace std;

int main() {
  int n, m, s, t;
  cin >> n >> m;

  vector<vector<int>> graph(n, vector<int>());
  vector<int> inDegrees(n, 0);
  while (m--) {
    cin >> s >> t;
    graph[s].push_back(t);
    inDegrees[t]++;
  }

  vector<int> res;
  queue<int> resQue; // 存储找到的 0 入度的节点

  for (int i = 0; i < inDegrees.size(); i++) {
    if (inDegrees[i] == 0)
      resQue.push(i);
  }

  // 对所有的入度为 0 的点指向的节点的入度减一
  while (!resQue.empty()) {
    auto a = resQue.front();
    resQue.pop();
    res.push_back(a);
    for (int i : graph[a]) {
      inDegrees[i]--;
      if (inDegrees[i] == 0)
        resQue.push(i);
    }
  }

  if (res.size() != n) {
    cout << -1 << endl;
    return 0;
  }

  for (int i = 0; i < res.size(); i++) {
    if (i == 0)
      cout << res[i];
    else
      cout << " " << res[i];
  }
}
