#include <iostream>
#include <vector>
#include <queue>

using namespace std;

int LevelOrderTraversal(const vector<vector<int>>& graph, vector<vector<bool>>& visited, int from, int to)
{
    queue<int> que;
    que.push(from);

    while(!que.empty())
    {
        auto temp = que.front(); que.pop();
        for (int i = 1; i < graph.size(); i++)
        {
            if (graph[temp][i] == 0 || visited[temp][i]) continue;
            else if (i == to) return 1;

            que.push(i);
        }
    }
    return 0;
}


int main()
{
    int n,m;
    cin >> n >> m;

    vector<vector<int>> graph(n + 1, vector<int>(n + 1, 0));
    vector<vector<bool>> visited(n + 1, vector<bool>(n + 1, false));

    int from, to;
    for (int i = 0; i < m; i++)
    {
        cin >> from >> to;
        graph[from][to] = 1;
        graph[to][from] = 1;
    }

    cin >> from >> to;

    cout << LevelOrderTraversal(graph, visited, from, to) << endl;

}
