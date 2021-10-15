using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateManager : MonoBehaviour
{
    ScaleTilter scaleTilterScript;
    WeightSize weightManagerScript;
    // Manages the location of the weights on the plates and passes out weight size.
    public GameObject[] weightLocations;
    private float weightAmount;
    [SerializeField] private bool isLeftPlate = false; // set in inspector

    private void Start()
    {
        scaleTilterScript = GetComponent<ScaleTilter>();
        weightManagerScript = GetComponent<WeightSize>();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weightLocations.Length; i++)
        {
            // put weight in random spot on plate
            // check if spot is full or empty
        }
        //add any weights to weightAmount or take any off
    }

}
