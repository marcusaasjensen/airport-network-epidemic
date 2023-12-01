using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneRendererController : MonoBehaviour
{
    private Material airplaneVirusStateMat;
    public Material contagiousAirplaneMat;
    public Material safeAirplaneMat; 
    public AirplaneNetwork airplaneNetwork;

    void Start()
    {
        airplaneVirusStateMat = safeAirplaneMat;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Airplane airplane in airplaneNetwork.airplanes)
        {
            if(airplane.GetComponent<Airplane>().hasVirus)
            {
                airplane.GetComponent<Renderer>().material = contagiousAirplaneMat;
            } 
            else
            {
                airplane.GetComponent<Renderer>().material = safeAirplaneMat;
            }
        }
    }
}
