using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStatistics : MonoBehaviour
{
    [SerializeField] private StatisticsManager stats;
    [SerializeField] private WindowGraph windowGraph;
    [SerializeField] private Text airplanesWithVirusCasesText;
    [SerializeField] private Text airportsWithVirusCasesText;
    [SerializeField] private Text safeAirplanesText;
    [SerializeField] private Text blockedAirportsText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text totalText;
    

    // Update is called once per frame
    private void Update()
    {
        airplanesWithVirusCasesText.text = stats.numberOfAirplanesWithVirusCases.ToString() + " = Number of airplanes with virus cases";
        airportsWithVirusCasesText.text = stats.numberOfAirportsWithVirusCases.ToString() + " = Number of airports with virus cases";
        safeAirplanesText.text = (stats.numberOfAirplanes - stats.numberOfAirplanesWithVirusCases).ToString() + " = Number of safe airplanes";
        blockedAirportsText.text = stats.numberOfBlockedAirports.ToString() + " = Number of blocked airports";
        timeText.text = (windowGraph.GetSecondsPassed()).ToString() + " Days (sec)";
        totalText.text = "Total nb airplanes = " + stats.numberOfAirplanes.ToString() + "/ nb airports = " + stats.numberOfAirports; 
    }
}
