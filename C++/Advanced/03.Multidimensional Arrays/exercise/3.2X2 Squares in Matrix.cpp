#include <iostream>


using namespace std;

int main(){
    
    int row, col;
    cin >> row >> col;
    
    char matrix[row][col];
    
    for (int r = 0; r < row; r++){
        for (int c = 0; c < col; c++){
            char n;
            cin >> n;
            
            matrix[r][c] = n;
        }
    }
    
    int count = 0;
    
    
    for (int r = 0; r < row - 1; r++){
        for (int c = 0; c < col - 1; c++){
            if ((matrix[r][c] == matrix[r][c + 1]) && (matrix[r][c] == matrix[r + 1][c]) && (matrix[r][c] == matrix[r + 1][c + 1])){
              count++;
            }
        }
    }
 
  cout << count << endl;
   
    return 0;
}