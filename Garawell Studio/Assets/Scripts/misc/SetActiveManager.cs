using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveManager : MonoBehaviour
{
    [SerializeField] Transform Parachute;
    public List<GameObject> _shields;
    [SerializeField] GameObject[] DropBoxtoActivate;
    private void Start()
    {
        StartCoroutine(DropBoxActive());
    }
    private void Update()
    {
        if (Parachute)
        {
            if (Parachute.position.y<10)
            {
                Parachute.gameObject.SetActive(false);
            }
        }
        if (_shields.Count!=0)
        {
            for (int i = 0; i < _shields.Count; i++)
            {
                if (_shields[i].transform.position.y<=-10)
                {
                    _shields[i].SetActive(false);
                }
            }
        }

    }

    IEnumerator DropBoxActive()
    {
        yield return new WaitForSeconds(10);
        DropBoxtoActivate[0].SetActive(true);
        DropBoxtoActivate[0].transform.position = new Vector3(Random.Range(0, 16), 1.38f, Random.Range(0, 16));
        yield return new WaitForSeconds(10);
        DropBoxtoActivate[1].SetActive(true);
        DropBoxtoActivate[1].transform.position = new Vector3(Random.Range(0, 16), 1.38f, Random.Range(0, 16));

    }
}
