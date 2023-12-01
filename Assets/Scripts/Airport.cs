using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{
    public int airportVirusState;
    public bool hasVirusCases;
    public bool isBlocked;
    [Range(0.3f,1)]
    public float populationDensity;
    [SerializeField] private float extrapolation;

    public List<Airplane> airplanes;

    void Start()
    {
        //transform.localScale *= populationDensity * extrapolation;
        airportVirusState = 0; //safe airport
    }

    void Update()
    {
        if(isBlocked)
        {
            hasVirusCases = false;
        }
        foreach(Airplane airplane in airplanes)
        {
            if(airplane.hasVirus)
            {
                if(airplane.currentAirport == this)
                {
                    airportVirusState = 2; //contagious airport
                    hasVirusCases = true;
                } 
                else if(hasVirusCases==false)
                {
                    airportVirusState = 1; //potentially contagious airport
                }
            }
        }
    }
}
