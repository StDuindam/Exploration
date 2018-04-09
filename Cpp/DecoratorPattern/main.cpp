#pragma once
#include <iostream>
#include <string>
#include "Decorator.h"
#include "NPC.h"
#include "Elves.h"
#include "FarmerDecorator.h"
#include "ShamanDecorator.h"
#include "Orcs.h"
#include "SoldierDecorator.h"


using namespace std;

int main() {

	NPC* FarmerElf = new FarmerDecorator(new Elves("Simon"));
	NPC* FarmerOrc = new FarmerDecorator(new Orcs("Lo'ker"));
	NPC* SoldierOrc = new SoldierDecorator(new Orcs("Grah-kul"));
	NPC* ShamanElf = new ShamanDecorator(new Elves("Perle"));

	FarmerElf->Render();
	FarmerOrc->Render();
	SoldierOrc->Render();
	ShamanElf->Render();
	
	system("Pause");
	return 0;
}