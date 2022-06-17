#include <iostream>
#include <map>
#include <vector>

using namespace std;

bool isCenter(vector<vector<int>> & data, int r, int c){
    for (auto d:data){
        if (d[0] == r && d[1] == c){
            return true;
        }
    }
    return false;
}

int main(){
    int n;
    cin >> n;
    cin.ignore();
    char matric[n][n];
    map<char, vector<vector<int>>> glitch;

    for (int i = 0; i < n; i++){
        string data;
        getline(cin, data);

        for (int j = 0; j < n; j++){
            matric[i][j] = data[j];

            if (data[j] != '.'){
                glitch[data[j]].push_back({i, j});
            }

        }
    }

    vector<vector<int>> centers;

    for (auto it = glitch.begin(); it != glitch.end(); it++){
        vector<vector<int>> temp = it -> second;
        int averageRow = 0;
        int averageCol = 0;

        for (int i = 0; i < temp.size(); i++){
            averageRow += temp[i][0];
            averageCol += temp[i][1];
        }   
        averageRow /= temp.size();
        averageCol /= temp.size();
        centers.push_back({averageRow, averageCol});     
    }

    for (int r = 0; r < n; r++){
        for (int c = 0; c < n; c++){
            if (isCenter(centers, r, c)){
                cout << matric[r][c];
            }else{
                cout << '.';
            }
        }
        cout << endl;
    }
    cout << endl;
    
    return 0;
}