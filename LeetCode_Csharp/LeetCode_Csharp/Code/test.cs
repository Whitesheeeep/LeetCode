int[][] GenerateMatrix(int n)
{
    int[][] res = new int[n][];
    // 初始化交错数组
    for (int i = 0; i < res.Length; i++)
    {
        res[i] = new int[n];
    }

    // 变换窗口，控制起始点和终点
    // 左闭右开
    int bottom = n - 1, right = n - 1;
    int up = 0, left = 0;
    int row = 0, colume = 0;
    for (int i = 1; i <= n * n;)
    {

        while (i <= n*n &&colume <= right)
        {
            res[row][colume++] = i++;
        }
        colume--;
        up++;
        

        while (i <= n * n && row <= bottom)
        {
            res[row++][colume] = i++;
        }
        right--;

        while (i <= n*n &&colume >= left)
        {
            res[row][colume--] = i++;
        }
        bottom--;

        while (i <= n*n &&row >= up)
        {
            res[row--][colume] = i++;
        }
        i--;
        left++;
    }
    return res;
}

var res = GenerateMatrix(3);
foreach (var item in res)
{
    foreach (int i in item)
    System.Console.WriteLine(i);
}
