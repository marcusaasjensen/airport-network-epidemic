using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockdownActions : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 100))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(hit.transform.GetComponent<Airport>()!=null)
                {
                    Airport airport = hit.transform.GetComponent<Airport>();
                    if(airport.isBlocked)
                        airport.isBlocked=false;
                    else
                        airport.isBlocked=true;
                }
            }
        }    
    }
}
