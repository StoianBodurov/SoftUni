#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;

bool mysort(double firs, double second){
    return second > firs;
}

int main(){
    string input;
    getline(cin, input);
    stringstream ss(input);
    
    vector<double> numbers;
    
    string temp;
    while(ss >> temp){
        numbers.push_back(stod(temp));
    }
    
    int count = 0;
    
    sort(numbers.begin(), numbers.end(), mysort);
    
    for (int i = 0; i < numbers.size(); i++){
        if (i < numbers.size() - 1){
            cout << numbers[i] << " <= ";
        }else{
            cout << numbers[i];
        }
        
    }
    
    cout << endl;
   
    return 0;
}