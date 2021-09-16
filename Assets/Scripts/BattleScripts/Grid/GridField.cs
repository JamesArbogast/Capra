using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridField
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public GridField(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int j = 0; j < gridArray.GetLength(1); j++)
            {
                UtilsClass.CreateWorldText(gridArray[x, j].ToString(), null, GetWorldPosition(x, j) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, j), GetWorldPosition(x, j + 1), Color.white, 100f) ;
                Debug.DrawLine(GetWorldPosition(x, j), GetWorldPosition(x + 1, j), Color.white, 100f);

            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int j) 
    {
        return new Vector3(x, j) * cellSize;
    }

    public void SetValue(int x, int j, int value)
    {
        if (x >= 0 && j >= 0 && x < width && j < height)
        {
            gridArray[x, j] = value;
        }
    }
}
