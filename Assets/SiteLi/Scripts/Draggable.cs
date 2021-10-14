using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{


    //ps: this script can be attached to whatever you want to drag with mouse cursor
    // well , i had to admit it behave pretty bad right now and I got no idea how to improve



    private Vector3 mOffset;

    private float mZCoord;

    public bool isDragging = false;

    Rigidbody rb;
    



    private void Start()
    {
       var rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //store offset ,so the position of cursor and selected object can be relatively smooth?
        //well at least that's what I understand from the tutotial.....
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }


    Vector3 GetMouseWorldPos()
    {
        //pixel coordinates of mouse(x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z cordinate of game object on screen
        mousePoint.z = mZCoord;

        //convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);


    }

    //when pressing down the mouse , the selected object will follow the cursor
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
        
        
        isDragging = true;
    }


    private void OnMouseUp()
    {
        isDragging = false;
    }



    


}
