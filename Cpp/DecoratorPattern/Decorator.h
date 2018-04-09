#pragma once
#include "NPC.h"
#include <string>
#include <iostream>

class Decorator : public NPC
{
	NPC* thisNPC;

public:
	Decorator(NPC* n);
	virtual void Render();
};

