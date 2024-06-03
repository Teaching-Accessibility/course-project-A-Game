using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool inMenu = false;
    public Board board;
    private InputController touchInput;

    public static int count = 0;
    private int[][] probabilityArray;

    private Cell activeCell;
    private Cell nextCell;

    [SerializeField]
    private float spawnTime = 3;

    [SerializeField]
    private Sound[] spawnables;


    // Start is called before the first frame update
    void Start()
    {
        touchInput = GetComponent<InputController>();
        setProbabiliy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMenu)
        {
            manageTouches();
        }
    }

    private void manageTouches()
    {
        switch (touchInput.phase)
        {
            case InputController.Phase.BEGIN:
                singleTouch();
                break;
            case InputController.Phase.HELD:
                    heldTouch();
                break;
            case InputController.Phase.DRAG:
                    dragTouch();
                break;
            case InputController.Phase.RELEASE:
                    releaseTouch();
                break;
        }
    }

    private void singleTouch()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(touchInput.position);
        activeCell = board.getClosestCell(pos);
        activeCell.tap();
    }

    private void heldTouch()
    {
        if(touchInput.holdTime >= spawnTime)
        {
            //board.addSoundToBoard(spawnables[Random.Range(0, spawnables.Length - 1)]);
            if (activeCell.empty())
            {
                int randomProp = Random.Range(0, 100);
                int spawnableIndex = 0;
                for (int i = 0; i < probabilityArray[count].Length; i++)
                {
                    if (i == 0 && randomProp <= probabilityArray[count][i])
                    {
                        spawnableIndex = i;
                    }
                    else if (randomProp <= probabilityArray[count][i] && randomProp >= probabilityArray[count][i-1]) 
                    { 
                        spawnableIndex = i;
                    } 
                }
                activeCell.addSound(spawnables[spawnableIndex]);
            }
        }
    }

    private void dragTouch()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(touchInput.position);
        Vector2 startPos = Camera.main.ScreenToWorldPoint(touchInput.rawPosition);
        var cell = board.getClosestCell(pos);
        if(nextCell != cell)
        {
            nextCell = cell;
            if (cell != activeCell)
            {
                cell.playSound();
            }
        }
        
        Debug.DrawLine(startPos, pos, Color.white);
        Debug.DrawLine(activeCell.transform.position, nextCell.transform.position, Color.cyan);
    }

    private void releaseTouch()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(touchInput.position);
        nextCell = board.getClosestCell(pos);
        nextCell.release(activeCell);
    }

    private void setProbabiliy()
    {
        probabilityArray = new int[3][];
        // 100 -> probability %
        probabilityArray[0] = new int[1] { 100 };
        // 67, 33 -> probability %
        probabilityArray[1] = new int[2] { 67, 100 };
        // 58, 28, 14 -> probability %
        probabilityArray[2] = new int[3] { 58, 86, 100 };
    }
}
