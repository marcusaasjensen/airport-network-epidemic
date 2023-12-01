using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpreading : MonoBehaviour
{
    public Virus virus;
    public AirplaneNetwork airplaneNetwork;
    public float chanceOfVirusCleaningPer1000; // sur 1000
    public float cleaningDeltaT;
    public float chanceOfVirusCleaningWhenLockdown; //sur 1000

    void Start()
    {
        if(airplaneNetwork.airplanes.Count!=0)
            airplaneNetwork.airplanes[Random.Range(0,airplaneNetwork.airplanes.Count-1)].hasVirus = true;
        StartCoroutine(Spreading());
        StartCoroutine(CleaningVirus(chanceOfVirusCleaningPer1000));
    }

    IEnumerator Spreading()
    {
        while(true)
        {
            foreach(Airplane airplane in airplaneNetwork.airplanes)
            {
                if(airplane.currentAirport!=null && !airplane.currentAirport.isBlocked)
                {
                        if(airplane.currentAirport.hasVirusCases)
                        {
                            Infect(airplane);
                        }
                }
                
            }
            yield return new WaitForSeconds(virus.dt);
        }
    }


    public void Infect(Airplane airplane)
    {
        float virusMorbidityRate = virus.contaminationRate;
        if(airplane.checkInfection && !(airplane.hasVirus) && !airplane.currentAirport.isBlocked)
        {
            float randomness = Random.Range(1, 100);
            if(randomness <= virusMorbidityRate)
            {
                airplane.hasVirus = true;
            }
            else
            {
                airplane.hasVirus = false;
            }
            airplane.checkInfection = false;
        } 
    }
    IEnumerator CleaningVirus(float chanceOfVirusCleaning1000)
    {
        while(true)
        {
            foreach(Airplane airplane in airplaneNetwork.airplanes)
            {
                if(airplane.currentAirport!=null)
                {
                    float chanceOfVirusCleaning = chanceOfVirusCleaning1000;
                    float randomness = Random.Range(1, 1000);
                    if(airplane.currentAirport.isBlocked)
                    {
                        chanceOfVirusCleaning = chanceOfVirusCleaningWhenLockdown;
                    }
                    if(randomness <= chanceOfVirusCleaning)
                    {
                        airplane.hasVirus = false;
                    }
                }
            }
            
            yield return new WaitForSeconds(cleaningDeltaT);
        }
    }
    /*IEnumerator CleaningVirus(float chanceOfVirusCleaning1000)
    {
        while(true)
        {
            float virusLifeTime = virus.lifeTime;
            foreach(Airplane airplane in airplaneNetwork.airplanes)
            {
                virusLifeTime = virus.lifeTime;
                if(airplane.currentAirport!=null)
                {
                    float chanceOfVirusCleaning = chanceOfVirusCleaning1000;
                    float randomness = Random.Range(1, 1000);
                    if(airplane.currentAirport.isBlocked)
                    {
                        virusLifeTime = lockdownCleaningTime;
                        chanceOfVirusCleaning = chanceOfVirusCleaningWhenLockdown;
                    }
                    if(randomness <= chanceOfVirusCleaning)
                    {
                        airplane.hasVirus = false;
                    }
                }
            }
            
            yield return new WaitForSeconds(virusLifeTime);
        }
    }*/

//https://www.ncbi.nlm.nih.gov/pmc/articles/PMC7806252/ formulas

//popDensity = nb people / area in km²
    float USCOVIDDiseaseMorbidityRate(float density)
    {
        float personPerK = Mathf.Lerp(1.28f, 11685.51f,density); //min and max population density in us
        return 0.0072f*personPerK + 0.7327f;
    }
    
    float HubeiCOVIDDiseaseMorbidityRate(float density)
    {
        float personPerK = Mathf.Lerp(23.41f,317.48f,density);//min and max population ensity in Hubei https://knoema.com/atlas/China/Hubei
        return 0.0015f*personPerK + 0.1227f;
    }
}
