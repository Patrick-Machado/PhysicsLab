using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUA_unity : MonoBehaviour
{
    public Vector3 velocidade;
    Rigidbody rb;
    public Vector3 forca;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = velocidade;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(forca, ForceMode.Force);
    }
}
