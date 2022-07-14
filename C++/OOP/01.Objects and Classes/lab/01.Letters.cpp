#include <iostream>
#include <set>
#include <sstream>
#include <regex>
#include <algorithm>

using namespace std;

class Letters
{
    private:
        set<string> words;

    public:
        Letters(istream &istr);

        void getWords(char ch);

    private:
        string toLowerCase(const string & word);
};

Letters::Letters(istream &istr)
{
    string text;

    getline(istr, text);

    stringstream ss(text);

    string word;
    while (ss >> word)
    {
        words.insert(regex_replace(word, regex("[.,!?;:]"), ""));
    }
};

void Letters::getWords(char ch)
{

    bool isWordContain = false;
    for (string word : words)
    {
        string tempword = toLowerCase(word);
        string::iterator it = find(tempword.begin(), tempword.end(), tolower(ch));
        if (it != tempword.end())
        {
            cout << word << ' ';
            isWordContain = true;
        }
    }

    if (!isWordContain)
    {
        cout << "---";
    }
    cout << endl;
};

string Letters::toLowerCase(const string & word){
    string tempWord = "";

     for (int j = 0; j < word.size(); j++){
                tempWord += tolower(word[j]);
            }

    return tempWord;
};

int main()
{

    Letters letters(cin);
    char ch;
    while (cin >> ch)
    {

        if (ch == '.')
        {
            break;
        }

        letters.getWords(ch);
    }


    return 0;
}

/*
You are given a text in English. Let’s define a word as any sequence of alphabetical characters. Each of those characters we’ll call a letter, but we will consider the uppercase and lowercase variant of a character in a word as the same letter.
a
Y
h
.
*/