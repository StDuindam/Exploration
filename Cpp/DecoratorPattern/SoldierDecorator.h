#pragma once
#include <string>
#include <iostream>
#include "Decorator.h"

class SoldierDecorator : public Decorator
{
public:
	SoldierDecorator(NPC *n);
	void Render();
};

