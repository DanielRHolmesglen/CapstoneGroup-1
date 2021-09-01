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

    private Quaternion currentTiltAngle;

    private Quaternion maxLeft = Quaternion.Euler(0,0,15);
    private Quaternion closeLeft = Quaternion.Euler(0, 0, 5);
    private Quaternion balanced = Quaternion.Euler(0, 0, 0);
    private Quaternion closeRight = Quaternion.Euler(0, 0, -5);
    private Quaternion maxRight = Quaternion.Euler(0, 0, -15);

    void Start()
    {
        crossBar = GetComponent<GameObject>();
        currentTiltAngle = Quaternion.Euler(0, 0, 10);
        transform.rotation = Quaternion.Lerp(currentTiltAngle,currentTiltAngle, Time.time * tiltSpeed);
    }

    
    void Update() // this should only be checked when a wheight is placed. **need to fix**
    {
        LargeWeightAdded();
        MediumWeightAdded();
        SmallWeightAdded();

        if (leftPlateValue > rightPlateValue)
        {
            if (leftPlateValue  <= (rightPlateValue + 3)) // need to check if close not greater or equal to
            {
                transform.rotation = Quaternion.Lerp(currentTiltAngle, closeLeft,Time.deltaTime * tiltSpeed);
                return;
            }
            transform.rotation = Quaternion.Lerp(currentTiltAngle, maxLeft, Time.deltaTime * tiltSpeed);
        } 
        else if (rightPlateValue > leftPlateValue)
        {
            if (rightPlateValue <= (leftPlateValue + 3))
            {
                transform.rotation = Quaternion.Lerp(currentTiltAngle, closeRight, Time.deltaTime * tiltSpeed);
                return;
            }
            transform.rotation = Quaternion.Lerp(currentTiltAngle, maxRight, Time.deltaTime * tiltSpeed); 
        } 
        else if (rightPlate == leftPlate)
        {
            transform.rotation = Quaternion.Lerp(currentTiltAngle, balanced, Time.deltaTime * tiltSpeed);
            //Do balanced effects.
            return;
        }
        
    }
    #region WeightInputs
    // disregard below it's only to test the code, 
    // this will all be set by putting the weights on the plates eventually
    public void LargeWeightAdded()
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
