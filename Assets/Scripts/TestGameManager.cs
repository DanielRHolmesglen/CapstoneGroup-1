using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    //ps: this script need to be attached to an empty game object(a game manager)



    //things need to manually set in inspector

   
    public GameObject left_Scale;
    public GameObject right_Scale;
    public GameObject EaqulEffect;


     GameObject correctImage;
     GameObject wrongImage;

    

    //things can ignored in inspector

  
    public float rightScaleWeight;
    public float leftScaleWeight;

  
    public bool isEaqual = false;

    //check if there anything in weight_scale
    public bool hasThingOnBothScale = false;

    
    void Start()
    {
        EaqulEffect.SetActive(false);

    }

   
    void Update()
    {
        //get the weight's value from weight_scale handle(which has the picked weight)
        rightScaleWeight = right_Scale.GetComponent<ScaleDetect>().ReturnFinalValue();

        //get the weight's value from goal_scale handle(which has the goal object)  
        leftScaleWeight = left_Scale.GetComponent<ScaleDetect>().ReturnFinalValue();

        //to check if there's anything put on the weight_scale handle(which has the picked weight)


        if (left_Scale.GetComponent<ScaleDetect>().hasThingOn == true && right_Scale.GetComponent<ScaleDetect>().hasThingOn == true)
        {
            hasThingOnBothScale = right_Scale.GetComponent<ScaleDetect>().ReturnBool();
            
        }
        else { hasThingOnBothScale = false; }



        //if there's something on the weight_scale , check if two side has the same weight value
        if (hasThingOnBothScale == true)
        {
            CheckValue();
        }

        //if nothing on the weight_scale , make sure those image not showing up
        else if (!hasThingOnBothScale)
        {

            /*correctImage.SetActive(false);
            wrongImage.SetActive(false);*/
        }


        if(leftScaleWeight == rightScaleWeight && hasThingOnBothScale == true)
        {

            isEaqual = true;
        }
        else
        {
            isEaqual = false;
        }


    } 


    
    public void CheckValue()

    {
        

        if( isEaqual== false || hasThingOnBothScale == false)
        {

            Debug.Log("the weight is not eaqual");

            
            EaqulEffect.GetComponent<ParticleSystem>().Stop();

            /*if (correctImage)
            {
                correctImage.SetActive(true);
                wrongImage.SetActive(false);
            }*/

        }

        

         else if(isEaqual==true && hasThingOnBothScale==true)
        {
            Debug.Log("the weight is equal");
            StartCoroutine(PlayEqual());

           /* if (wrongImage)
            {
                wrongImage.SetActive(true);
                correctImage.SetActive(false);
            }*/

        }


    }


    IEnumerator PlayEqual() 
    {
        yield return new WaitForSeconds(1f);
        if (EaqulEffect)
        {
            EaqulEffect.SetActive(true);
            EaqulEffect.GetComponent<ParticleSystem>().Play();
           
           
        }
        yield return null;
    }

   









}
