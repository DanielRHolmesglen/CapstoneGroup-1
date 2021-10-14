using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRecord : MonoBehaviour
{

    public int speed; // can change the speed value inside unity because its public

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0); //this will make the record rotate on the y axis
    }
}
