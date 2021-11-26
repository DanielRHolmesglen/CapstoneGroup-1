using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooAnimation : MonoBehaviour
{
    public TestGameManager gameManager;
    public float lerpTime = 0.02f;
    Vector3 startScale;
    Quaternion startRotation;

    Vector3 grow1 = new Vector3(0.6f, 0.2f, 0.6f);
    Vector3 grow2 = new Vector3(0.7f, 0.4f, 0.7f);
    Vector3 grow3 = new Vector3(0.8f, 0.7f, 0.8f);
    Vector3 grow4 = new Vector3(0.9f, 0.9f, 0.9f);
    Vector3 grow5 = new Vector3(1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.weightsOnPlate.Count == 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startScale, lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, startRotation, lerpTime);
        }
        else if (gameManager.weightsOnPlate.Count == 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, grow1, lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 161f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.weightsOnPlate.Count == 2)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, grow2, lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 116f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.weightsOnPlate.Count == 3)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, grow3, lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 63f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.weightsOnPlate.Count == 4)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, grow4, lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 18f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.weightsOnPlate.Count == 5)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, grow5, lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, lerpTime);
        }
    }
}