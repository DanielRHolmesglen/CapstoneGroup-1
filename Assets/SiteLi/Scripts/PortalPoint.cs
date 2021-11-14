﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPoint : MonoBehaviour
{

    public Transform PortalLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  

  /*  private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Weight>())
        {
            other.transform.position = PortalLocation.position;

        }
    }
*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Weight>())
        {
            collision.transform.position = PortalLocation.position;

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.GetComponent<Weight>())
        {
            collision.transform.position = PortalLocation.position;

        }
    }



}
