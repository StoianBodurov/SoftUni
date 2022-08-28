#ifndef OPERATORS_H
#define OPERATORS_H

#include <iostream>
#include <vector>
#include <sstream>

using namespace std;

ostream& operator<<(ostream& out, const vector<string>& v){
    for(string s : v){
        out << s << endl;
    }
    return out;
}

vector<string>& operator<<(vector<string>& v, const string& s){
    v.push_back(s);
    return v;
} 

string operator+(string s, int i){
    ostringstream result;
    result << s << i;

    return result.str();
}

#endif