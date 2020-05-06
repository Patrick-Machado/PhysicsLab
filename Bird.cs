using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MRUA_my
{
    bool live = true;
    public float force = 500;
    public float maxDesloc = 18f;
    public Pipe_Spawner gamecontroller;
    void Update()
    {
        if (!gamecontroller.gameIsOn) { return; }
        if (deslocamento.y >= 18) { deslocamento.y = 18; }

        if (Input.GetKeyDown(KeyCode.Space) && live && deslocamento.y < maxDesloc)
        {
            AddForce(new Vector3(0,force,0)); 
        }
    }
   
}
