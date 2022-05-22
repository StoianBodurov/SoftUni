#include <iostream>
#include <vector>
#include <map>
#include <sstream>
#include <algorithm>

using namespace std;


int main(){
    string data;
    getline(cin, data);
    
    vector<float> orderedNumbers;
    map<float, int> numbers;
    
    stringstream ss(data);
    
    float n;
    
    while (ss >> n){
        if (find(orderedNumbers.begin(), orderedNumbers.end(), n) == orderedNumbers.end()){
           orderedNumbers.push_back(n); 
        }
        
        numbers[n]++;
    }
    
    for (int i = 0; i < orderedNumbers.size(); i++){
        cout << orderedNumbers[i] << " - " << numbers[orderedNumbers[i]] << " times" << endl;
    }
    return 0;
}