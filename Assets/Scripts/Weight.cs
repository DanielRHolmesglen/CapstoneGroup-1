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
    public Vector3 StartPosition;
    public Quaternion StartRotation;
    public int type;




  

    private void Start()
    {
        
        StartPosition = transform.position;
        StartRotation = transform.rotation;
        
        //make sure sound volume all set to 0 
        if (gameObject.GetComponent<AudioSource>())
        {
            soundEffect = gameObject.GetComponent<AudioSource>();
            soundEffect.volume = 0;
        }
    }


   




    //other script can call this function to get this weight's value
    public float GetValue()
    {
        return weightValue;
    }

    //this function will be called within game manager,sound and visual effect will be triggered
    public void PlaySound()
    {
        StartCoroutine(FadeAudioSource.StartFade(soundEffect, 1f, 1f));
        //soundEffect.volume = 1;
        if (visualEffect)
        {
            visualEffect.GetComponent<ParticleSystem>().Play();
        }
    }
    //this function will be called within game manager,sound and visual effect will be triggered
    public void StopPlaySound()
    {
        StartCoroutine(FadeAudioSource.StartFade(soundEffect, 1f, 0f));
        //soundEffect.volume = 0;
        if (visualEffect)
        {
            visualEffect.GetComponent<ParticleSystem>().Stop();
        }
    }


    //if the weight collider with floor or anything has a floorTag scirpt , the weight will transform to its' original location
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<FloorTag>())
        {
            transform.position = StartPosition;
            transform.rotation = StartRotation;
        }


     

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FloorTag>())
        {
            transform.position = StartPosition;
            transform.rotation = StartRotation;
        }
    }


}
