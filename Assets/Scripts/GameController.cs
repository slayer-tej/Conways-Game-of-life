using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static int ScreenWidth = 10 ;
    private static int ScreenHeight = 10;
    private Vector2 MousePos;
    private int Timer;

    CellController[,] grid = new CellController[ScreenWidth, ScreenHeight];

    private void Start()
    {
        FillCells();
    }

    private void FillCells()
    {
        for(int y = 0;y < ScreenHeight; y++)
        {
            for(int x = 0; x < ScreenWidth; x++)
            {
                CellController cell = Instantiate(Resources.Load("Prefabs/Cell1", typeof(CellController)), 
                    new Vector2(x, y), Quaternion.identity) as CellController;
                    grid[x, y] = cell;
                    grid[x, y].SetAlive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CountNeighbours();
            PopulationControl();
        }
        if (Input.GetMouseButtonDown(0))
        {
            MousePos = Input.mousePosition;
            int x = Convert.ToInt32(MousePos.x);
            int y = Convert.ToInt32(MousePos.y);
            grid[x, y].SetAlive(true);
        }
    }
    
    private void PopulationControl()
    {
        for (int y = 0; y < ScreenHeight; y++)
        {
            for (int x = 0; x < ScreenWidth; x++)
            {
                if (grid[x, y].isAlive)
                {
                    if (grid[x, y].numOfNeighbours != 2 && grid[x,y].numOfNeighbours != 3)
                        grid[x, y].SetAlive(false);
                }
                else
                {
                    if (grid[x, y].numOfNeighbours == 3)
                        grid[x, y].SetAlive(true);
                }
            }
        }
    }

    private void CountNeighbours()
    {
        for (int y = 0; y < ScreenHeight; y++)
        {
            for (int x = 0; x < ScreenWidth; x++)
            {
                int numNeighbours = 0;
                if(x+1 < ScreenWidth)
                {
                    if (grid[x + 1, y].isAlive)
                        numNeighbours++;
                }
                if (y + 1 < ScreenHeight)
                {
                    if (grid[x, y+1].isAlive)
                        numNeighbours++;
                }
                if (x - 1 >= 0)
                {
                    if (grid[x - 1, y].isAlive)
                        numNeighbours++;
                }
                if (y - 1 >= 0)
                {
                    if (grid[x, y-1].isAlive)
                        numNeighbours++;
                }
                if (x + 1 < ScreenWidth && y + 1 < ScreenHeight)
                {
                    if (grid[x + 1, y+1].isAlive)
                        numNeighbours++;
                }
                if (x + 1 < ScreenWidth && y - 1 >= 0)
                {
                    if (grid[x + 1, y - 1].isAlive)
                        numNeighbours++;
                }
                if (x - 1 >=0 && y - 1 >= 0)
                {
                    if (grid[x - 1, y - 1].isAlive)
                        numNeighbours++;
                }
                if (x - 1 >=0 && y + 1 < ScreenHeight)
                {
                    if (grid[x - 1, y + 1].isAlive)
                        numNeighbours++;
                }
                grid[x, y].numOfNeighbours = numNeighbours;
            }
        }
    }
}
