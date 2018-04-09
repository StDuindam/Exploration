#pragma once
#include <iostream>
#include <string>

using namespace std;

class Cell{
public:
	Cell(int posx, int posy);
	void NeedsToChange(bool change);
	int liveState, posx, posy;
	void Death();
	void Life();
	string Display();
	bool GetState();
	void SaveState();

private:
	bool isPreviouslyAlive = false;
	bool isAlive = false;
};

