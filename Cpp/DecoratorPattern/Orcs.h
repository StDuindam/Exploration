#pragma once
#include "NPC.h"
#include <string>
#include <iostream>
using namespace std;

class Orcs : public NPC
{
	NPC* npc;

public:
	Orcs(string Name);
	void Render() {
		cout << " Orcs " << myName << endl;
	}
private:
	string myName;
};

