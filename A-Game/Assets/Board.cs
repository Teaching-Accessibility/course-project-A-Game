using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private int cellCount = 8;
    private int cellCount_prev;
    [SerializeField]
    private float distanceOut = 3;
    [SerializeField]
    private bool displayGfx;
    private Cell[] cells;

    // Start is called before the first frame update
    void Awake()
    {
        cells = initializeCells(cellCount);
        cellCount_prev = cellCount;
    }

    private void OnValidate()
    {
        cellCount = Mathf.Max(0, cellCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (cellCount != cellCount_prev)
        {
            clearCells(cells);
            cells = initializeCells(cellCount);
            cellCount_prev = cellCount;
        }
    }

    private Cell[] initializeCells(int cellCount)
    {
        Cell[] cellArr = new Cell[cellCount];
        
        for(int i = 0; i < cellCount; i++)
        {
            GameObject obj = Cell.MakeObj(getWorldPosAt(getIthPos(i)), transform);
            cellArr[i] = obj.GetComponent<Cell>();
        }

        return cellArr;
    }

    private void clearCells(Cell[] cellArr)
    {
        foreach(Cell cell in cellArr)
        {
            GameObject.Destroy(cell.gameObject);
        }
        
    }

    private Vector2 getWorldPosAt(float pos)
    {
        var r = distanceOut;
        return transform.position + new Vector3(
            Mathf.Sin(pos)* r,
            Mathf.Cos(pos)* r
            );
    }

    private float getIthPos(int i, int cellCount)
    {
        return ((2 * Mathf.PI) / cellCount) * i;
    }

    private float getIthPos(int i)
    {
        return getIthPos(i, cellCount);
    }

    private void OnDrawGizmos()
    {
        if(displayGfx)
        {
            foreach(Cell cell in cells)
            {
                Gizmos.DrawLine(transform.position, cell.gameObject.transform.position);
            }
        }
    }
}
