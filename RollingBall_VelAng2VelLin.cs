using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall_VelAng2VelLin : MonoBehaviour
{
    public Vector3 angularVelocity;
    Vector3 angle;
    float radius;
    Vector3 linearVelocity, displace;
    public Vector3 normal;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        radius = transform.localScale.x / 2.0f;
        angularVelocity *= Mathf.Deg2Rad;
        myQ = new myQuaternion();
    }
    myQuaternion myQ;
    Vector4 qua2rot;
    // Update is called once per frame
    void FixedUpdate()
    {
        time = Time.fixedDeltaTime;
        angle += angularVelocity * time;
        linearVelocity = Vector3.Cross(
            angularVelocity, normal) * radius;
        displace += linearVelocity * time;

        qua2rot = myQ.GetQuard(angle.x, angle.y, angle.z);
        Quaternion q = new Quaternion(qua2rot.x, qua2rot.y, qua2rot.z, qua2rot.w);
        transform.rotation = q;

            //Quaternion.Euler(angle);// or the created method GetQuard from myQuaternion.cs
        transform.position = displace;
    }
}
