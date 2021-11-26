using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScaleDetect : MonoBehaviour
{
    //PS: this script need to be attached to each side of the scale handle

   // current total weight value
    public float currentTotalWeight = 0;
    public GameObject currentPickedWeight;
    public TestGameManager testGameManagerScript;
    public ScaleTilter scaleTilter;

    //a list of current weights
    public List<GameObject> weights = new List<GameObject>();

    //a list of the snap point transform
    public List<Transform> weightTransforms = new List<Transform>();

    public string side;

    //to check if there has weight on this plate
    public bool hasThingOn = false;
   
    //snap point muber
    public int snapInt = 0;
    public float smoothing = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTotalWeight == 0)
        {
            hasThingOn = false;
        }
        else
        {
            hasThingOn = true;
        }

        //StartCoroutine(HasSameTypeCheck());
       
    }


    //if there's a weight put on the scale
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<Draggable>().isDragging == false)
        {
            testGameManagerScript.currentPickedWeight = other.gameObject;
            AddWeight(other.gameObject);
            SetWeight(other.gameObject);
        }
           

    }


    //if you remove a weight from current scale
    private void OnCollisionExit(Collision collision)
    {
        
        RemoveWeight(collision.gameObject); //remove weight from list
        collision.gameObject.GetComponent<Weight>().StopPlaySound();

    }

    //list management function
    void AddWeight(GameObject thisWeight)
    {
        
        weights.Add(thisWeight);
        testGameManagerScript.weightsOnPlate.Add(thisWeight);
        snapInt += 1;
        if (snapInt == 8)
        {
            snapInt = 0;
        }


        UpdateCurrentTotalWeight();
    }


    void RemoveWeight(GameObject thisWeight)
    {
       
        weights.Remove(thisWeight);
        testGameManagerScript.weightsOnPlate.Remove(thisWeight);
        UpdateCurrentTotalWeight();

    }

    void UpdateCurrentTotalWeight()
    {
        currentTotalWeight = 0;
        for (int i = 0; i < weights.Count; i++)
        {

            currentTotalWeight += weights[i].gameObject.GetComponent<Weight>().weightValue;        
        }
        testGameManagerScript.WeightValues(currentTotalWeight, side);
        
    }

    void SetWeight(GameObject thisWeight) 
    {
        thisWeight.transform.position = Vector3.Lerp(thisWeight.transform.position, weightTransforms[snapInt].transform.position, smoothing);
        thisWeight.transform.rotation = thisWeight.GetComponent<Weight>().StartRotation;
      
        //play effect 
        if (thisWeight.GetComponent<ParticleSystem>())
        {
            thisWeight.GetComponent<ParticleSystem>().Play();
        }

        if (thisWeight.GetComponent<AudioSource>())
        {
            thisWeight.GetComponent<Weight>().PlaySound();
        }

    }


    // other script can call this function to get the bool value
    public bool ReturnBool()
    {
        return hasThingOn;
    }

    // other script can call this function to get the weight's value when the weight is put on the scale

    public float ReturnFinalValue()
    {
        return currentTotalWeight;
    }

    private void OnDrawGizmos()
    {
        for(int i = 0;  i<weightTransforms.Count;i++) 
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(weightTransforms[i].transform.position, 0.01f);
        
        }
    }

}
