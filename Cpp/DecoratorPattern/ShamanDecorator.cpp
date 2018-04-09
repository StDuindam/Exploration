#include "ShamanDecorator.h"

ShamanDecorator::ShamanDecorator(NPC* n) : Decorator(n) {}

void ShamanDecorator::Render()
{
	cout << "Shaman";
	Decorator::Render();

}


