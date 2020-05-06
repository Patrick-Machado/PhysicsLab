using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitacao : MonoBehaviour
{
    public float Mass;
    public Vector3 Force;
    public Vector3 Velocity;
    Vector3 Displacement;
    public Gravitacao Others;
    float G = 0.001f; 

    // Start is called before the first frame update
    void Start()
    {
        Displacement = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Others == null) { return; }
        Vector3 diff = Others.transform.position - transform.position;
        Force = diff.normalized * (G * Mass * Others.Mass / (diff.magnitude * diff.magnitude));
        Vector3 gravity = Force / Mass;
        Velocity += gravity * Time.fixedDeltaTime;
        Displacement += Velocity * Time.fixedDeltaTime;
        transform.position = Displacement;
    }
}
