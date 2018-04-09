#pragma once
#include <string>
#include <iostream>
#include "Decorator.h"

class FarmerDecorator : public Decorator
{
public:
	FarmerDecorator(NPC *n);
	void Render();
};

