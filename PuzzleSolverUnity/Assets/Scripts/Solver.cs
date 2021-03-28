﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour
{

    public GameObject ButtonPrefab;
    public GameObject canvas;

    public int Solutions = 20;

    // Start is called before the first frame update
    void Start()
    {
        m_PuzzleSolver = new PuzzleSolver();
        m_PuzzleSolver.GenerateDefaultLayout();
        m_PuzzleSolver.SolvePuzzle();

        int Solutions = m_PuzzleSolver.GetNumSolutions();

        Debug.Log("Solutions: " + Solutions.ToString());


        int RowsCount = (Solutions - 1) / 10;

        for(int i = 0; i < Solutions; i++)
        {
            GameObject newButton = Instantiate<GameObject>(ButtonPrefab);

            //Set position before placing inside the Canvas
            int InitialXPos = 400 - (RowsCount * 45);
            int InitialYPos = 200;

            int XOffset = 45 * (i / 10);
            int YOffset = 45 * (i % 10);

            int XPos = InitialXPos + XOffset;
            int YPos = InitialYPos - YOffset;

            newButton.transform.position = new Vector3(XPos, YPos);
            newButton.transform.SetParent(canvas.transform, false);

            //Setup the variables
            SolutionButton solutionButton = newButton.GetComponent<SolutionButton>();
            solutionButton.SolutionIndex = i;
            solutionButton.solver = this;
        }
    }


    public void DisplaySolution(int solutionNum)
    {
        Debug.Log("Button pressed: " + solutionNum.ToString());
    }


    PuzzleSolver m_PuzzleSolver;
}