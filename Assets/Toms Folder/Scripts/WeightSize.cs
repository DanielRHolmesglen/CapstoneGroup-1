using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeightSize : MonoBehaviour
{
    [Header("Set what size the weight prefab is")]
    [SerializeField] bool largeWeight = false;
    [SerializeField] bool mediumWeight = false;
    [SerializeField] bool smallWeight = false;
    public float weightValue = 0;
    
    void Start()
    {
        if (largeWeight == true) weightValue = 6;
        if (mediumWeight == true) weightValue = 3f;
        if (smallWeight == true) weightValue = 2f;
        else Debug.Log("Weight value not set in inspector");
    }       
}
