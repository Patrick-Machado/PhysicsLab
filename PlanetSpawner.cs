using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public Gravitacao Sun;
    public GameObject planetPref;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnPlanet", 1f);
    }
    int i = 0;
    void spawnPlanet()
    {
        i += 1;
        Debug.Log(i);
        GameObject newPlanet;
        newPlanet = Instantiate(planetPref, this.transform.position, Quaternion.identity) as GameObject;
        newPlanet.GetComponent<Gravitacao>().Others = Sun;
        if(i<20)
        Invoke("spawnPlanet", 1.1f);
    }
    //Circle Elipse on vel Z = 4.472113;
    //Elipsoidal value on vel Z = 5.5;
}
