#include <iostream>


using namespace std;

int main(){
    
    int row, col;
    cin >> row >> col;
    
    int matrix[row][col];
    
    for (int r = 0; r < row; r++){
        for (int c = 0; c < col; c++){
            int n;
            cin >> n;
            
            matrix[r][c] = n;
        }
    }
    bool isFound = false;
    int searchNumber;
    cin >> searchNumber;
    
    for (int r = 0; r < row; r++){
        for (int c = 0; c < col; c++){
            if (matrix[r][c] == searchNumber){
                isFound = true;
                cout << r << " " << c << endl;
            }
        }
    }
 
    if (!isFound){
        cout << "not found" << endl;
    }
   
    return 0;
}