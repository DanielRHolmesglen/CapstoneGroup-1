using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasWeightOnItTag : MonoBehaviour
{
    public GameObject currentWeight;

    private void OnTriggerExit(Collider other)
    {
        currentWeight = null;
    }

}
