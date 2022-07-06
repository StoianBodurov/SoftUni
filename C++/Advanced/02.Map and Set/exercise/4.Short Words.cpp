#include <iostream>
#include <sstream>
#include <map>

using namespace std;


int main(){

    string data;
    getline(cin, data);
    stringstream ss(data);

    map<string, int> words;

    string word;
    while (ss >> word)
    {
        for (int i = 0; i < word.size(); i++){
            word[i] = tolower(word[i]);
        }
        if(word.size() < 5){
            words[word] = word.size();
        }
        
    }

    for (map<string, int>::iterator it = words.begin(); it != words.end(); it++){
        string key = it -> first;
        int value = it -> second;


        it++;
        if (it != words.end()){
            cout << key << ", ";
        }else{
            cout << key;
        }
        it--;
    
    }

    cout << endl;
    

    return 0;
}