#include <iostream>
#include <vector>

using namespace std;

class Solution{
public:
    bool backTracking(vector<vector<bool>>& usedInPanel, vector<vector<bool>>& usedInRow, vector<vector<bool>>& usedInCol, vector<vector<char>>& board, int row, int col){
        if (row == 9 || col == 9) return true;

        int nextRow = row, nextCol = col;
            if (++nextCol == 9){
                nextRow ++;
                nextCol = 0;
            }
        if (board[row][col] != '.'){
            return backTracking(usedInPanel, usedInRow, usedInCol, board, nextRow, nextCol);
        }

        for (int i = 1; i <= 9; i++) {
            if (usedInCol[col][i - 1] || usedInRow[row][i-1] || usedInPanel[(row/3) * 3+ col/3][i-1]) continue;

            usedInPanel[(row/3) * 3 + col/3][i-1] = true;
            usedInRow[row][i-1] = true;
            usedInCol[col][i-1] = true;
            board[row][col] = i + '0';
            
            // cout << "row: " << row << " col: " << col << " val: " << i << endl; 
            if (backTracking(usedInPanel, usedInRow, usedInCol, board, nextRow, nextCol)) return true;
            usedInPanel[(row/3) * 3 + col/3][i-1] = false;
            usedInRow[row][i-1] = false;
            usedInCol[col][i-1] = false;
            board[row][col] = '.';
        }
        return false;
    }


    void solveSudoku(vector<vector<char>>& board){
        // 小九宫格是否使用
        vector<vector<bool>> usedInPanel(9, vector<bool>(9, false));
        // 行 是否使用
        vector<vector<bool>> usedInRow(9, vector<bool>(9, false));
        // 列 是否使用
        vector<vector<bool>> usedInCol(9, vector<bool>(9, false));
        for (int i = 0 ; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j] != '.')
                {
                    int temp = board[i][j] - '1';
                    usedInRow[i][temp] = true;
                    usedInCol[j][temp] = true;
                    usedInPanel[i/3 * 3 + j/3][temp] = true; 
                }
            }
        }

        backTracking(usedInPanel, usedInRow, usedInCol, board, 0, 0);
    }
};

int main()
{
    vector<vector<char>> board(9, vector<char>(9, '.'));
    // char k;
    // int a;
    // cin >> a;
    // k = a + '0';
    // cout << k ;
    int row, col, k, n;
    cin >> n;
    while (n--) {
        cin >> row >> col >> k;
        board[row][col] = k + '0';
    }
    
    Solution* sln = new Solution();
    sln->solveSudoku(board);
}
