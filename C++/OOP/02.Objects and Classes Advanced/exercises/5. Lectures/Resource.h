#ifndef RESOURCE_H
#define RESOURCE_H

#include <iostream>


#include "ResourceType.h"

using namespace std;

namespace SoftUni {
	class Resource {
	private:
		int id;
		ResourceType type;
		string link;

	public:
		Resource() {}

		Resource(int id, ResourceType type, string link): id(id), type(type), link(link){}

		int getId() const {
			return this->id;
		}

		ResourceType getType() const {
			return this->type;
		}

		string getLink() const {
			return this->link;
		}

		bool operator<(const Resource& other) const {
			return this->id < other.id;
		}
	};
	ostream& operator<<(ostream& out, const Resource& r) {
		return out << r.getId() << " " << r.getType() << " " << r.getLink();
	}

	istream& operator>>(istream& in, Resource& r) {
		int id;
		string typeString;
		string link;

		in >> id >> typeString >> link;

		ResourceType type;

		if (typeString == "Presentation") {
			type = ResourceType::PRESENTATION;
		}
		else if (typeString == "Demo") {
			type = ResourceType::DEMO;
		}
		else if (typeString == "Video") {
			type = ResourceType::VIDEO;
		}

		r = Resource(id, type, link);

			return in;	
	}

}

#endif // !RESOURCE_H
