#include <iostream>
#include <deque>

using namespace std;


int main(){

    string data;
    cin >> data;

    deque<char> sequence;

    for (int i = 0; i < data.length(); i++){
        sequence.push_back(data[i]);
    }

    bool isBalanced = true;

    if (sequence.size() % 2 != 0){
        cout << "NO" << endl;
        return 0;
    }

    while (!sequence.empty())
    {
        if (sequence.front() == '{'){
            if (sequence.back() != '}'){
                isBalanced = false;
                break;
            }
        }else if (sequence.front() == '['){
            if (sequence.back() != ']'){
                isBalanced = false;
                break;
            }
        }else if(sequence.front() == '('){
            if (sequence.back() != ')'){
                isBalanced = false;
                break;
            }
        }

        sequence.pop_back();
        sequence.pop_front();
    }
    
    if (isBalanced){
        cout << "YES" << endl;
    }else{
        cout << "NO" << endl;
    }

    return 0;
}