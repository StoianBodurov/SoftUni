#include <iostream>

using namespace std;

void printMatrix(char** &mat, int row, int col){
    for (int r = 0; r < row; r++){
        for(int c = 0; c < col; c++){
            cout << mat[r][c];
        }
        cout << endl;
    }
}

void copyMatrix(char** &mat1, char** &mat2, int row, int col){
    for (int r = 0; r < row; r++){
        for (int c = 0; c <col; c++){
            mat2[r][c] = mat1[r][c];
        }
    }
}


int main(){

    int n, m;
    n = 10;
    m = 10;

    char** matrix = new char*[n];
    char** result = new char*[n];

    for (int r = 0; r < n; r++){

        string el;
        cin >> el;
        matrix[r] = new char[m];
        result[r] = new char[m];

        for (int c = 0; c < m; c++){
            

            matrix[r][c] = el[c];
            result[r][c] = el[c];
        }
    }

    int count;
    cin >> count;

    for (int i = 0; i < count; i++){

        for (int r = 0; r < n; r++){
            for (int c = 0; c < m; c++){
                if (matrix[r][c] == '!'){
                    if (r - 1 >= 0 && matrix[r - 1][c] != '#'){
                        result[r - 1][c] = '!';
                    }
                    if (r + 1 < n && matrix[r + 1][c] != '#'){
                        result[r + 1][c] = '!';
                    }
            
                    if (c - 1 >= 0 && matrix[r][c - 1] != '#'){
                        result[r][c - 1] = '!';
                    }
                    if (c + 1 < m && matrix[r][c + 1] != '#'){
                        result[r][c + 1] = '!';
                    }    
                }

                

            }
        }
        copyMatrix(result, matrix, n, m);
    }

    printMatrix(matrix, n, m);

    for (size_t r = 0; r < n; r++) {
 
        delete[] matrix[r];
        delete[] result[r];
    }

    delete[] matrix;
    delete[] result;
 
    return 0;
}