#include <iostream>
#include <sstream>
#include <set>
#include <cstring>
#include <algorithm>
#include <regex>


using namespace std;


int main(){
    string text;
    getline(cin, text);

    set<string> words;

    stringstream ss(text);
    string word;


    while (ss >> word)
    {
       
        words.insert(regex_replace(word, regex("[.]"), ""));
    }

    
    while (true)
    {
        char ch;

        cin >> ch;

        if (ch == '.'){
            break;
        }
      
        for (set<string>::iterator i = words.begin(); i != words.end(); i++){

            string w = *i;
            string::iterator it;

            string tempdWord = "";
            for (int j = 0; j < w.size(); j++){
                tempdWord += tolower(w[j]);
            }
            it = find(tempdWord.begin(), tempdWord.end(), tolower(ch));
            if (it != tempdWord.end()){
                cout << w << " ";
            }
        }
        cout << endl;
    }
    

    return 0;
}