using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private InputController touchInput;
    private bool menuStatus;

    private Vector2 currentPos;

    public AudioClip intro; // clip
    public AudioSource source; // plays clip

    // Start is called before the first frame update
    void Start()
    {
        touchInput = GetComponent<InputController>();
        menuStatus = false;
        source.PlayOneShot(intro);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuStatus)
        {
            manageTouches();
            // if not reading instructions and time
            // has passed sense last menu option read
            // read menu options again
        }
    }

    private void manageTouches() 
    {
        switch (touchInput.phase)
        {
            case InputController.Phase.BEGIN:
                currentPos = Camera.main.ScreenToWorldPoint(touchInput.position);
                determineAction();
                break;
        }
    }

    private void determineAction() 
    {
        if (currentPos.y > 0) {
            Debug.Log("Read insturctions");
            // set reading to true
        }
        else
        {
            Debug.Log("Exiting menu");
            menuStatus = false;
            //GameController.inMenu = false;
        }
    }

    public void openMenu()
    {
        // Menu is not already opened
        if (!menuStatus)
        {
            // Read welcome audio
            // and then menu options
        }
        menuStatus = true;
        Debug.Log("In menu");
    }
}
