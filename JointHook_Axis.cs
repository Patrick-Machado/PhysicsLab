using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointHook_Axis : MonoBehaviour
{


    ///---------
    Rigidbody rigidbody;
    public float force;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rigidbody.AddForce(new Vector3(x * force, 0, z * force));

    }
}

