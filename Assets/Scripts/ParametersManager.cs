using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametersManager : MonoBehaviour
{
    [SerializeField] private GameObject airportNetworkBuilder;
    [SerializeField] private GameObject virus;
    [SerializeField] private GameObject virusSpreadingManager;

    [Range(0,100)] private int virusContaminationRate;
    private int numberOfAirports;
    private float dt; //delta time of the virus (time between chance of contaminating)
    private int virusLifeTime; //time between every moment the virus might die
    private float chanceOfVirusCleaningWhenLockdown; //rules against virus when lockdown (is logically above chanceOfVirusCleaning)
    private float chanceOfVirusCleaning; //rules against virus in general
    private float cleaningDeltaT; //time between clean ups of a blocked airport

    [SerializeField] Text chanceOfVirusCleaningText;
    [SerializeField] Text chanceOfVirusCleaningWhenLockdownText;
    [SerializeField] Text contaminationRateText;
    
    void Update()
    {
        airportNetworkBuilder.GetComponent<AirportNetworkBuilder>().nbNodes = numberOfAirports;
        
        virusSpreadingManager.GetComponent<VirusSpreading>().cleaningDeltaT = cleaningDeltaT;
        virusSpreadingManager.GetComponent<VirusSpreading>().chanceOfVirusCleaningPer1000 = chanceOfVirusCleaning;
        virusSpreadingManager.GetComponent<VirusSpreading>().chanceOfVirusCleaningWhenLockdown = chanceOfVirusCleaningWhenLockdown;

        virus.GetComponent<Virus>().contaminationRate = virusContaminationRate;
        virus.GetComponent<Virus>().dt = dt;
        //virus.GetComponent<Virus>().lifeTime = virusLifeTime;
    }

    public void SetCleaningDeltaTime(string n)
    {
        if(int.Parse(n) >= 0)
            cleaningDeltaT = int.Parse(n);
        else
            cleaningDeltaT = 1;
    }

    public void SetNumberOfAirports(string n)
    {
        if(int.Parse(n) >= 0)
            numberOfAirports = int.Parse(n);
        else
            numberOfAirports = 0;
    }

    public void SetChanceOfVirusCleaning(float i)
    {
        if(i>=0f)
        {
            chanceOfVirusCleaning = Mathf.RoundToInt(i*1000);
            chanceOfVirusCleaningText.text = "Chance of virus cleaning: " + (Mathf.Round(i*1000)/1000).ToString();
        }
        else
            chanceOfVirusCleaning = 100;
    }

    public void SetChanceOfVirusCleaningWhenLockdown(float i)
    {
        if(i>=0f)
        {
            chanceOfVirusCleaningWhenLockdown = Mathf.RoundToInt(i*1000);
            chanceOfVirusCleaningWhenLockdownText.text = "Chance of lockdown virus cleaning: " + (Mathf.Round(i*1000)/1000).ToString();
        }
        else
            chanceOfVirusCleaning = 900;
    }

    public void SetVirusContaminationRate(float i)
    {
        if(i>=0f)
        {
            virusContaminationRate = Mathf.RoundToInt(i*100);
            contaminationRateText.text = "Chance of airplane getting virus: " + (Mathf.Round(i*100)/100).ToString();
        }
        else
            virusContaminationRate = 100;
    }

    public void SetDeltaTime(string t)
    {
        if(float.Parse(t) > 0)
            dt = float.Parse(t);
        else 
            dt = 0.1f;
    }

    /*public void SetVirusLifeTime(string t)
    {
        if(int.Parse(t) > 0)
            virusLifeTime = int.Parse(t);
        else
            virusLifeTime = 3;
    }*/

}
