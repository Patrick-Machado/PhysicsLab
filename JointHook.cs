using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JointHook : MonoBehaviour
{
    public GameObject other;

    public float k;
    public float rest_length;
    public bool rigid;

    Vector3 force;
    Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Vector3 d = transform.position - other.transform.position;
        float magnitude = d.magnitude - rest_length;

        if ((magnitude <= rest_length) && (!rigid))
          return;

        force = -k * magnitude * d.normalized;
        rg.AddForce(force);
    }

}
