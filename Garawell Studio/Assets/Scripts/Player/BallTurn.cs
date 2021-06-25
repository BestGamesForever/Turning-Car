using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallTurn : MonoBehaviour
{
    [SerializeField] Transform _PlayersTarget;
    float xtime;
    private void Update()
    {        
        if (DropBoxTurn.isHitDropBox)
        {
            xtime += Time.deltaTime;
           
            if (xtime<=3)
            {
                transform.RotateAround(_PlayersTarget.position, Vector3.up, 720 * Time.deltaTime);
                gameObject.GetComponent<SpringJoint>().spring = 0;
            }
            if (xtime>=3)
            {
                gameObject.GetComponent<SpringJoint>().spring = 3000;
                xtime = 0;
                DropBoxTurn.isHitDropBox = false;
            }
        }
      
    }
}
