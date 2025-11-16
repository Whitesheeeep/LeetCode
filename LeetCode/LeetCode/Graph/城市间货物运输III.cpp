#include <iostream>
#include <vector>
#include <queue>
#include <climits>
#include <list>
#include "头文件/GraphAlgorithm.H"

using namespace std;

int main()
{
    int n, m;
    cin >> n >> m;

    vector<list<Edge>> graph(n + 1); // 第二层存边

    int s, t, v;
    for (int i = 0; i < m; i++)
    {
        cin >> s >> t >> v;
        graph[s].push_back(Edge(t, v));
    }

    int src, dst, k;
    cin >> src >> dst >> k;
    k++;

    vector<int> minDist(n + 1, INT_MAX);
    vector<int> minDist_copy(n + 1);
    minDist[src] = 0;
    queue<int> que;
    que.push(src);
    // isInQue[src] = true;
    int queLen = que.size();
    
    while (!que.empty() && k--)
    {
        // 由于更新使用的是上一层的 minDist_copy，所以：
        // 将 visited 放在外部会导致在 i 层的时候就设置某点v为 true，在 i + 1 层的时候，由于v被设置为true 不会加入到 que，那么在 i + 2 层的时候就会导致，不能通过该点进行松弛，这就导致了最短路径出问题。
        vector<bool> visited(n + 1, false); 
        queLen = que.size();
        minDist_copy = minDist;
        while (queLen--)
        {
            int v = que.front();
            que.pop();
            // isInQue[v] = false;
            for (Edge e : graph[v])
            {
                if (minDist_copy[v] + e.weight < minDist[e.to])
                    minDist[e.to] = minDist_copy[v] + e.weight;
                if (!visited[e.to])
                {
                    // 更新
                    que.push(e.to);
                    visited[e.to] = true;
                }
            }
        }
        // for(int i = 0; i <= n; i++)
        // {
        //     cout << minDist[i] << " ";
        // }
        // cout << endl;
    }

    if (minDist[dst] == INT_MAX)
        cout << "unreachable" << endl;
    else
        cout << minDist[dst] << endl;
}
