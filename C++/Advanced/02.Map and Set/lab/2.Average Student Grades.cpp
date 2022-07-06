#include <iostream>
#include <map>
#include <vector>
#include <algorithm>
#include <numeric>
#include <iomanip>


using namespace std;

int main(){
    int n;
    cin >> n;

    map<string, vector<float>> students;
    vector<string> studentsByOrder;

    for (int i = 0; i < n; i++){
        string name;
        float grade;
        cin >> name;
        cin >> grade;


        students[name].push_back(grade);
        if (find(studentsByOrder.begin(), studentsByOrder.end(), name) == studentsByOrder.end()){
            studentsByOrder.push_back(name);
        }


    }

    for (int i = 0; i < studentsByOrder.size(); i++){
        float averageGrade = accumulate(students[studentsByOrder[i]].begin(), students[studentsByOrder[i]].end(), 0.0) / students[studentsByOrder[i]].size();

        cout << studentsByOrder[i] << " -> ";

        for (int j = 0; j < students[studentsByOrder[i]].size(); j++){
            cout << setprecision(2) << fixed << students[studentsByOrder[i]][j] << " ";
        }

        cout << "(avg: " << setprecision(2) << fixed << averageGrade << ")" << endl;
    }

    return 0;
}