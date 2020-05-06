using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque_AngularAcceleration : MonoBehaviour
{
    public Vector3 force;
    public Vector3 arm;
    public float mass;
    public Vector3 torque;//angular
    Vector3 angAcc;
    Vector3 inertia;
    Vector3 angularVelocity;
    Vector3 angle;
    float radius;
    Vector3 displacement;//linear
    Vector3 velocity;
    float time;



    // Start is called before the first frame update
    void Start()
    {
        radius = transform.localScale.x / 2;
        //calculo of inertia rotational sphere
        float inert = 0.4f * mass * (radius * radius);
        inertia = new Vector3(inert, inert, inert);
        myQ = new myQuaternion();
    }
    myQuaternion myQ;
    Vector4 qua2rot;
    // Update is called once per frame
    void FixedUpdate()
    {
        time = Time.fixedDeltaTime;
        torque = Vector3.Cross(arm, force);// torque = cross(arm,force)
        angAcc = divVector(torque, inertia);//ang = torque / inertia;
        angularVelocity += angAcc * time;// w = w0 + aa *t -> w = ômega or angular velocity
        angle += angularVelocity * time;// angle rotation

        qua2rot = myQ.GetQuard(angle.x, angle.y, angle.z);
        Quaternion q = new Quaternion(qua2rot.x, qua2rot.y, qua2rot.z, qua2rot.w);

        transform.rotation = q; //
        velocity = Vector3.Cross(angularVelocity, Vector3.up) * radius;
        displacement += velocity * time;
        transform.position = displacement;
    }

    Vector3 divVector(Vector3 v, Vector3 u)
    {

        return new Vector3(v.x/u.x,v.y/u.y,v.z/u.z);
    }
}
