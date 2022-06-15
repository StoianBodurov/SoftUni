#include <iostream>

using namespace std;

void printMatrix(int** &mat, int row, int col){
    for (int r = 0; r < row; r++){
        for(int c = 0; c < col; c++){
            cout << mat[r][c];
        }
        cout << endl;
    }
}


int main(){

    int n, m;
    cin >> n;
    cin >> m;

    char matrix[n][m];
    int** result = new int*[n];

    for (int r = 0; r < n; r++){
        result[r] = new int[m];
        for (int c = 0; c < m; c++){
            char el;
            cin >> el;

            matrix[r][c] = el;
            result[r][c] = 0;
        }
    }


    for (int r = 0; r < n; r++){
        for (int c = 0; c < m; c++){
            if (matrix[r][c] == '!'){
                result[r][c]++;
                if (r - 1 >= 0){
                    result[r - 1][c]++;
                }
                if (r + 1 < n){
                    result[r + 1][c]++;
                }
                if (r - 1 >= 0 && c - 1 >= 0){
                    result[r - 1][c - 1]++;
                }
                if (r - 1 >= 0 && c + 1 < m){
                    result[r - 1][c + 1]++;
                }
                if (r + 1 < n && c + 1 < m){
                    result[r + 1][c + 1]++;
                }
                if (r + 1 < n && c - 1 >= 0){
                    result[r + 1][c - 1]++;
                }
                if (c - 1 >= 0){
                    result[r][c - 1]++;
                }
                if (c + 1 < m){
                    result[r][c + 1]++;
                }    
            }

        }
    }

    printMatrix(result, n, m);

      for (size_t r = 0; r < n; r++) {
 
        delete[] result[r];
    }

    delete[] result;
 
    return 0;
}