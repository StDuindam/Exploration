#pragma once
#include <string>
#include <iostream>
#include "Decorator.h"

class ShamanDecorator : public Decorator
{
public:
	ShamanDecorator(NPC *n);
	void Render();
};

