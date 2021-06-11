using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class CarChasingController : MonoBehaviour
{
    public NavMeshAgent  agent;
    public static bool stopIfGameOver = true;
    [SerializeField] GameObject Player;
    [SerializeField] Rigidbody _rb;
    void Update()
    {
        DistanceFind();
        navigate();
    }

    private void DistanceFind()
    {
        float distance = (gameObject.transform.position - Player.transform.position).magnitude;
      //  Debug.Log("distance" + distance);
        if (distance<=12)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * 25 * Time.deltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);          
        }
    }

  

    public void navigate()
    {
        if (stopIfGameOver)
        {
          
            agent.SetDestination(Player.transform.position);

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    Debug.Log(agent.remainingDistance);
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        gameObject.transform.LookAt(Player.transform.position);
                       // agent.isStopped = true;
                    }
                }
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<NavMeshAgent>().enabled = false;
            stopIfGameOver = false;
        }
     
    }
    private void OnTriggerStay(Collider other)
    {
       // if (other.gameObject.CompareTag("Player"))
       // {
       //   
       // }
       
    }
}




