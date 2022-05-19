#include <iostream>
#include <deque>
#include <sstream>

using namespace std;

int main(){
    string data;
    getline(cin, data);
    int count;
    cin >> count;

    stringstream ss(data);
    deque<string> children;

    string name;
    while (ss >> name)
    {
        children.push_back(name);
    }
    int n = 0;
    while (true)
    {
        if (children.size() == 1){
            break;
        }
        n++;

        if (n != count){
            string temp;
            temp = children.front();
            children.pop_front();

            children.push_back(temp);

        }else{
            cout << "Removed " << children.front() << endl;
            children.pop_front();
            n = 0;
        }
    }
    
    
    cout << "Last is " << children.back() << endl;
    return 0;
}