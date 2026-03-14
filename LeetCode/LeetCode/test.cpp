#include <iostream>
#include <vector>

using namespace std;

void backTracking(const vector<vector<int>>& graph, vector<int>& path, vector<vector<int>>& res, int node, int n)
{
    if (node == n)
    {
        res.push_back(path);
        return;
    }


    for (int i = 0; i < graph[node].size(); i++)
    {
        path.push_back(graph[node][i]);
        backTracking(graph, path, res, graph[node][i], 1);
        path.pop_back();
    }
}


int main()
{
    int n, m;
    cin >> n >> m;

    vector<vector<int>> graph(n + 1, vector<int>());

    int from, to;
    while (m--)
    {
        cin >> from >> to;
        graph[from].push_back(to);
    }

    vector<int> path;
    vector<vector<int>> res;

    backTracking(graph, path, res, 1, n);

    for (auto q : res)
    {
        for (int i = 0; i < q.size(); i++)
        {
            cout << q[i];
            if (i < q.size() - 1) cout << " ";
        }
    }

}
