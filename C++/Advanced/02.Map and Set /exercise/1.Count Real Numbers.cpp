#include <iostream>
#include <map>
#include <sstream>

using namespace std;


int main(){
    
    string input;
    getline(cin, input);
    stringstream ss(input);
    map<float, int> counter;
    
    float n;
    while(ss >> n){
        counter[n]++;
    }
    
    for (auto it = counter.begin(); it != counter.end(); it++){
        cout << it -> first << " -> " << it -> second << endl;
    }
   
    return 0;
}