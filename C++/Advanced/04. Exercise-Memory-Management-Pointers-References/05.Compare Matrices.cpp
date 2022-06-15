#include <iostream>

using namespace std;

void readMatrix(string *mat, int r){
    for (int i = 0; i < r; i++){
        string data;
        getline(cin, data);
        
        mat[i] = data;
      

    }
}


bool isMatrixsSeme(string *m1, string *m2, int r1, int r2){

    if (r1 != r2){
        return false;
    }

    for (int i = 0; i < r1; i++){
        for (int j = 0; j < m1[i].size(); j++){
            if (m1[i][j] != m2[i][j]){
                return false;
            }
        }
    }

    return true;
}


int main(){

    int r1, r2;
    cin >> r1;
    cin.ignore();
    string mat1[r1];

    readMatrix(mat1, r1);

    cin >> r2;
    cin.ignore();
    string mat2[r2];

    readMatrix(mat2, r2);

    if (isMatrixsSeme(mat1, mat2, r1, r2)){
        cout << "equal";
    }else{
        cout << "not equal";
    }
    cout << endl;


    return 0;
}