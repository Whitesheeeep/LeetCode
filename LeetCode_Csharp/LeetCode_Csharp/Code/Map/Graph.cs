using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LeetCode_Csharp.Code.Map
{
    public class Graph
    {

        public void BFS1TON(in List<List<int>> graph, List<bool> visited,
            List<List<int>> res, List<int> path, int node, int n)
        {
            if (node == n)
            {
                res.Add(path);
                return;
            }

            for (int next = 0; next < graph[node].Count; next++)
            {
                visited[node] = true;
                path.Add(node);
                BFS1TON(graph, visited, res, path, graph[node][next], n);
                visited[node] = false;
                path.Remove(node);
            }
        }
    }
}
