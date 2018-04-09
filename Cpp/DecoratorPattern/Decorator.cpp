#include "Decorator.h"


Decorator::Decorator(NPC* n)
{
	thisNPC = n;
}

void Decorator::Render()
{
	thisNPC->Render();
}
