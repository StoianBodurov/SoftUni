#include <iostream>
#include <math.h>
#include <iomanip>
#include <vector> 
#include <map>

using namespace std;

class Sale{
    public:
        string town;
        string product;
        double price;
        double quantity;
    
    public:
        Sale(istream & istr){
            istr >> town >> product >> price >> quantity;
        }
        Sale(){
            town = "";
            product = "";
            price = 0;
            quantity = 0;
        }
};

int main(){
    int n;
    cin >> n;
    vector<Sale> sales;
    
    for (int i = 0; i < n; i++){
        Sale s(cin);
        sales.push_back(s);
    }
    
    map<string, double> result;
    for (Sale s:sales){
        result[s.town] += s.price * s.quantity;
    }
    
    cout << setprecision(2) << fixed;
    for (map<string, double>::iterator it = result.begin(); it != result.end(); it++){
        cout << it->first << " -> " << it->second << endl;
    }
    return 0;
}