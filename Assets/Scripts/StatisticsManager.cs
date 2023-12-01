using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public AirplaneNetwork airplaneNetwork;
    public AirportNetwork airportNetwork;

    public int numberOfAirplanes;
    public int numberOfAirplanesWithVirusCases;

    public int numberOfAirports;
    public int numberOfAirportsWithVirusCases;
    public int numberOfBlockedAirports;

    void Start()
    {
        numberOfAirplanes = airplaneNetwork.airplanes.Count;
        numberOfAirports = airportNetwork.airports.Count;
    }
    void Update()
    {
        numberOfAirportsWithVirusCases = airportNetwork.airportsWithVirusCases.Count;
        numberOfAirplanesWithVirusCases = airplaneNetwork.airplanesWithVirusCases.Count;
        numberOfBlockedAirports = airportNetwork.blockedAirports.Count;
    }
        

    
}
