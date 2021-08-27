using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //ps : this script need be attached to an empty object which contain the main camera as a child object(which means don't attach this script to camera directly)

    //wasd/arrow key to move , q/e key to rotate  , mouse scroll to zoom in and out

    public float moveSpeed;
    public float zoomSpeed;
    
    public float minZoomDis;
    public float maxZoomDis;

    public float smoothing;
    public float rotationAmount;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateCam();
        Zoom();
        
    }



    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;

        Vector3 desiredPos = transform.position + dir * moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothing);


    }


    void RotateCam()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            Quaternion desiredRotation = transform.rotation * Quaternion.Euler(Vector3.up * rotationAmount);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothing);
        }

        if (Input.GetKey(KeyCode.E))
        {

            Quaternion desiredRotation = transform.rotation * Quaternion.Euler(Vector3.up * -rotationAmount);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothing);
        }

       

    }


    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float dist = Vector3.Distance(transform.position, cam.transform.position );


        //set limit for mouse scroll
        if(dist < minZoomDis && scrollInput > 0.0f)
        {
            return;
        }
        else if(dist>maxZoomDis && scrollInput<0.0f)
        {
            return;
        }

        Vector3 desiredZoom = cam.transform.position + cam.transform.forward * scrollInput * zoomSpeed;
        cam.transform.position = Vector3.Lerp(cam.transform.position, desiredZoom, smoothing);
    }

}
