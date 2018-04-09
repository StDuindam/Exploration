#include <iostream>
#include <string>
#include "Cell.h"
#include "Grid.h"
#include <time.h>
#pragma once

using namespace std;


int main() {

	//lilGrid

	Grid* Grid1 = new Grid();

	clock_t t;
	float deltaTime = 0;
	float timePassed = 0;
	t = clock();
	double framerate = 0.25;

	Grid1->GenerateNewGrid();
	Grid1->GenerateNewGrid();
	Grid1->GenerateNewGrid();
	
	while (true) {
		deltaTime = ((float)(clock() - t)) / CLOCKS_PER_SEC;
		t = clock();
		timePassed += deltaTime;

		if (timePassed > (framerate)) {
			Grid1->GenerateNewGrid();
			std::cout << std::flush;
			timePassed -= (framerate);
		}

	}

	//system("pause");
	return 0;
}