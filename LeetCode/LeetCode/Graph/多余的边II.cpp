///
// 并查集在验证有向树中的应用
///

#include <iostream>
#include <stack>
#include <vector>

using namespace std;

int n = 1001;
vector<int> father(n, 0);

void init()
{
    for(int i = 0; i < n; i++)
        father[i] = i;
}

int find(int u){
    if (u == father[u]) return u;
    return father[u] = find(father[u]);
}

bool isSame(int u, int v)
{
    u = find(u);
    v = find(v);
    return u == v;
}

void add(int u, int v)
{
    u = find(u);
    v = find(v);
    if (u == v) return;
    father[v] = u;
}


bool isTreeAfterDeleteEdge(const vector<vector<int>>& edges, int edgeIndex)
{
    for (int i =0; i < edges.size(); i++) {
        if (i == edgeIndex) continue;
        if (isSame(edges[i][0], edges[i][1])){
            return false;
        }
        else {
            add(edges[i][0], edges[i][1]);
        }
    }
    return true;;
}

void getRemoveEdge(const vector<vector<int>>& edges)
{
    init();
    for (int i = 0; i < edges.size(); i++)
    {
        if (isSame(edges[i][0], edges[i][1])){
            cout << edges[i][0] << " " << edges[i][1];
            return;
        }
        else
            add(edges[i][0], edges[i][1]);
    }
}

int main()
{
    int a;
    cin >> a;
    
    // 存储边
    vector<vector<int>> edges;
    // 入度存储
    vector<int> indegrees(a + 1,0);

    init();
    int s,t;
    while(a--)
    {
        cin >> s >> t;
        indegrees[t]++;
        edges.push_back({s,t});
    }

    // 寻找入度为 2 的边
    stack<int> edgeWith2Indegrees;
    for (int i = 0; i< edges.size(); i++) {
        if (indegrees[edges[i][1]] == 2)
            edgeWith2Indegrees.push(i);
    }

    if (edgeWith2Indegrees.size() > 0)
    {
        int edgeIndex = edgeWith2Indegrees.top();
        edgeWith2Indegrees.pop();
        if (isTreeAfterDeleteEdge(edges, edgeIndex))
        {
            cout << edges[edgeIndex][0] << " " << edges[edgeIndex][1] << endl;
            return 0;
        }
        else {
            cout << edges[edgeWith2Indegrees.top()][0] << " " << edges[edgeWith2Indegrees.top()][1] << endl;
            return 0;
        }
    }

    // 处理循环树
    getRemoveEdge(edges);
}
