using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Board board;
    private InputController touchInput;

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
                activeCell.addSound(spawnables[Random.Range(0, spawnables.Length - 1)]);
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
}
