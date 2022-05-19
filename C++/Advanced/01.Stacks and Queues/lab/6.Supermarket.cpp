#include <iostream>
#include <queue>

using namespace std;


int main(){

    queue<string> que;

    while (true)
    {
        string data;
        cin >> data;

        if (data == "End"){
            break;
        }

        if (data == "Paid"){
            while (!que.empty())
            {
               cout << que.front() << endl;
               que.pop(); 
            }
            
        }else{
            que.push(data);
        }
    }

    cout << que.size() << " people remaining." << endl;
    
    return 0;
}