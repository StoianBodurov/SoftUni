#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>
#include <math.h>

using namespace std;

bool mysort(int firs, int second){
    return second < firs;
}

int main(){
    string input;
    getline(cin, input);
    stringstream ss(input);
    
    vector<int> numbers;
    
    string temp;
    while(ss >> temp){
        numbers.push_back(stoi(temp));
    }
    
    sort(numbers.begin(), numbers.end(), mysort);
    
    for (int i = 0; i < numbers.size(); i++){
        if (pow(sqrt(numbers[i]), 2) == numbers[i]){
            cout << numbers[i] << " ";
        }
    }
    cout << endl;
    
   
    return 0;
}