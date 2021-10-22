using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBarAttachPoint : MonoBehaviour
{
    
        public Transform crossbarTransform;

        void Update()
        {
            transform.position = crossbarTransform.position;
        }
    

}
