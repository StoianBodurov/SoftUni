#include <iostream>

using namespace std;

int main(){

    int size;
    cin >> size;
    string matrix[size];

    for (int r = 0; r < size; r++){
        string row;
        cin >> row;
        matrix[r] = row;
    }

    char serchedSymbol;
    cin >> serchedSymbol;
    bool isFinde = false;
    int rowPosition;
    int colPosition;

    for (int r = 0; r < size; r++){

        if (isFinde){
            break;
        }
        for (int c = 0; c < size; c++){
            if (matrix[r][c] == serchedSymbol){
                rowPosition = r;
                colPosition = c;
                isFinde = true;
                break;
            }
        }
    }

    if (isFinde){
        cout << "(" << rowPosition << ", " << colPosition << ")"<< endl;
    }else{
        cout << serchedSymbol << " does not occur in the matrix" << endl;
    }

    return 0;
}