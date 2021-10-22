using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    //ps: this script need to be attached to objects that you want to give it a value(weight , Goal_object)

    //basically just to store the value of each weight that attached with this script
    public float value;
    public AudioSource soundEffect;
   

    
    public float GetValue()
    {

        return value;
    }


    public void PlaySound()
    {

        soundEffect.Play();
    }



}
