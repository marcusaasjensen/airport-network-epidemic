using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneNetworkBuilder : MonoBehaviour
{
    public Transform airplanesHolder;
    public GameObject airplanePrefab;
    public AirportNetworkBuilder airportNetworkBuilder;
    public List<GameObject> airplanes;
    
    void Start()
    {
        //Créer un réseau de trajets d'avions à partir d'un graphe. Le graphe est un support pour les trajets et la position de chaque avion : le réseau d'avion dépend forcément d'un graphe.
        airplanes = CreateAirplanesWith2Airports(airportNetworkBuilder);
    }

    public List<GameObject> CreateAirplanesWith2Airports(AirportNetworkBuilder graph)
    {
        List<GameObject> airplanes = new List<GameObject>();

        //Le swipe permet d'assigner les trajets d'avions de manière à ce qu'il y ait au moins un avion par aéroport. Il ne change pas le trajet mis à part la position de départ des avions
        int swipe = 0;

        //Assigne un avion par arète du graphe mis en paramètre
        for(int indexOfFirstAirport = 0 ; indexOfFirstAirport < graph.nodes.Count - 1 ; indexOfFirstAirport++)
        {
            //Les deux boucles for sont écrites de manière à ne pas créer d'avions ayant le même trajet
            //Gère des GameObject car cela instancie tous les objets. Il ne se charge pas de recueillir les données, mais de gérer l'intantiation et leur accès
            for(int indexOfSecondAirport = indexOfFirstAirport+1 ; indexOfSecondAirport < graph.nodes.Count ; indexOfSecondAirport++)
            {
                GameObject firstAirport = graph.nodes[indexOfFirstAirport];
                GameObject secondAirport = graph.nodes[indexOfSecondAirport];
                
                GameObject airplane= (GameObject) Instantiate(airplanePrefab, airplanesHolder);

                if(swipe%2==0)
                {
                    // /!\ Toujours instancier la liste de airplaneRide avant d'instancier airplaneRide
                    airplane.GetComponent<Airplane>().ride = new List<GameObject>{firstAirport, secondAirport};
                }
                else
                {
                    airplane.GetComponent<Airplane>().ride = new List<GameObject>{secondAirport, firstAirport};
                }
                airplanes.Add(airplane);
                firstAirport.GetComponent<Airport>().airplanes.Add(airplane.GetComponent<Airplane>());
                secondAirport.GetComponent<Airport>().airplanes.Add(airplane.GetComponent<Airplane>());
                swipe++;
            }
        }
        return airplanes;
    }


//ancien code (voir évolution)
    /*public List<AirplaneRide> CreateAirplaneRides(Graph graph)
    {
        List<AirplaneRide> airplanes = new List<AirplaneRide>();

        //Le swipe permet d'assigner les trajets d'avions de manière à ce qu'il y ait au moins un avion par aéroport. Il ne change pas le trajet mis à part la position de départ des avions
        int swipe = 0;

        //Assigne un avion par arète du graphe mis en paramètre
        for(int indexOfFirstAirport = 0 ; indexOfFirstAirport < graph.nodes.Count - 1 ; indexOfFirstAirport++)
        {
            //Les deux boucles for sont écrites de manière à ne pas créer d'avions ayant le même trajet
            for(int indexOfSecondAirport = indexOfFirstAirport+1 ; indexOfSecondAirport < graph.nodes.Count ; indexOfSecondAirport++)
            {
                GameObject firstAirport = graph.nodes[indexOfFirstAirport];
                GameObject secondAirport = graph.nodes[indexOfSecondAirport];

                if(swipe%2==0)
                {
                    // /!\ Toujours instancier la liste de airplaneRide avant d'instancier airplaneRide
                    airplanes.Add(new AirplaneRide((GameObject) Instantiate(airplanePrefab, airplanesHolder), new List<GameObject>{firstAirport, secondAirport}));
                }
                else
                {
                    airplanes.Add(new AirplaneRide((GameObject) Instantiate(airplanePrefab, airplanesHolder), new List<GameObject>{secondAirport, firstAirport}));
                }
                swipe++;
            }
        }
        return airplanes;
    }*/
    
}

/*public class AirplaneRide
{
    public List<GameObject> ride;
    public GameObject airplane;

    //Si on ne veut pas assigner de trajets à un avion (fait pour avoir un trajet)
    public AirplaneRide(GameObject airplane)
    {
        this.airplane = airplane;
        this.ride = new List<GameObject>();
    }

    public AirplaneRide(GameObject airplane, List<GameObject> ride)
    {
        this.airplane = airplane;
        airplane.transform.position = ride[0].transform.position;
        airplane.transform.rotation = Quaternion.Euler(90,0,0);
    }
}*/

/*
        for(int i = 0 ; i < graph.NbEdges(); i++)
        {
            airplanes.Add(new AirplaneRide((GameObject) Instantiate(airplanePrefab), new List<GameObject>()));
        }
        //next permet d'assigner à un nouvel élément
        int next = 0;
        for(int i = 0 ; i < graph.nodes.Count - 1 ; i++)
        {
            for(int j = i+1 ; j < graph.nodes.Count ; j++)
            {
                if(next%2==0)
                {
                    airplanes[next].ride.Add(graph.nodes[i]);
                    airplanes[next].ride.Add(graph.nodes[j]);
                } 
                else
                {
                    airplanes[next].ride.Add(graph.nodes[j]);
                    airplanes[next].ride.Add(graph.nodes[i]);
                }
                airplanes[next].airPlane.transform.position = airplanes[next].ride[0].transform.position;
                next++;
            }
        }*/