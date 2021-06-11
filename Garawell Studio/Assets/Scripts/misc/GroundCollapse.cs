using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollapse : MonoBehaviour
{
    [SerializeField] GameObject[] piecesContain;
    [SerializeField] Material material;
    float startTime;

    void Start()
    {
        StartCoroutine(collapseround());
    }
    private void FixedUpdate()
    {
        startTime += Time.deltaTime;
       
    }
    IEnumerator collapseround()
    {
        while (true)
        {       
            //1
            if (startTime>=14)
            {
                for (int i = 0; i < 30; i++)
                {
                    piecesContain[i].GetComponent<Renderer>().material.color = new Color32(255,0,0,50);
                    yield return new WaitForSeconds(.1f);
                    if (i==29)
                    {
                        for (int j = 0; j < 30; j++)
                        {
                            piecesContain[j].GetComponent<Rigidbody>().useGravity = true;                           
                        }
                    }                   
                }
                yield return new WaitForSeconds(2);
                for (int i = 0; i < 30; i++)
                {                   
                    piecesContain[i].SetActive(false);
                }
            }
            //2
            if (startTime>=24)
            {
                for (int i = 30; i < 55; i++)
                {
                    piecesContain[i].GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 50);
                    yield return new WaitForSeconds(.1f);
                    if (i == 54)
                    {
                        for (int j = 30; j < 55; j++)
                        {
                            piecesContain[j].GetComponent<Rigidbody>().useGravity = true;
                        }
                    }
                }
                yield return new WaitForSeconds(2);
                for (int i = 30; i < 55; i++)
                {
                    piecesContain[i].SetActive(false);
                }
            }
            //3
            if (startTime >= 44)
            {
                for (int i = 55; i < 75; i++)
                {
                    piecesContain[i].GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 50);
                    yield return new WaitForSeconds(.1f);
                    if (i == 74)
                    {
                        for (int j = 55; j < 75; j++)
                        {
                            piecesContain[j].GetComponent<Rigidbody>().useGravity = true;
                        }
                    }
                }
                yield return new WaitForSeconds(2);
                for (int i = 55; i < 75; i++)
                {
                    piecesContain[i].SetActive(false);
                }
            }
            //4
            if (startTime >= 54)
            {
                for (int i = 75; i < 90; i++)
                {
                    piecesContain[i].GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 50);
                    yield return new WaitForSeconds(.1f);
                    if (i == 89)
                    {
                        for (int j = 75; j < 90; j++)
                        {
                            piecesContain[j].GetComponent<Rigidbody>().useGravity = true;
                        }
                    }
                }
                yield return new WaitForSeconds(2);
                for (int i = 75; i < 90; i++)
                {
                    piecesContain[i].SetActive(false);
                }
            }
            if (startTime >= 64)
            {
                for (int i = 90; i < 100; i++)
                {
                    piecesContain[i].GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 50);
                    yield return new WaitForSeconds(.1f);
                    if (i == 99)
                    {
                        for (int j = 90; j < 100; j++)
                        {
                            piecesContain[j].GetComponent<Rigidbody>().useGravity = true;
                        }
                    }
                }
                yield return new WaitForSeconds(2);
                for (int i = 90; i < 100; i++)
                {
                    piecesContain[i].SetActive(false);
                }
            }
            yield return null;
        }        
    }
}
