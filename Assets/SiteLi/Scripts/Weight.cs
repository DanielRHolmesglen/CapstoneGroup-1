using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    //ps: this script need to be attached to objects that you want to give it a value(weight , Goal_object)

    //basically just to store the value of each weight that attached with this script
    public float weightValue;
    public AudioSource soundEffect;
    public GameObject visualEffect;

    private void Start()
    {
        if (gameObject.GetComponent<AudioSource>())
        {
            soundEffect = gameObject.GetComponent<AudioSource>();
            soundEffect.volume = 0;
        }
    }

    public float GetValue()
    {

        return weightValue;
    }


    public void PlaySound()
    {
        soundEffect.volume = 1;
        if (visualEffect)
        {
            visualEffect.GetComponent<ParticleSystem>().Play();
        }
    }
    public void StopPlaySound()
    {
        soundEffect.volume = 0;
        if (visualEffect)
        {
            visualEffect.GetComponent<ParticleSystem>().Stop();
        }
    }


}
