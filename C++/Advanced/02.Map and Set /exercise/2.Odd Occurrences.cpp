#include <iostream>
#include <map>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;


int main(){
    
    string input;
    getline(cin, input);
    stringstream ss(input);
    map<string, int> counter;
    vector<string> order;
    
    string word;
    while(ss >> word){
        for (int i = 0; i < word.size(); i++){
            word[i] = tolower(word[i]);
        }
        counter[word]++;
        if (find(order.begin(), order.end(), word) == order.end()){
            order.push_back(word);
        }
    }
    
    for (int i = 0; i < order.size(); i++){
        
        if (counter[order[i]] % 2 != 0){
            if (i != order.size() - 1){
                cout << order[i] << ", ";
            }else {
                cout << order[i];
            }
            
        }
    }
    
    cout << endl;
   
    return 0;
}