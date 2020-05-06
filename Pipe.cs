using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    Vector3 velocity = new Vector3(0,0,-5f);
    Vector3 displacement;
    float time;
    public GameObject boxA, boxB;
    GameObject gameCtrl;
    bool destroying = false;
    private void Awake()
    {
        displacement = transform.position;
        gameCtrl = GameObject.FindGameObjectWithTag("GameController");
        addMyselfOnlist();
    }
    void FixedUpdate()
    {
        if (!gameCtrl.GetComponent<Pipe_Spawner>().gameIsOn) return;
        time = Time.deltaTime;
        displacement += velocity * time;
        transform.position = displacement;
        if(transform.position.z < -50)
        {
            if (destroying) return;
            destroying = true;
            gameCtrl.GetComponent<PontoBox>().box.RemoveAt(0);
            gameCtrl.GetComponent<PontoBox>().box.RemoveAt(0);
            Invoke("self_destroy", 1f);
        }
    }
    void addMyselfOnlist()
    {
        gameCtrl.gameObject.GetComponent<PontoBox>().box.Add(boxA);
        gameCtrl.gameObject.GetComponent<PontoBox>().box.Add(boxB);
    }

    void self_destroy()
    {
        Destroy(this.gameObject);
    }
}
