using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordRotate : MonoBehaviour
{
    public float rotSpeed = 60; // degrees per second

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);
    }
}
