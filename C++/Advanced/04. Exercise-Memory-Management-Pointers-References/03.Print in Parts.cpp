#include <iostream>

using namespace std;


int main(){
    int row, col;
    cin >> row;
    cin >> col;

    int mat[row][col];

    for (int r = 0; r < row; r++){
        for (int c = 0; c < col; c++){
            int n;
            cin >> n;
            mat[r][c] = n;
        }
    }

    int r, c;


    cin >> r;
    cin >> c;


    for (int i = 0; i < r; i++){
        for (int j = 0; j < c; j++){
            cout << mat[i][j]<< " ";
        }
        cout << endl;
    }
    cout << endl;


}

/*
3 4
1 2 3 4
11 22 33 44
111 222 333 444
3 3
*/