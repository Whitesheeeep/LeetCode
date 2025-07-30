#include <iostream>
#include <vector>

using namespace std;

vector<vector<int>> res;
vector<int> path;

void findPath(const vector<vector<int>>& graph, vector<bool>& visited, int node, int n)
{
    if(node == n) // 如果到达终点
    {
        res.push_back(path); // 将当前路径添加到结果中
        return;
    }

    for(const int& next : graph[node])
    {
        if(visited[next]) continue; // 如果已经访问过，跳过
        visited[next] = true; // 标记为已访问
        path.push_back(next); // 添加到当前路径
        findPath(graph, visited, next, n); // 递归查找下一个
        path.pop_back(); // 回溯，移除当前节点
        visited[next] = false; // 标记为未访问
    }
}

int main()
{
    int n, m; // n 个顶点，m 条边
    std::cin >> n >> m;
    
    vector<vector<int>> graph(n + 1); // 使用 vector 存储图的邻接表
    vector<bool> visited(n + 1, false); // 访问标记
    
    // 有向图
    while (m--)
    {
        int u, v; // 边的起点和终点
        cin >> u >> v;         // 输入边的起点和终点
        graph[u].push_back(v); // 添加边
    }

    // 存储当前路径
    visited[1] = true; // 从节点 1 开始访问
    path.push_back(1); // 将起点添加到路径中
    findPath(graph, visited, 1, n);  // 从节点 0 开始查找路径

    // 输出结果
    if (res.empty())
    {
        return -1; // 如果没有路径，返回 -1
    }

    for (const auto &path : res)
    {
        for (int i = 0; i < path.size(); ++i)
        {
            cout << path[i] << (i == path.size() - 1 ? "\n" : " ");
        }
    }
    return 0;
}


