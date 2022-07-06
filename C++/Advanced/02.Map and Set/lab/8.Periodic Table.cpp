#include <iostream>
#include <sstream>
#include <set>

using namespace std;


int main(){

    int n;
    cin >> n;
    set<string>  periodicTable;

    for (int i = 0; i < n; i++){
        string data;
        getline(cin, data);

        stringstream ss(data);

        string element;
        while (ss >> element)
        {
            periodicTable.insert(element);
        }
        
    }

    for (string el: periodicTable){
        cout << el << " ";
    }
    cout << endl;

    return 0;
}