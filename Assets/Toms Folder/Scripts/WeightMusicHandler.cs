using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WeightMusicHandler : MonoBehaviour
{
    private AudioSource music;
    private float startMusicVolume = 0;
    public float musicVolume = 10; // make it's own class for the player to control
    //public AudioClip musicTrack;

    // Starts all the audio clips at the same time but sets their volume at zero
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = (startMusicVolume);
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // when activated it starts playing the track
        if (gameObject.GetComponent<Draggable>().isDragging == true)
        {
            music.volume = musicVolume;
        }
    }
    
}
