using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestGameManager : MonoBehaviour
{
    //ps: this script need to be attached to an empty game object(a game manager)



    //things need to manually set in inspector

   
    public GameObject left_Scale;
    public GameObject right_Scale;
    public GameObject EaqulEffect;
    public GameObject DialogueText;
    public GameObject currentPickedWeight;
    public List<GameObject> weightsOnPlate = new List<GameObject>();
    public bool alreadyHasThatType = false;
    GameObject correctImage;
     GameObject wrongImage;


    public float smoothing = 0.4f;


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


       

        //left_Scale.GetComponent<ScaleDetect>().alreadyHasThatType == true || right_Scale.GetComponent<ScaleDetect>().alreadyHasThatType == true
        if (alreadyHasThatType == true ) 
        {
            if (DialogueText)
            {
                DialogueText.SetActive(true);
            }
        }

        else 
        {
            if (DialogueText)
            {
                DialogueText.SetActive(false);
            }
        }


        //weightsOnPlate = left_Scale.GetComponent<ScaleDetect>().weights.Union(right_Scale.GetComponent<ScaleDetect>().weights).ToList();
       

        StartCoroutine(HasSameTypeCheck());

        if (leftScaleWeight == rightScaleWeight && hasThingOnBothScale == true && alreadyHasThatType == false)
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


    IEnumerator HasSameTypeCheck()
    {
        //weights.Count

        if (weightsOnPlate.Count > 1)
        {
            for (int i = 0; i < weightsOnPlate.Count - 1; i++)
            {
                if (currentPickedWeight)
                {
                    if (currentPickedWeight.GetComponent<Weight>().type == weightsOnPlate[i].GetComponent<Weight>().type)
                    {
                        
                        alreadyHasThatType = true;
                        currentPickedWeight.transform.position = Vector3.Lerp(currentPickedWeight.transform.position, currentPickedWeight.GetComponent<Weight>().StartPosition, smoothing * 2);

                        currentPickedWeight.transform.rotation = currentPickedWeight.GetComponent<Weight>().StartRotation;
                        currentPickedWeight = null;
                        yield return new WaitForSeconds(5);
                        alreadyHasThatType = false;
                    }
                }

            }

        }
        yield return null;
    }








}
