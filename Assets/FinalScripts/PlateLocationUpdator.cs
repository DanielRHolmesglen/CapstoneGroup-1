using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateLocationUpdator : MonoBehaviour
{
    // Updates the location of the plates to match the tilt of the cross bar
    public Transform crossbarTransform;
        
    void Update()
    {
        transform.position = crossbarTransform.position;
    }
}
