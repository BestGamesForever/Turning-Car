using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropBoxTurn : MonoBehaviour
{ 
    public static bool isHitDropBox;
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Hey");
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hey");
            isHitDropBox = true;
            this.gameObject.SetActive(false);
        }
    }

}
