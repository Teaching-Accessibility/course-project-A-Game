using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    private AudioSource audio;

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
        if(sound != null)
        {
            playSound();
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
                    addSound(sound.getNext());
                    otherCell.sound = null;
                }
            }
        }
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


}
