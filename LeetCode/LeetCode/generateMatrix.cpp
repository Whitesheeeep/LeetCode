#include <vector>

using namespace std;

class Solution {
public:
	vector<int> generateMatrix(vector<vector<int>>& matrix) {
		int m = matrix.size(), n = matrix[0].size();
		vector<int> res;

		// 初始化滑动窗口
		int left = 0, right = n - 1,
			up = 0, bottom = m - 1;
		while (left <= right && up <= bottom)
		{
			//从左往右，闭区间
			for (int i = left; i <= right; i++)
			{
				res.push_back(matrix[0][i]);
			}

			for (int j = up + 1; j <= bottom; j++)
			{
				res.push_back(matrix[j][right]);
			}
			if(up < bottom)
				for (int i = right - 1; i >= left; i--)
				{
					res.push_back(matrix[bottom][i]);
				}
			if (left < right)
				for (int j = bottom - 1; j > up; j--)
				{
					res.push_back(matrix[j][left]);
				}
			left++;
			right--;
			up++;
			bottom--;
		}
		return res;

	}
};

