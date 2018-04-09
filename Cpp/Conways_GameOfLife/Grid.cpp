#include "Grid.h"
using namespace std;

Grid::Grid(){
	AddCells();
}

void Grid::CheckNeighbours(Cell* c)//Check for the rules of Game Of Life
{
	int aliveNeighbours = 0;
	for (int i = c->posx - 1; i <= c->posx + 1; i++) {
		if(i >= 0 && i < GRID_SIZE){
			for (int j = c->posy - 1; j <= c->posy + 1; j++) {
				if(j >= 0 && j < GRID_SIZE){
					if (grid[i][j]->GetState()) {
						aliveNeighbours += 1;
					}
				}
			}
		}
	}
	if (c->GetState()) {
		aliveNeighbours -= 1;
	}
	if (aliveNeighbours > MAX_NEIGHBOURS || aliveNeighbours < MIN_NEIGHBOURS && c->GetState()){
		c->NeedsToChange(false);
	}

	else if (aliveNeighbours == 3 && c->GetState() == false) {
		c->NeedsToChange(true);
	}
}

void Grid::AddCells() {//Create the grid including cells
	for (int i = 0; i < GRID_SIZE; i++) {
		for (int j = 0; j < GRID_SIZE; j++) {
			grid[i][j] = new Cell(i, j);
		}
	}
}

void Grid::GridDisplay() {//Print the grid
	for (int i = 0; i < GRID_SIZE; i++) {
		for (int j = 0; j < GRID_SIZE; j++) {
			cout << grid[i][j]->Display();
		}
		cout << endl;
	}
	cout << endl;
}

void Grid::GenerateNewGrid() {
	//GridDisplay
	GridDisplay();

	//forloop savestate
	for (int i = 0; i < GRID_SIZE; i++) {
		for (int j = 0; j < GRID_SIZE; j++) {
			grid[i][j]->SaveState();
		}
	}
	//CheckNeighbours
	for (int i = 0; i < GRID_SIZE; i++) {
		for (int j = 0; j < GRID_SIZE; j++) {
			CheckNeighbours(grid[i][j]);
		}
	}
	cout << "reached code" << endl;
}