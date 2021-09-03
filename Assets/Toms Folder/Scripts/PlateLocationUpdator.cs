using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateLocationUpdator : MonoBehaviour
{
    public Transform crossbarTransform;
        
    void Update()
    {
        transform.position = crossbarTransform.position;
    }
}
