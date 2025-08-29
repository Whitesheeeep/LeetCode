#include <iostream>
#include <vector>
#include <queue>

using namespace std;

int main()
{
    int n, m; // n 个文件，m 个依赖关系
    cin >> n >> m;

    vector<vector<int>> graph(n, vector<int>(n, 0));
    vector<int> inDegree(n, 0);
    for (int i = 0; i < m; i++)
    {
        int s, t;
        cin >> s >> t;
        graph[s][t] = 1;
        inDegree[t]++;
    }

    // 找到根
    queue<int> resque;

    for (int i = 0; i < n; i++)
    {
        if (!inDegree[i])
        {
            resque.push(i);
        }
    }
    vector<int> res;
    while (!resque.empty())
    {
        int cur = resque.front();
        resque.pop();
        res.push_back(cur);
        for (int i = 0; i < n; i++)
        {
            if (graph[cur][i])
            {
                inDegree[i]--;
                if (inDegree[i] == 0)
                    resque.push(i);
            }
        }
    }

    if (res.size() < n)
        cout << -1 << endl;
    else
    {
        for (int i = 0; i < res.size() - 1; i++)
        {
            cout << res[i] << " ";
        }
        cout << res[n - 1];
    }
}
