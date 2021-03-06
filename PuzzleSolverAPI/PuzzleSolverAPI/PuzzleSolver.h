#pragma once
#include <vector>
#include "Piece.h"
#include <sstream>
#include <functional>

class PuzzleSolver
{
	std::function<void(std::vector<Piece>&)> DrawFunction;

public:
	PuzzleSolver();
	~PuzzleSolver();

	void GenerateDefaultLayout();
	void GenerateLayoutFromFile(const char* filepath);
	void GenerateLayoutFromIntArr(int* dataArr);

	void SolvePuzzle();

	int GetNumSolutions();

	Piece  GetPieceAtIndex(int index);
	Piece* GetSolutionAtIndex(int index);

	void SetDrawFunction(std::function<void(std::vector<Piece>&)> drawFunc);
	void DrawSolutions();

private:
	inline bool IsUniqueSetOf2(std::vector<Piece>& p1, std::vector<Piece>& p2)
	{
		return
			p1[0]._Index != p2[0]._Index &&
			p1[0]._Index != p2[1]._Index &&
			p1[1]._Index != p2[0]._Index &&
			p1[1]._Index != p2[1]._Index;
	}

private:
	BaseShape _Shapes[8];
	std::vector<Piece> _Pieces;
	std::vector<std::vector<Piece>> _Solutions;

};

