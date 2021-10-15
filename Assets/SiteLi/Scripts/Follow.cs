using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public bool shouldFollow = false;
    public float distance = 6f, smoothing =0.4f, turnSmoothing = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldFollow) return;

        var desiredPos = target.transform.position + -target.transform.forward * distance;
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothing);

        var desiredDir = Quaternion.LookRotation(target.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredDir, turnSmoothing * 0.1f);
    }

}