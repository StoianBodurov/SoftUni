#include <iostream>


using namespace std;

int main(){

    int row, col;
    cin >> row >> col;
    int matrix[row][col];

    for(int r = 0; r < row; r++){
        for (int c = 0; c < col; c++){
            int n;
            cin >> n;
            matrix[r][c] = n;
        }
    }


    for (int c = 0; c < col; c++){
        int columnSum = 0;

        for (int r = 0; r < row; r++){
            columnSum += matrix[r][c];
        }

        cout << columnSum << endl;
    }
}