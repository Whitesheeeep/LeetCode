using System.Text;

List<int> ints = [1];
AddInt(ints);
Print(ints);


void Print(List<int> ints)
{
    foreach(int i in ints)
        System.Console.WriteLine(i);
}

void AddInt(List<int> ints)
{
    ints.Add(2);
}
