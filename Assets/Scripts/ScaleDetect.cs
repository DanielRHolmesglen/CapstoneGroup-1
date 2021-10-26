using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleDetect : MonoBehaviour
{
    //PS: this script need to be attached to each side of the scale handle

   
    public float CurrentTotalWeight = 0;

    public List<GameObject> weights = new List<GameObject>();
    public List<Transform> weightTransforms = new List<Transform>();
    public List<int> randomNumbers = new List<int>();
    

    public bool  hasThingOn = false;

    
    public int snapInt;

    public float smoothing = 0.4f;

    



    // Start is called before the first frame update
    void Start()
    {
        for (int n = 0; n < 9; n++)    //  Populate list
        {
            randomNumbers.Add(n);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentTotalWeight == 0)
        {
            hasThingOn = false;
        }
        else
        {
            hasThingOn = true;
        }
    }


    //if there's a weight put on the scale
    private void OnCollisionEnter(Collision other)
    {

    

       
            AddWeight(other.gameObject); //adding to list
            int i = Random.Range(0, randomNumbers.Count - 1);
        
            other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position,weightTransforms[i].transform.position,  smoothing);
            other.gameObject.transform.rotation = other.gameObject.GetComponent<Weight>().StartRotation;
            //weightTransforms[i].GetComponent<HasWeightOnItTag>().currentWeight = other.gameObject;
        

           
           


            //play effect 
            if (other.gameObject.GetComponent<ParticleSystem>())
            {
                other.gameObject.GetComponent<ParticleSystem>().Play();
            }

            if (other.gameObject.GetComponent<AudioSource>())
            {
                other.gameObject.GetComponent<Weight>().PlaySound();
            }

            UpdateCurrentTotalWeight();

         
            
     

    }


    //if you remove a weight from current scale
    private void OnCollisionExit(Collision collision)
    {
        
            RemoveWeight(collision.gameObject); //remove weight from list
        collision.gameObject.GetComponent<Weight>().StopPlaySound();

        UpdateCurrentTotalWeight();
        
    }

    //list management function
    void AddWeight(GameObject thisWeight)
    {
        
        weights.Add(thisWeight);
        if (snapInt < 3)
        {
            snapInt += 1;
        }
        else
        {
            snapInt = 1;
        }

    }


    void RemoveWeight(GameObject thisWeight)
    {

        weights.Remove(thisWeight);
        
       
    }


    void UpdateCurrentTotalWeight()
    {
        CurrentTotalWeight = 0;
        for (int i = 0; i < weights.Count; i++)
        {

            CurrentTotalWeight += weights[i].gameObject.GetComponent<Weight>().weightValue;        }

    }

    

    // other script can call this function to get the bool value
    public bool ReturnBool()
    {
        return hasThingOn;
    }


    // other script can call this function to get the weight's value when the weight is put on the scale

    public float ReturnFinalValue()
    {
        return CurrentTotalWeight;
    }


    



}
