using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 position;
    public Vector2 rawPosition;

    public enum Phase
    {
        IDLE,
        BEGIN,
        HELD,
        DRAG,
        RELEASE
    };

    public Phase phase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        phase = Phase.IDLE;
        if (Input.GetMouseButton(0))
        {
            position = Input.mousePosition;

            if(Input.GetMouseButtonDown(0))
            {
                phase = Phase.BEGIN;
                rawPosition = position;
            }
            else if(rawPosition == position)
            {
                phase = Phase.HELD;
            }
            else
            {
                phase = Phase.DRAG;
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            phase = Phase.RELEASE;
        }
    }
}
