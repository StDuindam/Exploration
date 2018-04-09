#include "Cell.h"

Cell::Cell(int posx, int posy){
	this->posx = posx;
	this->posy = posy;

	if (rand() % 2 == 1) {
		Death();
	}
	else {
		Life();
	}
}

void Cell::NeedsToChange(bool change){
	isAlive = change;
}

void Cell::Death() {
	isAlive = false;
}

void Cell::Life() {
	isAlive = true;
}

string Cell::Display() {
	if (isAlive) {
		return "0 ";
	}
	else {
		return"  ";
	}
}

void Cell::SaveState() {
	isPreviouslyAlive = isAlive;
}

bool Cell::GetState() {
	return isPreviouslyAlive;
}