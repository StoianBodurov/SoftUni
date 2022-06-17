#include <iostream>
#include <vector>
#include <map>
#include <regex>

using namespace std;

void getData(string &data, string &name, string &cordinats){
    vector<string> tempVector;
    string tempString = "";
    for (int i = 0; i < data.size(); i++){
        if (data[i] == ','){
            tempVector.push_back(tempString);
            tempString = "";
            continue;
        }
        tempString += data[i];
    }
    tempVector.push_back(tempString);


    name = tempVector[0];
    cordinats = tempVector[1] + " " + tempVector[2];
    
}

int main() {
    string inputData;

   

    map<string, string> nameToLocation;
    map<string, vector<string>> locationToName;

    while (true)
    {
        string inputData;
        getline(cin, inputData);
        string locationName;
        string locationCordinats;

        if (inputData == "."){
            break;
        }

        getData(inputData, locationName, locationCordinats);

        nameToLocation[locationName] = locationCordinats;
        locationToName[locationCordinats].push_back(locationName);
        
    }

    while (true)
    {
        string inputData;
        getline(cin, inputData);
        if (inputData == "."){
            break;
        }

        if (isdigit(inputData[inputData.size() - 1])){
            map<string, vector<string>>::iterator it;
            it = locationToName.find(inputData);
            if (it != locationToName.end()){
                for(int i = 0; i < locationToName[inputData].size(); i++){
                    cout << locationToName[inputData][i] << "," << regex_replace(nameToLocation[locationToName[inputData][i]], regex(" "), ",") << endl;
                }
            }
        }else{
            map<string, string>::iterator it;
            it = nameToLocation.find(inputData);
            if (it != nameToLocation.end()){
                cout << inputData << "," << regex_replace(nameToLocation[inputData], regex(" "), ",") << endl;
            }
        }
    }
    

    return 0;
}