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
    public GameObject EaqulEffect2;
    //public GameObject DialogueText;
    public GameObject currentPickedWeight;
    public GameObject recordPlayer;
    public GameObject record;
    public GameObject recordApperarEffect;
    public GameObject narratives;



    public List<GameObject> weightsOnPlate = new List<GameObject>();
    public bool alreadyHasThatType = false;
    public bool recordShouldAppear = false;
    public bool eaqualShouldPlayer = false;
    public bool sameTypeAlert = false;

    public Transform PortalPosition;


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
        EaqulEffect2.SetActive(false);
        
        Invoke("DisableNarrative", 15f);

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

        else if (!hasThingOnBothScale)
        {

            CheckValue();
           
        }


       


        //check if the eaqual effect should be player
        if (eaqualShouldPlayer == true)
        {
            if (EaqulEffect)
            {
                EaqulEffect.SetActive(true);
                EaqulEffect.GetComponent<ParticleSystem>().Play();
                StartCoroutine(FadeAudioSource.StartFade(EaqulEffect2.GetComponent<AudioSource>(), 2f, 0.2f));

                
            }
            if (EaqulEffect2)
            {
                EaqulEffect2.SetActive(true);
                EaqulEffect2.GetComponent<ParticleSystem>().Play();
                StartCoroutine(FadeAudioSource.StartFade(EaqulEffect2.GetComponent<AudioSource>(), 2f, 0.2f));
                
            }

        }
        else if (eaqualShouldPlayer == false)
        {
            EaqulEffect.GetComponent<ParticleSystem>().Stop();
            EaqulEffect2.GetComponent<ParticleSystem>().Stop();
            StartCoroutine(FadeAudioSource.StartFade(EaqulEffect.GetComponent<AudioSource>(), 2f, 0f));
            StartCoroutine(FadeAudioSource.StartFade(EaqulEffect2.GetComponent<AudioSource>(), 2f, 0f));

            //record.GetComponentInChildren<RotateRecord>().enabled = false;
            //record.SetActive(false);
            recordShouldAppear = false;
            

        }


        //check if the record should appear
        if (recordShouldAppear == true)
        {
            record.SetActive(true);
            recordPlayer.GetComponentInChildren<RotateRecord>().enabled = true;
            //recordPlayer.GetComponent<AudioSource>().Play();
            StartCoroutine(FadeAudioSource.StartFade(recordPlayer.GetComponent<AudioSource>(), 0.6f, 0.6f));


        }
        else if(recordShouldAppear == false)
        {
            recordPlayer.GetComponentInChildren<RotateRecord>().enabled = false;
            record.SetActive(false);
            StartCoroutine(FadeAudioSource.StartFade(recordPlayer.GetComponent<AudioSource>(), 0.6f, 0f));
        }

       



       //check if there has same type weight on the scale
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
            eaqualShouldPlayer = false;

        }

        

         else if(isEaqual==true && hasThingOnBothScale==true)
        {
            
            Debug.Log("the weight is equal");
            if (weightsOnPlate.Count == 5)
            {
                StartCoroutine(PlayEqual());
            }
         

        }


    }


    IEnumerator PlayEqual() 
    {
       
        yield return new WaitForSeconds(1f);
       
        eaqualShouldPlayer = true;
          
        yield return new WaitForSeconds(2f);
        if (record) 
        {
           
            recordShouldAppear = true;
        
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
                        //currentPickedWeight.transform.position = Vector3.Lerp(currentPickedWeight.transform.position, currentPickedWeight.GetComponent<Weight>().StartPosition, smoothing * 2);
                       /* currentPickedWeight.transform.position = PortalPosition.position;
                        currentPickedWeight.transform.rotation = currentPickedWeight.GetComponent<Weight>().StartRotation;*/
                       weightsOnPlate[i].transform.position = PortalPosition.position;
                        weightsOnPlate[i].transform.rotation = weightsOnPlate[i].GetComponent<Weight>().StartRotation;

                        currentPickedWeight = null;
                        yield return new WaitForSeconds(5);
                        alreadyHasThatType = false;
                       
                    }
                }

            }

        }
        yield return null;
    }


    public void DisableNarrative() 
    {
        narratives.SetActive(false);
    
    }







}
