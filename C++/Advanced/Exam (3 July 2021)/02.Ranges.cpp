#include <iostream>
#include <sstream>
#include <vector>
#include <string>
#include <list>

using namespace std;

int main(){
    list<vector<int>> ranges;

    while (true)
    {
        string input;
        getline(cin, input);

        if (input == "."){
            break;
        }

        stringstream ss(input);
        int n;
        vector<int> temp;
        while (ss >> n)
        {
            temp.push_back(n);
        }

        ranges.push_back(temp);
        
    }

    while (true)
    {
        string input;
        cin >> input;

        if (input == "."){
            break;
        }
        bool isInRange = false;
        int n = stoi(input);
        for (auto i = ranges.begin();i != ranges.end(); i++ ){
            int s;
            int e;
            int index = 0;
            for (auto j = i->begin(); j != i->end(); j++){
                if (index == 0){
                    s = *j;
                }else{
                    e = *j;
                }
            }

            if(s <= n && e >= n){
                isInRange = true;
                break;
            }
        }

        if (isInRange){
            cout << "in";
        }else{
            cout << "out";
        }
        cout << endl;
    }
    
    
    return 0;
}