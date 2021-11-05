using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScaleDetect : MonoBehaviour
{
    //PS: this script need to be attached to each side of the scale handle

   
    public float CurrentTotalWeight = 0;
    public GameObject CurrentPickedWeight;
    public TestGameManager TestGameManagerScript;

    public List<GameObject> weights = new List<GameObject>();
    public List<Transform> weightTransforms = new List<Transform>();
    public List<GameObject> weightsOnThePlate = new List<GameObject>();
   

   
    



    
    public bool hasThingOn = false;
    public bool alreadyHasThatType = false;
   

    public int snapInt = 0;
    public float smoothing = 0.4f;





    // Start is called before the first frame update
    void Start()
    {
        TestGameManagerScript = TestGameManagerScript.GetComponent<TestGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //weightsOnThePlate = TestGameManagerScript.weightsOnPlate;
       // CurrentPickedWeight = TestGameManagerScript.currentPickedWeight;

        if (CurrentTotalWeight == 0)
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

            TestGameManagerScript.currentPickedWeight = other.gameObject;
            AddWeight(other.gameObject); 
            SetWeight(other.gameObject);
           
        


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
        UpdateCurrentTotalWeight();

    }


    void UpdateCurrentTotalWeight()
    {
        CurrentTotalWeight = 0;
        for (int i = 0; i < weights.Count; i++)
        {

            CurrentTotalWeight += weights[i].gameObject.GetComponent<Weight>().weightValue;        }

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


    /*IEnumerator HasSameTypeCheck() 
    {
        //weights.Count

        if (weightsOnThePlate.Count > 1)
        {
            for (int i = 0; i < weightsOnThePlate.Count - 1; i++)
            {
                if (CurrentPickedWeight)
                {
                    if (CurrentPickedWeight.GetComponent<Weight>().type == weightsOnThePlate[i].GetComponent<Weight>().type)
                    {

                        alreadyHasThatType=true;
                        CurrentPickedWeight.transform.position = Vector3.Lerp(CurrentPickedWeight.transform.position, CurrentPickedWeight.GetComponent<Weight>().StartPosition, smoothing * 2);

                        CurrentPickedWeight.transform.rotation = CurrentPickedWeight.GetComponent<Weight>().StartRotation;
                        CurrentPickedWeight = null;
                        yield return new WaitForSeconds(5);
                        alreadyHasThatType = false;
                    }
                }

            }

        }
        yield return null;
    }*/


    

   

    

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


    private void OnDrawGizmos()
    {
        for(int i = 0;  i<weightTransforms.Count;i++) 
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(weightTransforms[i].transform.position, 0.01f);
        
        }
    }



}
