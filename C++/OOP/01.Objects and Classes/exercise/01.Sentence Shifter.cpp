#include <iostream>
#include <sstream>
#include <vector>

using namespace std;

class Sentence{
    vector<string> words;
    int count;
    
    public:
    Sentence(istream & istr);
    
    void getShiftedSentence();
    
    void printWords();
};

Sentence::Sentence(istream & istr){
    string text;
    
    getline(istr, text);
    istr >> count;
    
    stringstream ss(text);
    
    string word;
    while (ss >> word){
        words.push_back(word);
    }
}

void Sentence::getShiftedSentence(){
    for (int i = 0; i < count; i++){
        string temp = words[words.size() - 1];
        vector<string>::iterator it = words.begin();
        words.insert(it, temp);
        words.pop_back();
    }
    printWords();
}

void Sentence::printWords(){
    for (string w : words){
        cout << w << endl;
    }
    cout << endl;
}



int main() {
    
    Sentence sentence(cin);
    sentence.getShiftedSentence();
	return 0;
}