using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioClip snd;
    [SerializeField]
    private Sound next;

    public AudioClip getAudioClip()
    {
        return snd;
    }

    public Sound getNext()
    {
        return next;
    }
}
