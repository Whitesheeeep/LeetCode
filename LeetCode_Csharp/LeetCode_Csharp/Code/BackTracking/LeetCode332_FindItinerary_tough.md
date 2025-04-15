# LeetCode332_FindItinerary_tough

> [LeetCode332](https://leetcode.cn/problems/reconstruct-itinerary/description/)

```C#
public class Solution {
    Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
    List<string> res = new List<string>();

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        // 建图并按字典序排序
        foreach (var t in tickets) {
            if (!graph.ContainsKey(t[0])) graph[t[0]] = new List<string>();
            graph[t[0]].Add(t[1]);
        }
        foreach (var key in graph.Keys) {
            graph[key].Sort(); // 字典序排序
        }

        DFS("JFK");
        res.Reverse(); // 逆序输出
        return res;
    }

    void DFS(string curr) {
        while (graph.ContainsKey(curr) && graph[curr].Count > 0) {
            string next = graph[curr][0];
            graph[curr].RemoveAt(0); // 删除已访问的边
            DFS(next);
        }
        res.Add(curr); // 后序添加节点
    }
}
```
