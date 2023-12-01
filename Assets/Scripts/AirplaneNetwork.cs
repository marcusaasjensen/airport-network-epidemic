using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneNetwork : MonoBehaviour
{
    public List<Airplane> airplanes;
    public List<Airplane> airplanesWithVirusCases;
    public AirplaneNetworkBuilder airplaneNetworkBuilder;


    void Start()
    {
        airplanesWithVirusCases = new List<Airplane>();
        airplanes = new List<Airplane>();
        for(int i = 0 ; i < airplaneNetworkBuilder.airplanes.Count ; i++)
        {
            airplanes.Add(airplaneNetworkBuilder.airplanes[i].GetComponent<Airplane>());
        }
    }

    void Update()
    {
        foreach(Airplane airplane in airplanes)
        {
            if(airplane.hasVirus && !airplanesWithVirusCases.Contains(airplane))
            {
                airplanesWithVirusCases.Add(airplane);
            } else if(!airplane.hasVirus && airplanesWithVirusCases.Contains(airplane))
            {
                airplanesWithVirusCases.Remove(airplane);
            }
        }
    }
}
