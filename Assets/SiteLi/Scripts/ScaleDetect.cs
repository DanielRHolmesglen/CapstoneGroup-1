using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDetect : MonoBehaviour
{
    //PS: this script need to be attached to each side of the scale handle

   
    public float CurrentTotalWeight = 0;

    public List<GameObject> weights = new List<GameObject>();

    

    public bool  hasThingOn = false;

    public Transform SnapPoint;
    public Transform SnapPoint1;
    public Transform SnapPoint2;
    public int snapInt;

    public float smoothing = 0.4f;

    



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

    

       // if (other.gameObject.GetComponent<Draggable>().isDragging == false)
        //{
            AddWeight(other.gameObject); //adding to list

            //move the weight to snpa point
            if (SnapPoint)
            {
                if (snapInt == 1)
                {
                   other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, SnapPoint.position, smoothing);
                    
                }

                if (snapInt ==2 )
                {
                   other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, SnapPoint1.position, smoothing);
                    
                }

                if (snapInt ==3)
                {
                    other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, SnapPoint2.position, smoothing);
                    
                }

            }
           


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

        //}  
            
     

    }


    //if you remove a weight from current scale
    private void OnCollisionExit(Collision collision)
    {
        
            RemoveWeight(collision.gameObject); //remove weight from list

        if (collision.gameObject.GetComponent<AudioSource>())
        {
            collision.gameObject.GetComponent<Weight>().StopPlaySound();
        }


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
            
            CurrentTotalWeight += weights[i].gameObject.GetComponent<Weight>().value;
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
        return CurrentTotalWeight;
    }



}
