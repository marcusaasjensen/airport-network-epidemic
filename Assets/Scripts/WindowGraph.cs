using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private StatisticsManager stats;
    [SerializeField] private float timeBetweenValues;
    [SerializeField] private float timeBetweenRefreshes;

    private RectTransform graphContainer;
    int secondsPassed;
    bool endStats;

    List<int> airplanesWithViruscasesList = new List<int>();
    List<int> airportsWithViruscasesList = new List<int>();
    List<int> safeAirplanesList = new List<int>();
    List<int> lockdownAirportList = new List<int>();
    //List<int> safeAirportsList = new List<int>();

    Color32 airplanesWithVirusCasesColorCurv;
    Color32 airportsWithVirusCasesColorCurv;
    Color32 safeAirplanesColorCurv;
    Color32 lockdownAirportColorCurv;
    //Color32 safeAirportsColorCurv;
    public int GetSecondsPassed()
    {
        return secondsPassed;
    }

    void Awake()
    {
        airplanesWithVirusCasesColorCurv = new Color32(255,0,0,255);
        airportsWithVirusCasesColorCurv = new Color32(0,0,255,255);
        safeAirplanesColorCurv = new Color32(0,255,0,255);
        lockdownAirportColorCurv = new Color32(255,255,255,255);
        //safeAirportsColorCurv = new Color32(0,255,255,255);
        secondsPassed = 0;
        endStats = false;
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

        StartCoroutine(PointAdder(timeBetweenValues));
        StartCoroutine(GraphActualizer(timeBetweenRefreshes));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            endStats = true;
        }
    }

    IEnumerator GraphActualizer(float sec)
    {
        while(!endStats)
        {
            yield return new WaitForSeconds(sec);
            foreach(Transform child in transform.Find("GraphContainer").GetComponent<Transform>())
            {
                if(child.name == "circle")
                {
                    Destroy(child.gameObject);
                }
            }
            ShowGraph(airplanesWithViruscasesList, secondsPassed, stats.numberOfAirplanes, airplanesWithVirusCasesColorCurv);
            ShowGraph(airportsWithViruscasesList, secondsPassed, stats.numberOfAirports, airportsWithVirusCasesColorCurv);
            ShowGraph(safeAirplanesList, secondsPassed, stats.numberOfAirplanes, safeAirplanesColorCurv);
            ShowGraph(lockdownAirportList, secondsPassed, stats.numberOfAirports, lockdownAirportColorCurv);
            //ShowGraph(safeAirportsList, secondsPassed, stats.numberOfAirports, safeAirportsColorCurv);
        }
    }

    IEnumerator PointAdder(float sec)
    {
        while(!endStats)
        {
             yield return new WaitForSeconds(sec);
             secondsPassed++;
             airplanesWithViruscasesList.Add(stats.numberOfAirplanesWithVirusCases);
             airportsWithViruscasesList.Add(stats.numberOfAirportsWithVirusCases);
             safeAirplanesList.Add(stats.numberOfAirplanes - stats.numberOfAirplanesWithVirusCases);
             lockdownAirportList.Add(stats.numberOfBlockedAirports);
             //safeAirportsList.Add(stats.numberOfAirports - stats.numberOfAirportsWithVirusCases);
        }
    }

    private GameObject CreateCircle(Vector2 anchoredPosition, Color color) //implémenter couleur
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        gameObject.GetComponent<Image>().color = color;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(.5f, 1);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<int> valueList,float xMaximum, float yMaximum, Color color)
    {
        float graphLength = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;
        float xOffset = 3;
        float yOffset = 5;

        for(int i = 0 ; i < valueList.Count ; i++)
        {
            float xPosition = (i / (xMaximum)) * (graphLength-2*xOffset) + xOffset;
            float yPosition = (valueList[i] / yMaximum) * (graphHeight-2*yOffset)+ yOffset;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition), color);
        }
    }
}
