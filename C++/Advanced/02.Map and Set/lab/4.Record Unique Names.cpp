#include <iostream>
#include <set>
#include <list>


using namespace std;


int main(){
    int n;
    cin >> n;

    set<string> names;
    list<string> orderedName;

    for (int i = 0; i < n; i++){
        string name;
        cin >> name;

        names.insert(name);
        if (names.size() != orderedName.size()){
            orderedName.push_back(name);
        }
    }
    
     for (list<string>::iterator it = orderedName.begin(); it != orderedName.end(); it++){
        cout << *it << endl;
    }

    return 0;
}