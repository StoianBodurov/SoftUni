#include <iostream>
#include <sstream>
#include <vector>

using namespace std;

bool isInDiagonals(vector<vector<int>> & diagonals, int r, int c){

    for (auto e:diagonals){
        if (e[0] == r && e[1] == c){
            return true;
        }
    }
    return false;
}


int main(){

    int rows;
    cin >> rows;
    cin.ignore();

    int matrix[rows][rows];

    string data;
    getline(cin, data);
    stringstream ss(data);
    vector<vector<int>> diaganalsCordinate;

    for (int r = 0; r < rows; r++){
        diaganalsCordinate.push_back({r, r});
        diaganalsCordinate.push_back({r, rows - 1 - r});
        for (int c = 0; c < rows; c++){
            int n;
            ss >> n;
            matrix[r][c] = n;
        }
    }

    int sum = 0;

    for (int r = 0; r < rows; r++){
        for (int c = 0; c < rows; c++){
            if (!isInDiagonals(diaganalsCordinate, r, c) && matrix[r][c] % 2 != 0){
                sum += matrix[r][c];
            }
        }
    }

    cout << "The sum is: " << sum << endl;
    return 0;
}