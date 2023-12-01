using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportNetworkBuilder : MonoBehaviour
{
    public List<GameObject> nodes;
    public int nbNodes;
    public float spaceRangeMinMax;
    public Transform networkHolder;
    public GameObject pointPrefab;
    public GameObject airplaneNetworkBuilder;

    void Start()
    {
        Vector3 randomXYPosition;
        
        for(int i = 0 ; i < nbNodes ; i++)
        {
            randomXYPosition = new Vector3(Random.Range(-spaceRangeMinMax,spaceRangeMinMax),0, Random.Range(-spaceRangeMinMax,spaceRangeMinMax));
            nodes.Add((GameObject) Instantiate(pointPrefab, randomXYPosition, Quaternion.identity, networkHolder));
        }
        airplaneNetworkBuilder.SetActive(true);
    }

   /* void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        foreach(var node in nodes)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(node.transform.position,0.125f);
            Gizmos.color = Color.black;
            foreach(var connectedNode in nodes) {
                {
                    Gizmos.DrawLine(node.transform.position,connectedNode.transform.position);
                }
            }
        }
    }*/

    public int NbEdges()
    {
        int n = nbNodes;
        int nbEdges = 0;
        for(int i = 1 ; i <= n ; i++)
        {
            nbEdges+=n-i;
        }
        return nbEdges;
    }
}