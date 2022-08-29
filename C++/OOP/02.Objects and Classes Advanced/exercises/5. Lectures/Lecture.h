#ifndef LECTURE_H
#define LECTURE_H

#include <set>
#include <map>

#include "Resource.h"
#include "ResourceType.h"

using namespace std;

namespace SoftUni{
    class Lecture{
        private:
        set<Resource> resorces;
        map<ResourceType, int> numberOfResourceByType;
        
        public:
        Lecture(){}

        set<Resource>::iterator begin()const{
        
            return resorces.begin();
        }
        
        set<Resource>::iterator end()const{
            return resorces.end();
        }

        void updateResource(Resource r){
            if(resorces.find(r) != resorces.end()){
                resorces.erase(r);
                numberOfResourceByType[r.getType()]--;
            }
            auto iteratorAndSuccess = resorces.insert(r);
            numberOfResourceByType[r.getType()]++;
        }

        int operator[](ResourceType t){
            return numberOfResourceByType.at(t);
        }

        friend vector<ResourceType>& operator<<(vector<ResourceType>& v, const Lecture& lecture);

    };

    Lecture& operator<<(Lecture& lecture, Resource resource){
        lecture.updateResource(resource);
        return lecture;
    }

    vector<ResourceType>& operator<<(vector<ResourceType>& v, const Lecture& lecture){
        for(auto pair : lecture.numberOfResourceByType){
            v.push_back(pair.first);
        }
        return v;
    }

}

#endif