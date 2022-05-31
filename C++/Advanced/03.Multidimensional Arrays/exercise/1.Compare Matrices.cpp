#include <iostream>


using namespace std;

int main(){
    
    int row1;
    cin >> row1;
    cin.ignore();
    
    string matrix1[row1];
    
    for (int r = 0; r < row1; r++){
        string data;
        getline(cin, data);
        matrix1[r] = data;
    }
    
    int row2;
    cin >> row2;
    cin.ignore();
    
    string matrix2[row2];
    
    for (int r = 0; r < row2; r++){
        string data;
        getline(cin, data);
        matrix2[r] = data;
    }
    
    if (row1 != row2){
        cout << "not equal" << endl;
        return 0;
    }
    
    for (int r = 0; r < row1; r++){
        if (matrix1[r].size() != matrix2[r].size()){
            cout << "not equal" << endl;
            return 0;
        }
        
        for (int i = 0; i < matrix1[r].size(); i++){
            if (matrix1[r][i] != matrix2[r][i]){
                cout << "not equal" << endl;
                return 0;
            }
        }
    }
    
    cout << "equal" << endl;
   
    return 0;
}