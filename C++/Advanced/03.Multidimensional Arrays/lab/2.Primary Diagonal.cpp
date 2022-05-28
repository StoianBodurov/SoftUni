#include <iostream>

using namespace std;

int main(){
    int size;
    cin >> size;

    int matrix[size][size];

    for (int r = 0; r < size; r++){
        for (int c = 0; c < size; c++){
            int n;
            cin >> n;

            matrix[r][c] = n;
        }
    }

    int sumPrimaryDiagonal = 0;

    for (int i = 0; i < size; i++){
        sumPrimaryDiagonal += matrix[i][i];
    }

    cout << sumPrimaryDiagonal << endl;
}