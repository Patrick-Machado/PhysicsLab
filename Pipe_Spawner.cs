using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pipe_Spawner : MonoBehaviour
{
    public bool gameIsOn = true;
    public GameObject pref_Pipe;
    PontoBox colisionCtrl;

    void Awake()
    {
        colisionCtrl = GetComponent<PontoBox>();
        SpawnPipe();
    }

    void SpawnPipe()
    {
        if (!gameIsOn) return;
        GameObject pipe = Instantiate(pref_Pipe, new Vector3(transform.position.x,randomPosition()
            ,transform.position.z), 
            Quaternion.identity) as GameObject;
        Invoke("SpawnPipe", 4f);
    }
    float randomPosition()
    {
        return Random.Range(0f, 16f);
    }

    public void GameOver()
    {
        gameIsOn = false;
        Invoke("Restart", 2f);
    }
    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);

    }
}
