#include <functional>
#include <iostream>
#include <queue>
#include <utility>
#include <vector>

using namespace std;

int dir[8][2] = {-2, 1, -1, 2, 1, 2, 2, 1, 2, -1, 1, -2, -1, -2, -2, -1};
vector<vector<int>> moves(1001, vector<int>(1001, 0));

struct Pos {
  int x, y, f,g;
  bool operator<(const Pos &a) const { return f > a.f; }
};

int L2_Dis(int start_x, int start_y, int end_x, int end_y) {
  return (start_x - end_x) * (start_x - end_x) + (start_y - end_y) * (start_y - end_y);
}

void astar(const Pos& start, const Pos& end)
{
  Pos cur, next;
  priority_queue<Pos> que;
  que.push(start);

  while (!que.empty()) {
    cur = que.top(); que.pop();
    if (cur.x == end.x && cur.y == end.y) break;

    for(int i = 0; i < 8; i++)
    {
      next = {cur.x + dir[i][0], cur.y + dir[i][1], 0, 0};
      if (next.x < 1 || next.x > 1000 || next.y < 1 || next.y > 1000) continue;
      if (!moves[next.x][next.y]){
        moves[next.x][next.y] = moves[cur.x][cur.y] + 1;
        next.g = cur.g + 5;
        next.f = next.g + L2_Dis(next.x, next.y, end.x, end.y);
        que.push(next);
      }
    }
  }

}


int main() {
  int n, a1, a2, b1, b2;
  cin >> n;
  std::vector<vector<int>> ex(n, vector<int>());

  while (n--) {
    cin >> a1 >> a2 >> b1 >> b2;
    moves = {1001, vector<int>(1001, 0)};
    Pos start{a1, a2, 0 + L2_Dis(a1, a2, b1, b2), 0};
    Pos end{b1, b2, 0, 0};
    astar(start, end);
    cout << moves[b1][b2] << endl;
  }
}
