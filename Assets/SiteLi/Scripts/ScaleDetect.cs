using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDetect : MonoBehaviour
{
    //PS: this script need to be attached to each side of the scale handle

   
    public float CurrentTotalWeight = 0;

    public List<GameObject> weights = new List<GameObject>();

    public bool  hasThingOn = false;

    


    



    // Start is called before the first frame update
    void Start()
    {
        
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

    

        if (other.gameObject.GetComponent<Draggable>().isDragging == false)
        {
            AddWeight(other.gameObject); //adding to list

           
            

           


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
            
     

    }


    //if you remove a weight from current scale
    private void OnCollisionExit(Collision collision)
    {
        
            RemoveWeight(collision.gameObject); //remove weight from list


            UpdateCurrentTotalWeight();
        
    }

    //list management function
    void AddWeight(GameObject thisWeight)
    {
        
        weights.Add(thisWeight);
       

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
