#include <iostream>


using namespace std;

int main(){
    
    int row, col;
    cin >> row >> col;
    string word;
    cin >> word;
    
    int index = 0;
    
    char matrix[row][col];
    
    for (int r = 0; r < row; r++){
        
        if (r % 2 == 0){
        
            for (int c = 0; c < col; c++){
                if (index == word.size()){
                    index = 0;
                }
                matrix[r][c] = word[index];
                index++;
            }
        } else {
            for (int c = col - 1; c >= 0; c--){
                if (index == word.size()){
                    index = 0;
                }
                matrix[r][c] = word[index];
                index++;
            }
        }
    }

    for (int r = 0; r < row; r++){
        for (int c = 0; c < col; c++){
            cout << matrix[r][c];
        }
        cout << endl;
    }
   
    return 0;
}