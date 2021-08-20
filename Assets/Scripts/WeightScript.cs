using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class WeightScript : MonoBehaviour
{
    AudioSource weightAudio;
    public KeyCode Button;
    bool isPlaying = false;
    // Start is called before the first frame update
    
    void Start()
    {
        weightAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            weightAudio.volume = 1;
        }
        else
        {
            weightAudio.volume = 0;
        }
        if (Input.GetKeyDown(Button))
        {
            isPlaying = !isPlaying;
        }
    }
}
