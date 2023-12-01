using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject airportNetworkBuilder;
    public GameObject airplaneNetworkBuilder;
    public GameObject airportNetwork;
    public GameObject airplaneNetwork;
    public GameObject airplaneRendererController;
    public GameObject airportRendererController;
    public GameObject virusSpreading;
    public GameObject statisticsManager;
    public GameObject windowGraph;
    
    void Start()
    {
        airportNetworkBuilder.SetActive(true);
        airplaneNetworkBuilder.SetActive(true);
        airportNetwork.SetActive(true);
        airplaneNetwork.SetActive(true);
        airportRendererController.SetActive(true);
        airplaneRendererController.SetActive(true);
        virusSpreading.SetActive(true);
        statisticsManager.SetActive(true);
        windowGraph.SetActive(true);
    }
}
