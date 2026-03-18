#include <climits>
#include <iostream>
#include <math.h>
#include <queue>
#include <vector>

using namespace std;

#pragma region 并查集
int n = 10001;
vector<int> father(n,0);

void init()
{
    for (int i = 0; i < n; i++)
    {
        father[i] = i;
    }
}

int find(int u)
{
    return u == father[u] ? u : father[u] = find(father[u]);
}

bool isSame(int u, int v)
{
    u = find(u);
    v = find(v);
    return u == v;
}

void join(int u, int v)
{
    u = find(u);
    v = find(v);
    if (u == v) return;
    father[v] = u;
}
#pragma endregion


struct Edge {
  int l, r, w;
};


class Comparer {
  public:
    bool operator()(const Edge& l, const Edge& r) { return l.w > r.w; }
};

///
// Prim 算法：生成树，每次将最小的加入到树中。
///
int main() {

  int v, e;
  cin >> v >> e;

  // 初始化
//   vector<bool> visited(v + 1, false);
//   vector<int> minDis(v + 1, INT_MAX);
//   minDis[1] = 0;
  priority_queue<Edge, vector<Edge>, Comparer> minDistance;
//   vector<vector<int>> graph(v + 1, vector<int>(v + 1, 0));
  init();

  // 构建图
  int v1, v2, w;
  while (e--) {
    cin >> v1 >> v2 >> w;
    Edge temp = Edge();
    temp.l = v1;
    temp.r = v2;
    temp.w = w;
    minDistance.emplace(temp);
  }
  int res = 0;
  // 找到最小边，加入到树中
  while(!minDistance.empty())
  {
    // 取出最小边
    auto edge = minDistance.top(); minDistance.pop();
    if (isSame(edge.l, edge.r)) continue;
    else
    {
        join(edge.l, edge.r);
        res += edge.w;
    }
  }

  // 处理完毕，将所有的内容加载一起
  cout << res << endl;
}
