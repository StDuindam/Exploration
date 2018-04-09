#include "FarmerDecorator.h"

FarmerDecorator::FarmerDecorator(NPC* n) : Decorator(n) {}

void FarmerDecorator::Render()
{
	cout << "Farmer";
	Decorator::Render();

}


