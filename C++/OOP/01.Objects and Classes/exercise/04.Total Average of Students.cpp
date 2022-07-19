#include <iostream>
#include <math.h>
#include <iomanip>
#include <vector> 
#include <map>

using namespace std;

class Student{
    public:
        string firstName;
        string lastName;
        double averageGrade;

    public:
        Student(istream & istr);
        Student();
        
};

Student::Student(istream & istr){
    istr >> firstName >> lastName >> averageGrade;
}

Student::Student(){
    firstName = "";
    lastName = "";
    averageGrade = 0; 
}

int main(){
    int n;
    cin >> n;
    vector<Student> students;
    
    for (int i = 0; i < n; i++){
        Student s(cin);
        students.push_back(s);
    }
    
    if (students.size() == 0){
        cout << "Invalid input";
    }else{
        double averageAllStudent = 0;
    for (Student s:students){
        cout << s.firstName << " " << s.lastName << " " << s.averageGrade << endl;
        averageAllStudent += s.averageGrade;
    }
    cout << averageAllStudent / n << endl;
    }
    


    return 0;
}