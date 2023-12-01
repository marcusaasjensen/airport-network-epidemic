using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportNetwork : MonoBehaviour
{
    public AirportNetworkBuilder airportNetworkBuilder;
    public List<Airport> airports;
    public List<Airport> airportsWithVirusCases;
    public List<Airport> blockedAirports;
    public int minAirportPopulation = 1000;
    public int maxAirportPopulation = 10000;
    void Start()
    {
        airports = new List<Airport>();
        airportsWithVirusCases = new List<Airport>();
        blockedAirports = new List<Airport>();
        for(int i = 0 ; i < airportNetworkBuilder.nbNodes ; i++)
        {
            Airport airport = airportNetworkBuilder.nodes[i].GetComponent<Airport>();
            airport.populationDensity = Random.Range(30,100)*0.01f;
            airports.Add(airport);
        }
    }

    void Update()
    {
        foreach(Airport airport in airports)
        {
            if(airport.hasVirusCases && !airportsWithVirusCases.Contains(airport))
            {
                airportsWithVirusCases.Add(airport);
            }
            
            if(airport.hasVirusCases==false && airport.airportVirusState!=1)
                airport.airportVirusState=0;
            if(airport.airportVirusState==0 || airport.hasVirusCases==false)
                airportsWithVirusCases.Remove(airport);

            if(airport.isBlocked && !blockedAirports.Contains(airport))
            {
                blockedAirports.Add(airport);
            }
            else if(!airport.isBlocked && blockedAirports.Contains(airport))
            {
                blockedAirports.Remove(airport);
            }

        }
    }
}
