#include <climits>
#include <functional>
#include <iostream>
#include <queue>
#include <utility>
#include <vector>

using namespace std;

struct Edge {
  int to;
  int w;
};

class Comparer
{
    public:
        bool operator()(const pair<int, int>& a, const pair<int, int>& b){
            return a.second > b.second;
        }
};

int main() {
  int n, m, s, e, v;
  cin >> n >> m;

  // 初始化
  vector<int> minDis(n + 1, INT_MAX);
  vector<bool> visited(n + 1, false);
  vector<vector<Edge>> graph(n + 1, vector<Edge>());
  // 最小堆
  priority_queue<pair<int,int>, vector<pair<int, int>>, Comparer> minHeap;

  // 建图
  while (m--) {
    cin >> s >> e >> v;
    graph[s].push_back({e, v});
  }

  // 迪杰斯特拉
  minDis[1] = 0;
  minHeap.push({1, 0});
  // 不需要：int res = 0;

    while(!minHeap.empty()) { // 找到最小的值
    // for (int i = 1; i <= n; i++) {
    //   if (!visited[i] && min > minDis[i]) {
    //     index = i;
    //     min = minDis[i];
    //   }
    // }
    // if (index == -1) break;
    // 加入到集合中
    auto temp = minHeap.top(); minHeap.pop();
    int min = temp.second, index = temp.first;
    if (visited[index]) continue;
    visited[temp.first] = true;
    // cout << index << " " << min << endl;
    // 错误：
    // res = min;

    // 松弛周围的边
    for (int i = 0; i < graph[index].size(); i++) {
      auto edge = graph[index][i];
      if (!visited[edge.to] && min + edge.w < minDis[edge.to]) {
        minDis[edge.to] = min + edge.w;
        minHeap.push({edge.to, minDis[edge.to]});
      }
    }
  }
  if (!visited[n]) cout << -1 << endl;
  else cout << minDis[n] << endl;
  return 0;
}
