using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Rigidbody Followtransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float _followspeed;
    

    private void Update()
    {
        if (Followtransform!=null)
        {
            Vector3 desiredPos = Followtransform.position + offset;
            Vector3 SmoothPos= Vector3.Lerp(transform.position, desiredPos, _followspeed);
            transform.position = SmoothPos;
           // transform.LookAt(Followtransform);
        }
    }
}
