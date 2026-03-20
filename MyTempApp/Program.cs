int n = 1001;
List<int> father = new(n);

Init();
int a;
a = int.Parse(System.Console.ReadLine());
System.Console.WriteLine(a);

List<List<int>> edges;
List<int> inDegrees = Enumerable.Repeat(0, n).ToList();

int u,v;
while(a-- > 0)
{
    string line = Console.ReadLine();
    var strs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    (u,v) = (int.Parse(strs[0]), int.Parse(strs[1]));
    edges.Add([u, v]);
    inDegrees[v]++;
}

for (int i = edges.Count; i >=0 ;i--)
{
    if (inDegrees[edges[i][1]] == 2 && IsTreeAfterRemoveEdge(edges, i))
    {
        System.Console.WriteLine($"{inDegrees[edges[i][0]]} {in}");
    }
}



void Init()
{
    for (int i = 0; i < n; i++)
    {
        father.Add(i);
    }
}

int Find(int u)
{
    return u == father[u] ? u : father[u] = Find(father[u]);
}

bool IsSame(int u, int v)
{
    u = Find(u);
    v = Find(v);
    return u == v;
}

void Join(int u, int v)
{
    u = Find(u);
    v = Find(v);
    if (u == v) return;
    father[v] = u;
}



