#include <iostream>
#include <vector>
#include <algorithm>

#include "Company.h"


using namespace std;

int main(){

    vector<Company> companies;

    string line;
    while (getline(cin, line) && line != "end")
    {
        istringstream linIn(line);

        int id;
        string name;
        linIn >> name >> id;

        companies.push_back(Company{id, name});
    }

    string sortBy;
    cin >> sortBy;

    bool (*lessThan)(const Company& a, const Company & b);

    if (sortBy == "name"){
        lessThan = [](const Company& a, const Company & b){
            return a.getName() < b.getName();
        };
    }
    else if (sortBy == "id"){
        lessThan = [](const Company& a, const Company & b){
            return a.getId() < b.getId();
        };
    }

    sort(companies.begin(), companies.end(), lessThan);

    for (auto c : companies){
        cout << c.toString() << endl;
    }
    

    return 0;
}