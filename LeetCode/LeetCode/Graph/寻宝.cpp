#include <iostream>
#include <vector>
#include <climits>
#include <math.h>

using namespace std;

///
// Prim 算法：生成树，每次将最小的加入到树中。
///
int main()
{
    

    int v, e;
    cin >> v >> e;
    
    // 初始化
    vector<bool> visited(v+1, false);
    vector<int> minDis(v+1, INT_MAX);
    minDis[1] = 0;
    vector<vector<int>> graph(v+1,vector<int>(v+1, 0));

    // 构建图
    int v1, v2, w;
    while (e--) {
        cin >> v1 >> v2 >> w;
        graph[v1][v2] = w;
        graph[v2][v1] = w;
    }

    for (int i = 1; i <= v; i++)
    {
        // 寻找最小距离
        int index = -1, minVal = INT_MAX;
        for (int j = 1; j <= v; j++)
        {
            if (!visited[j] && minDis[j] < minVal)
            {
                index = j;
                minVal = minDis[j];
            }
        }
        // cout << index << " " << minDis[index] << endl;
        // 加入到树中
        visited[index] = true;
        // 更新周边的最小距离
        for (int j = 1; j <= v; j++)
        {
            if (graph[index][j] != 0 && !visited[j] && minDis[j] > graph[index][j])
            {
                minDis[j] = graph[index][j];
            }
        }
    }

    // 处理完毕，将所有的内容加载一起
    int res = 0;
    for (int i = 1; i <= v; i++)
    {
        res += minDis[i];
    }
    cout << res << endl;

}
