using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    private AudioSource audio;
    private ArrayList generatedSounds = new ArrayList();
    private int generatedCount = 0;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public static GameObject MakeObj(Vector2 pos, Transform parent)
    {
        GameObject obj = new GameObject("Cell");
        Cell cell = obj.AddComponent<Cell>();
        obj.transform.position = pos;
        obj.transform.parent = parent;
        return obj;
    }

    public void tap()
    {
        Debug.Log("Cell tapped");
        if (sound != null)
        {
            playSound();
        }
        else
        { 
            audio.Play();
        }
    }

    public void release(Cell otherCell)
    {
        Debug.Log("cell released");
        if (!otherCell.empty() && otherCell != this)
        {
            if(empty())
            {
                //addSound(otherCell.sound);
                //otherCell.sound = null;
            }
            else
            {
                if(sound == otherCell.getSound())
                {
                    mergeWith(otherCell);
                }
            }
        }
    }

    private void mergeWith(Cell otherCell)
    {
        if (generatedCount < 3 && alreadyGenerated(sound.getNext()) == false)
        { 
            generatedSounds.Add(sound.getNext());
            generatedCount++;
            GameController.count++;
        }
        addSound(sound.getNext());
        otherCell.sound = null;
    }

    public void playSound()
    {
        audio.PlayOneShot(sound.getAudioClip());
    }

    public void addSound(Sound sound)
    {
        this.sound = sound;
        audio.PlayOneShot(sound.getAudioClip());
    }

    public Sound getSound()
    {
        return sound;
    }

    public bool empty()
    {
        return sound == null;
    }

    public bool alreadyGenerated(Sound sound)
    {
        return generatedSounds.Contains(sound);
    }

}
