#include <iostream>
#include <string>
#include <sstream>
#include <map>
#include <algorithm>
#include <vector>

using namespace std;

int main(){

  map<string, int> resorses;
  vector<string> order;
  
  int count = 0;
  string resurs;
  
  while(true){
      count++;
      string command;
      cin >> command;
      
      
      
      if (command == "stop"){
          break;
      }
      
      if (count % 2 != 0){
          resurs = command;
          if (find(order.begin(), order.end(), resurs) == order.end()){
              order.push_back(resurs);
          }
      }else{
          resorses[resurs] += stoi(command);
      }
  }
  
  for (int i = 0; i < order.size(); i++){
      cout << order[i] << " -> " << resorses[order[i]] << endl;
  }
   
    return 0;
}