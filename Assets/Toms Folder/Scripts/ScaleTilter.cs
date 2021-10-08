using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTilter : MonoBehaviour
{
    public Transform leftPlate;
    public Transform rightPlate;

    bool scaleIsBalanced = false;
    
    public float leftPlateValue;
    public float rightPlateValue;
    // below weights would take info from weight prefabs or just left here.
    private float weightLarge = 6f;
    private float weightMedium = 3f;
    private float weightSmall = 2f;
    [SerializeField] private float tiltSpeed = 1f;

    private Quaternion startTiltAngle = Quaternion.Euler(0, 0, 10);

    // Scale balance points
    private Quaternion maxLeft = Quaternion.Euler(0,0,15);
    private Quaternion closeLeft = Quaternion.Euler(0, 0, 5);
    private Quaternion balanced = Quaternion.Euler(0, 0, 0);
    private Quaternion closeRight = Quaternion.Euler(0, 0, -5);
    private Quaternion maxRight = Quaternion.Euler(0, 0, -15);

    void Start()
    {
        //not working
        transform.rotation = Quaternion.Lerp(balanced,startTiltAngle, Time.deltaTime * tiltSpeed);
    }

    
    void Update() 
    {
        WeightAmountUpdated();
        /* for testing only
        LargeWeightAdded();
        MediumWeightAdded();
        SmallWeightAdded();
        */
    }
    public void CalculateWeights()
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
            scaleIsBalanced = true; // pass out to game manager
            return;
        }
    }

    public void WeightAmountUpdated()
    {
        CalculateWeights();
    }
    
    #region WeightInputs 
    /*
    // this will all be set by putting the weights on the plates eventually
    public void LargeWeightAdded() 
    {
        if (Input.GetKeyDown(KeyCode.Q)) leftPlateValue += weightLarge;
        else if (Input.GetKeyDown(KeyCode.E)) rightPlateValue += weightLarge;
        CalculateWeights();
    }
    public void MediumWeightAdded()
    {
        if (Input.GetKeyDown(KeyCode.A))  leftPlateValue += weightMedium; 
        else if (Input.GetKeyDown(KeyCode.D)) rightPlateValue += weightMedium;
        CalculateWeights();
    }
    public void SmallWeightAdded()
    {
        if (Input.GetKeyDown(KeyCode.Z)) leftPlateValue += weightSmall;
        else if (Input.GetKeyDown(KeyCode.C)) rightPlateValue += weightSmall;
        CalculateWeights();
    }*/
    #endregion
    
}
