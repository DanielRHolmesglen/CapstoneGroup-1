using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WeightMusicHandler : MusicPlayer
{
    private AudioSource musicPlayer;
    private float startMusicVolume = 0;

    public AudioMixer mixer;
    public float musicVolume = 10; // player to set their desired volume
    public AudioClip musicTrack;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        // starts the timer for handling the music being in sync
        
        musicPlayer.volume = (startMusicVolume);
        musicPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // when activated it starts playing the track
        if (Input.GetButtonDown("Jump"))
        {
            musicPlayer.volume = musicVolume;
        }
    
    }
}
