using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathnode
{

    private GridField grid;
    private int x;
    private int y;

    //movement costs
    public int gCost;
    public int hCost;
    public int fCost;

    //node we came from previously
    public Pathnode cameFromNode;

    public Pathnode(GridField grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return x + ", " + y;
    }
}
