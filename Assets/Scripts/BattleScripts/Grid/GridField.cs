using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridField
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public GridField(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        //creates battle grid
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f) ;
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);

            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        //Example of setting grid value
        //SetValue(2, 1, 56);
    }

    //translates grid to world position
    private Vector3 GetWorldPosition(int x, int y) 
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    //translates world position into grid position
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition / cellSize - originPosition).y);
    }

    //set grid value with xPos, yPos, and value entered into square
    public void SetValue(int x, int y, int value)
    {
        if (y >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    //set grid value by using world position (eg. click) and value entered into square
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    //gets gridarray value (multidimensional array)
    public int GetValue(int x, int y)
    {
        if (y >= 0 && y >= 0 && x < width && x < height)
        {
            return gridArray[x, y];
        } 
        else
        {
            return 0;
        }
    }

    //returns gridarray value (multidimensional array)
    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
