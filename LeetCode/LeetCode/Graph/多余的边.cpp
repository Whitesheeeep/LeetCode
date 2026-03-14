#include <iostream>
#include <vector>

using namespace std;

int n = 1001;
vector<int> father = vector<int>(n);

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

int main()
{
    int a;
    cin >> a;
    init();
    int s,t;
    while(a--)
    {
        cin >> s >> t;
        if (!isSame(s,t)) add(s,t);
        else cout << s << " " << t;
    }
}

