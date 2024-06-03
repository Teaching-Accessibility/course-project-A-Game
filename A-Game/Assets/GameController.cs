using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Board board;
    private InputController touchInput;

    public Menu menu;
    public bool inMenu;

    private int count = 3;
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
        menu = GetComponent<Menu>();
        setProbabiliy();
        inMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        manageTouches();
    }

    private void manageTouches()
    {
        switch (touchInput.phase)
        {
            case InputController.Phase.BEGIN:
                singleTouch();
                break;
            case InputController.Phase.HELD:
                if (inMenu == false)
                    heldTouch();
                break;
            case InputController.Phase.DRAG:
                if (inMenu == false)
                    dragTouch();
                break;
            case InputController.Phase.RELEASE:
                if (inMenu == false)
                    releaseTouch();
                break;
        }
    }

    private void singleTouch()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(touchInput.position);
        // Hardcodes values for now
        if (pos.y < -3.5 && pos.x > 2.5) {
            inMenu = true;
            Debug.Log(Screen.height / 2 + " " + pos.y);
            Debug.Log("Entered menu");
            menu.openMenu();
        }
        
        if (inMenu == false)
        {
            activeCell = board.getClosestCell(pos);
            activeCell.tap();
        }
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
        probabilityArray = new int[6][];
        // 100 -> probability %
        probabilityArray[0] = new int[1] { 100 };
        // 67, 33 -> probability %
        probabilityArray[1] = new int[2] { 67, 100 };
        // 58, 28, 14 -> probability %
        probabilityArray[2] = new int[3] { 58, 86, 100 };
        // 54, 26, 13, 7 -> probability %
        probabilityArray[3] = new int[4] { 54, 80, 93, 100 };
        // 52, 27, 12, 6, 3 -> probability %
        probabilityArray[4] = new int[5] { 52, 79, 91, 97, 100 };
        // 52, 25, 12, 6, 3, 2 -> probability %
        probabilityArray[5] = new int[6] { 52, 77, 89, 95, 98, 100 };
    }
}
