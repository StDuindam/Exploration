#pragma once
#include <iostream>
#include "Cell.h"
#include <string>
using namespace std;

class Grid{
public:
	static const int MAX_NEIGHBOURS = 3, MIN_NEIGHBOURS = 2, GRID_SIZE = 20, BIRTH = 3;
	Grid();
	void AddCells();
	Cell* grid[Grid::GRID_SIZE][Grid::GRID_SIZE];
	void CheckNeighbours(Cell* c);
	void GridDisplay();
	void GenerateNewGrid();

private:
	int aliveNeighbours;
};

