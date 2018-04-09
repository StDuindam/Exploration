#include "SoldierDecorator.h"

SoldierDecorator::SoldierDecorator(NPC* n) : Decorator(n) {}

void SoldierDecorator::Render()
{
	cout << "Soldier";
	Decorator::Render();

}


