using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private InputController touchInput;
    private bool menuStatus;

    //private Vector2 pastPos;
    private Vector2 currentPos;

    public AudioClip intro; // clip
    public AudioSource source;// plays clip

    // Start is called before the first frame update
    void Start()
    {
        touchInput = GetComponent<InputController>();
        menuStatus = false;
        source.PlayOneShot(intro);
        //read the welcome message
        //read instructions once
    }

    // Update is called once per frame
    void Update()
    {
        if (menuStatus)
        {
            manageTouches();
            // make function to repeat what each button does if instructions 
            // are not being read and timer? has expired
        }
    }

    private void manageTouches() 
    {
        switch (touchInput.phase)
        {
            case InputController.Phase.BEGIN:
                Debug.Log("here");
                //pastPos = currentPos;
                currentPos = Camera.main.ScreenToWorldPoint(touchInput.position);
                // if tap is to close and the instructions have not finished reading
                // (make bool) then don't do anything
                // if tap to close and instructions have finished (bool)
                // signal/go back to game
                // if 
                determineAction();
                break;
        }
    }

    private void determineAction() 
    {
        //Vector2 pos = Camera.main.ScreenToWorldPoint(touchInput.position);
        float middle = Screen.height / 2;
        if (currentPos.x > middle) {
            Debug.Log("Read insturctions");
        }
        else
        {
            menuStatus = false;
            //GameController.inMenu = false;
        }
    }

    public void openMenu()
    {
        menuStatus = true;
        Debug.Log("In menu");
    }
    // have an open menu function
    // loops infinite till bool to close is set
}
