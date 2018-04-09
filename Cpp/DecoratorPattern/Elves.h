#pragma once
#include "NPC.h"
#include <string>
#include <iostream>
using namespace std;

class Elves : public NPC
{
	NPC* npc;

public:
	Elves(string Name);
	void Render() {
		cout << " Elf " << myName << endl;
	}
private:
	string myName;
};

