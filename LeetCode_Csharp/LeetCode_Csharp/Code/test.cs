using System.Text;

StringBuilder sb = new();
List<string> strings = new();
strings.Add(sb.ToString());
int[] diag     = [];

List<bool[]> row = new List<bool[]>(9);
for (int i  = 0; i < 9; i++)
    row[i] = new bool[9];
