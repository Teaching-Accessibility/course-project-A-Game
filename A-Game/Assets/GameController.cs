using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Board board;
    private TouchController touchInput;

    [SerializeField]
    private Cell activeCell;
    private Cell nextCell;


    // Start is called before the first frame update
    void Start()
    {
        touchInput = GetComponent<TouchController>();
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
            case TouchController.Phase.BEGIN:
                singleTouch();
                break;
            case TouchController.Phase.DRAG:
                dragTouch();
                break;
            case TouchController.Phase.RELEASE:
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

    private void dragTouch()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(touchInput.position);
        Vector2 startPos = Camera.main.ScreenToWorldPoint(touchInput.rawPosition);
        nextCell = board.getClosestCell(pos);
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
