#include <iostream>
#include <map>
#include <vector>
#include <string>

using namespace std;

int getMinElement(vector<int> &v){
    int min = v[0];
    for (int i = 1; i < v.size(); i++){
        if (v[i] < min){
            min = v[i];
        }
    }
    return min;
}

int getMaxElement(vector<int> &v){
    int max = v[0];
    for (int i = 1; i < v.size(); i++){
        if (v[i] > max){
            max = v[i];
        }
    }
    return max;
}

int main(){

    map<string, vector<int>> towns;

    int numbersTown;
    cin >> numbersTown;

    
    string citi;
  

    while (cin >> citi)
    {   
        int minTemperature, maxTemperature;
        cin >> minTemperature;
        cin >> maxTemperature;

        

        map<string, vector<int>>::iterator it;
        it = towns.find(citi);



        if (it == towns.end() && towns.size() == numbersTown){
            break;
        }

        towns[citi].push_back(minTemperature);
        towns[citi].push_back(maxTemperature);
        
    }


    for (map<string, vector<int>>::iterator it = towns.begin(); it != towns.end(); it++){
        string c = it -> first;
        vector<int> t = it -> second;

        cout << c << " " << getMinElement(t) << " " << getMaxElement(t) << endl;
    }
    

    return 0;
}

