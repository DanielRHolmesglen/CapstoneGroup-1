using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTilter : MonoBehaviour
{
    public GameObject crossBar;
    public Transform leftPlate; 
    public Transform rightPlate;
    
    public float leftPlateValue;
    public float rightPlateValue;
    // below weights would take info from weight prefabs
    private float weightLarge = 6f;
    private float weightMedium = 3f;
    private float weightSmall = 2f;
    [SerializeField] private float tiltSpeed = 1f;

    private Quaternion startTiltAngle;

    // Scale balance points
    private Quaternion maxLeft = Quaternion.Euler(0,0,15);
    private Quaternion closeLeft = Quaternion.Euler(0, 0, 5);
    private Quaternion balanced = Quaternion.Euler(0, 0, 0);
    private Quaternion closeRight = Quaternion.Euler(0, 0, -5);
    private Quaternion maxRight = Quaternion.Euler(0, 0, -15);

    void Start()
    {
        crossBar = GetComponent<GameObject>();
        startTiltAngle = Quaternion.Euler(0, 0, 10); 
        transform.rotation = Quaternion.Lerp(transform.rotation,startTiltAngle, Time.deltaTime * tiltSpeed);
    }

    
    void Update() // this should only be checked when a weight is placed. **need to fix**
    {
        //LargeWeightAdded();
        //MediumWeightAdded();
        //SmallWeightAdded();
        leftPlateValue = leftPlate.GetComponent<ScaleDetect>().ReturnFinalValue();
        rightPlateValue = rightPlate.GetComponent<ScaleDetect>().ReturnFinalValue();


        #region Weight Added logic // commented out
        
        if (leftPlateValue > rightPlateValue)
        {
            if (leftPlateValue  <= (rightPlateValue + 3)) 
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, closeLeft,Time.deltaTime * tiltSpeed);
                return;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, maxLeft, Time.deltaTime * tiltSpeed);
        } 
        else if (rightPlateValue > leftPlateValue)
        {
            if (rightPlateValue <= (leftPlateValue + 3))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, closeRight, Time.deltaTime * tiltSpeed);
                return;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, maxRight, Time.deltaTime * tiltSpeed);
        } 
        else if (leftPlateValue == rightPlateValue)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, balanced, Time.deltaTime * tiltSpeed);
            //Do balanced effects.
            return;
        }
        
        #endregion 

    private void WeightAdded() //  IEnumerator?
    {
        if (leftPlateValue > rightPlateValue)
        {
            if (leftPlateValue <= (rightPlateValue + 3))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, closeLeft, Time.deltaTime * tiltSpeed);
                return;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, maxLeft, Time.deltaTime * tiltSpeed);
        } else if (rightPlateValue > leftPlateValue)
        {
            if (rightPlateValue <= (leftPlateValue + 3))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, closeRight, Time.deltaTime * tiltSpeed);
                return;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, maxRight, Time.deltaTime * tiltSpeed);
        } else if (leftPlateValue == rightPlateValue)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, balanced, Time.deltaTime * tiltSpeed);
            //Do balanced effects.
            return;
        }
    }*/

    #region WeightInputs
    // disregard below it's only to test the code, 
    // this will all be set by putting the weights on the plates eventually
    public void LargeWeightAdded() // can add code in here to make plates move.
    {
        if (Input.GetKeyDown(KeyCode.Q)) leftPlateValue += weightLarge;
        else if (Input.GetKeyDown(KeyCode.E)) rightPlateValue += weightLarge;
    }
    public void MediumWeightAdded()
    {
        if (Input.GetKeyDown(KeyCode.A))  leftPlateValue += weightMedium; 
        else if (Input.GetKeyDown(KeyCode.D)) rightPlateValue += weightMedium;
    }
    public void SmallWeightAdded()
    {
        if (Input.GetKeyDown(KeyCode.Z)) leftPlateValue += weightSmall;
        else if (Input.GetKeyDown(KeyCode.C)) rightPlateValue += weightSmall;        
    }
    #endregion

}
