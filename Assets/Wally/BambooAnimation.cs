using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooAnimation : MonoBehaviour
{
    public GameObject gameManager;
    public float lerpTime = 0.02f;
    Vector3 startScale;
    Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<TestGameManager>().weightsOnPlate.Count == 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startScale, lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, startRotation, lerpTime);
        }
        else if (gameManager.GetComponent<TestGameManager>().weightsOnPlate.Count == 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.6f, 0.2f, 0.6f), lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 161f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.GetComponent<TestGameManager>().weightsOnPlate.Count == 2)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.7f, 0.4f, 0.7f), lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 116f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.GetComponent<TestGameManager>().weightsOnPlate.Count == 3)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.8f, 0.7f, 0.8f), lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 63f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.GetComponent<TestGameManager>().weightsOnPlate.Count == 4)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.9f, 0.9f, 0.9f), lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(new Vector3(0, 18f, 0), Vector3.up), lerpTime);
        }
        else if (gameManager.GetComponent<TestGameManager>().weightsOnPlate.Count == 5)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), lerpTime);
            //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, lerpTime);
        }
    }
}