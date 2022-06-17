#include <iostream>
#include <vector>
#include <sstream>

using namespace std;


int main(){

    vector<string> words;

    while (true)
    {
        string row;
        getline(cin, row);
        if (row == "###") break;

        stringstream ss(row);
        string word;
        while (ss >> word)
        {
            words.push_back(word);
        }
    }

    int charCount;
    cin >> charCount;

    int count = 0;
    for (int i = 0; i < words.size(); i++){
        if (count == 0){
            cout << words[i];
            count += words[i].size();
        }else{
            if ((count + words[i].size() + 1) <= charCount){
                cout << " " << words[i];
                count += words[i].size() + 1;
            }else{
                cout << endl << words[i];
                count = words[i].size();
            }
        }
    }

    cout << endl;

    return 0;
}