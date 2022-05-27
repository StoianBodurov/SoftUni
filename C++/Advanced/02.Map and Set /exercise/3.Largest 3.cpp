#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;

bool mysort(double firs, double second){
    return second < firs;
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
    
    for (vector<double>::iterator it = numbers.begin(); it != numbers.end(); it++){
        cout << *it << " ";
        count++;
        if (count == 3){
            break;
        }
        
    }
    

   
    return 0;
}