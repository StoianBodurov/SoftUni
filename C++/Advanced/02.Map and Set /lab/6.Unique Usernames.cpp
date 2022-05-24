#include <iostream>
#include <set>
#include <list>


using namespace std;


int main(){

    int n;
    cin >> n;

    set<string> names;
    list<string> orderedNames;

    for (int i = 0; i < n; i++){
        string name;
        cin >> name;

        names.insert(name);

        if (names.size() > orderedNames.size()){
            orderedNames.push_back(name);
        }
    }

    for (list<string>::iterator it = orderedNames.begin(); it != orderedNames.end(); it++){
        cout << *it << endl;
    }


    return 0;
}