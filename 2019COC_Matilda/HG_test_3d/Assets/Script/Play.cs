using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Play : MonoBehaviour
{
    private AudioSource theAudio;

    [SerializeField] private AudioClip[] clip;

    public static float Max = 0.8f;
    public static float Min = 0.0f;

    // Use this for initialization
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
        theAudio.volume = 0.4f;
    }   

    public void PlaySE()
    {
        int _temp = Random.Range(0, 3);

        Debug.Log(_temp);
        theAudio.clip = clip[_temp];
        theAudio.Play();
    }

    public void Mute()
    {
        if (theAudio.mute)
            theAudio.mute = false;
        else
            theAudio.mute = true;

    }

    public void VolumeDown()
    {
        if (theAudio.volume > Min) theAudio.volume -= 0.2f;
    }

    public void VolumeUp()
    {
        if (theAudio.volume < Max) theAudio.volume += 0.2f;
    }
}