using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    public static bool isLeft;
    public static bool isRight;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {            
            Vector3 clickedpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
           
            if (clickedpos.x < 0)
            {              
                isLeft = true;
            }
            else if (clickedpos.x> 0)
            {             
                isRight = true;
            }
        }
    }
}
