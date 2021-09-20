using UnityEngine;
using CodeMonkey.Utils;

public class TestGrid : MonoBehaviour
{

    private GridField<bool> grid;
    void Start()
    {
        grid = new GridField<bool>(22, 12, 10f, new Vector3(0, 0));
    }

    // Update is called once per frame
    void Update()
    {   
        //for clicking on grid to set value
        if(Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), true);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
        

    }
}
