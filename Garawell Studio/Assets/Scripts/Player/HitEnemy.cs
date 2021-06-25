using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitEnemy : MonoBehaviour
{
    [SerializeField] Transform Playeritself;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Faster")
        {
            
            StartCoroutine(Hitenemy());
        }
       
    }
    private IEnumerator Hitenemy()
    {      
        var distance = new Vector3(0,5,0) + Playeritself.position;

      
        {
            Playeritself.position = Vector3.Lerp(Playeritself.position, distance, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }

        Playeritself.position = new Vector3(Playeritself.position.x, 0, Playeritself.position.z);
     
    }


}
