#include <iostream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <queue>

using namespace std;

int BFS(unordered_map<int, vector<int>>& graph)
{
    // 判断 1 是否能达到所有顶点
    unordered_set<int> canReachVertex;
    // vector<bool> visited(v + 1, false);
    
    // 广搜
    queue<int> nodeQueue;
    nodeQueue.push(1);
    // visited[1] = true;
    canReachVertex.insert(1);
    while (!nodeQueue.empty())
    {
        int node = nodeQueue.front(); nodeQueue.pop();
        vector<int> around = graph[node];
        for(int i = 0; i < around.size(); i++)
        {
            if (canReachVertex.find(around[i]) != canReachVertex.end()) continue;
            canReachVertex.insert(around[i]);
            // visited[around[i]] = true;
            nodeQueue.push(around[i]);
        }
    }
    
    return canReachVertex.size() == graph.size() ? 1 : -1;
}

void DFS(unordered_map<int, vector<int>> &graph, unordered_set<int>& canReachVectex, int v)
{
    if(canReachVectex.find(v) != canReachVectex.end()) return;

    canReachVectex.insert(v);
    for(int i : graph[v])
    {
        DFS(graph, canReachVectex, i);
    }
}


int main()
{
    int v, e; // 顶点、边的数量
    cin >> v >> e;

    unordered_map<int, vector<int>> graph;
    for(int i = 1; i <= v; i++)
    {
        graph[i] = {};
    }

    // 输入边
    for(int i = 0; i < e; i++)
    {
        int start, end;
        cin >> start >> end;
        graph[start].push_back(end);
    }

    // 输出图
    // for (int i = 0; i < v; i++)
    // {
    //     for(auto item : graph[i])
    //         cout << i << "->" << item << endl;
    // }

    unordered_set<int> canReachVectex;
    DFS(graph, canReachVectex, 1);
    int res = v == canReachVectex.size() ? 1 : -1;
    cout << res << endl;
    return 0;
}
