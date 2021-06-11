using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<CarChasingController>().enabled = false;
        int value = Random.Range(2, 5);
        collision.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(value,value,value) * 5);
    }
}
