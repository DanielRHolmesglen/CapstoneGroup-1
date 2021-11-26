using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestGameManager : MonoBehaviour
{
    //ps: this script need to be attached to an empty game object(a game manager)
    //things need to be manually set up in inspector
    public ScaleTilter scaleTilter;
    // a reference of the left scale plate
    public ScaleDetect left_Scale;
    // a reference of the right scale plate
    public ScaleDetect right_Scale;
    // raining particle effects
    public ParticleSystem eaqulEffect;
    public ParticleSystem eaqulEffect2;
   
    // a reference of the curret weight that are being picked up
    public GameObject currentPickedWeight;
    //a reference to the record base
    public RecordRotate recordPlayer;
    // a reference to the record
    public GameObject record;
    //a reference to the record's particle effect
    public GameObject recordApperarEffect;
    //a reference to the panel which display narratived at the start
    public GameObject narratives;


    // a list to store all the weights that are currently on the plate
    public List<GameObject> weightsOnPlate = new List<GameObject>();
    // to check if the weights on the plate same as the current picked one
    public bool alreadyHasThatType = false;
    // to check if the record should show up
    public bool recordShouldAppear = false;
    // to check if related FX should be triggered 
    public bool eaqualFXShouldPlay = false;
    
    //a reference of the portal point that the old same type weight will be transformed to
    public Transform portalPosition;


    public float smoothing = 0.4f;




    //things don't need to be manually set up in inspector as it will be assigned with code

    //the current total value of the right scale plate
    public float rightScaleWeight;
    //the current total value of the left scale plate
    public float leftScaleWeight;

    // to check if two sides value are eaqual
    public bool isEaqual = false;

    //check if there anything in both lef and right side of the scale plates
    public bool hasThingOnBothScale = false;

    
    void Start()
    {

        // make sure raining particle effect turned off
        eaqulEffect.Play(false);
        eaqulEffect2.Play(false);
        // the narrative will disappear after some time
        Invoke("DisableNarrative", 15f);

    }

   
    void Update()
    {
        //get the  total weight's value from  scale_detect script which attached on right side plate  , the script is attached at the ScalePlate(1) game object within RightPlatePivot
        //rightScaleWeight = right_Scale.GetComponent<ScaleDetect>().ReturnFinalValue();

        //get the  total weight's value from  scale_detect script which attached on left side plate  , the script is attached at the ScalePlate game object within LeftPlatePivot
        //leftScaleWeight = left_Scale.GetComponent<ScaleDetect>().ReturnFinalValue();



        //if the there are weights on both left scale plates and right scale plates , set hasThingOnBothScale to true , if not set it to false;
        if (left_Scale.hasThingOn == true && right_Scale.hasThingOn == true)
        {
            hasThingOnBothScale = true;
            
        }
        else { hasThingOnBothScale = false; }


        // to set up the value for Bool eaqualFXShouldPlay
        SettingBoolForEaqulFXShouldPlay();


        //check if EaqualFX should play or not
        CheckIfEaqualFxShouldPlay();



       //check if there has same type weight on the scale
        StartCoroutine(HasSameTypeCheck());

        CheckEaqulOrNot();
       

    } 

    public void WeightValues(float scaleWeight, string side)
    {
        if(side == "right")
        {
            rightScaleWeight = scaleWeight;
        } 
        else  leftScaleWeight = scaleWeight;

        scaleTilter.WeightAmountUpdated(leftScaleWeight,rightScaleWeight);
    }
    

   
    public void SettingBoolForEaqulFXShouldPlay()

    {
       
        // if the two sides are not eaqual , the eaqual FX should not be played
        if( isEaqual== false || hasThingOnBothScale == false)
        {
           
            Debug.Log("the weight is not eaqual");
            eaqualFXShouldPlay = false;

        }

        
        // if the two sides are eaqual ,and there are 5 weights in total, the eaqual FX should be played,
         else if(isEaqual==true && hasThingOnBothScale==true)
        {
            
            Debug.Log("the weight is equal");
            if (weightsOnPlate.Count == 5)
            {
                StartCoroutine(PlayEqual());
            }
         

        }


    }


    public void CheckIfEaqualFxShouldPlay() 
    {
        if (eaqualFXShouldPlay == true)
        {
            if (eaqulEffect)
            {
                eaqulEffect.Play(true);
                //eaqulEffect.GetComponent<ParticleSystem>().Play();
                //StartCoroutine(FadeAudioSource.StartFade(eaqulEffect2.GetComponent<AudioSource>(), 2f, 0.2f));


            }
            if (eaqulEffect2)
            {
                eaqulEffect2.Play(true);
                //eaqulEffect2.GetComponent<ParticleSystem>().Play();
                //StartCoroutine(FadeAudioSource.StartFade(eaqulEffect2.GetComponent<AudioSource>(), 2f, 0.2f));

            }

        }
        else if (eaqualFXShouldPlay == false)
        {
            eaqulEffect.Stop();
            eaqulEffect2.Stop();
            //StartCoroutine(FadeAudioSource.StartFade(eaqulEffect.GetComponent<AudioSource>(), 2f, 0f));
            //StartCoroutine(FadeAudioSource.StartFade(eaqulEffect2.GetComponent<AudioSource>(), 2f, 0f));


            recordShouldAppear = false;


        }


        //check if the record should appear
        if (recordShouldAppear == true)
        {
            record.SetActive(true);
            recordPlayer.enabled = true;
            //recordPlayer.GetComponent<AudioSource>().Play();
            StartCoroutine(FadeAudioSource.StartFade(recordPlayer.GetComponent<AudioSource>(), 0.6f, 0.6f));


        }
        else if (recordShouldAppear == false)
        {
            recordPlayer.enabled = false;
            record.SetActive(false);
            StartCoroutine(FadeAudioSource.StartFade(recordPlayer.GetComponent<AudioSource>(), 0.6f, 0f));
        }




    }


    public void CheckEaqulOrNot() 
    {
        if (leftScaleWeight == rightScaleWeight && hasThingOnBothScale == true && alreadyHasThatType == false)
        {

            isEaqual = true;
        }
        else
        {
            isEaqual = false;
        }

    }



  
    IEnumerator PlayEqual() 
    {
       
        yield return new WaitForSeconds(1f);
       
        eaqualFXShouldPlay = true;
          
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
                       weightsOnPlate[i].transform.position = portalPosition.position;
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
