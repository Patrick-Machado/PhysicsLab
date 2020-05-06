using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myQuaternion : MonoBehaviour
{
    /*private void FixedUpdate()
    {
        Debug.Log(GetAngle(transform.localRotation.x, transform.localRotation.y,
            transform.localRotation.z, transform.localRotation.w));
    }*/
    Vector3 GetAngle(float x, float y, float z, float w)
    {
        float angleX, angleY, angleZ;
        float t0 = 2.0f * (w * x + y * z); float t1 = 1.0f - 2.0f * (x * x + y * y);
        angleX = Mathf.Atan2(t0, t1);
        float t2 = 2.0f * (w*y - z*x);
        if (t2 >= 1.0f) { t2 = 1.0f; } else if (t2 < -1.0f) { t2 = -1.0f; }
        angleY = Mathf.Asin(t2);
        float t3 = 2.0f * (w * z + x * y); float t4 = 1.0f - 2.0f * (y * y + z * z);
        angleZ = Mathf.Atan2(t3, t4);
        float Pi = Mathf.PI;
        return new Vector3(angleX*180.0f/Pi, angleY * 180.0f / Pi, angleZ * 180.0f / Pi); //(*180/Pi) de radianos pra converte pra graus
    }
    Vector3 angle;
    Vector4 q;
    GameObject obj;
    private void Start()
    {
        obj = this.gameObject;
    }
    void Update()
    {
        angle = transform.eulerAngles;

        //angle.x * Mathf.PI / 180.0f é o mesmo que angle.x * Mathf.Deg2Rad
        q = GetQuard(angle.x * Mathf.PI / 180.0f, angle.y * Mathf.PI / 180.0f, angle.z * Mathf.PI / 180.0f);
        Debug.Log("myQuart: " + q + "/ Unity Quart: " + obj.transform.rotation + "/ return Angle: " + GetAngle(q.x, q.y, q.z, q.w));

    }


    public Vector4 GetQuard(float angleX, float angleY, float angleZ)//GetQuart de quaternion (erro de digitação)
    {

        float c1 = Mathf.Cos(angleZ / 2.0f);
        float s1 = Mathf.Sin(angleZ / 2.0f);

        float c2 = Mathf.Cos(angleY / 2.0f);
        float s2 = Mathf.Sin(angleY / 2.0f);

        float c3 = Mathf.Cos(angleX / 2.0f);
        float s3 = Mathf.Sin(angleX / 2.0f);

        float c1c2 = c1 * c2;
        float s1s2 = s1 * s2;

        float w = c1c2 * c3 - s1s2 * s3;

        float x = c1c2 * s3 + s1s2 * c3;
        float y = c1 * s2 * c3 - s1 * c2 * s3;
        float z = s1 * c2 * c3 + c1 * s2 * s3;

        return new Vector4(x, y, z, w);
    }

    Vector3 Rotate(Vector4 q, Vector3 p)
    {
        return new Vector3(q.x * p.x, q.y * p.y, q.z * p.z);
    }

    Vector3 GetAngle2(float x, float y, float z, float w)
    {

        float angleX, angleY, angleZ;

        float t0 = 2.0f * (w * x + y * z);
        float t1 = 1.0f - 2.0f * (x * x + y * y);
        angleX = Mathf.Atan2(t0, t1);

        float t2 = 2.0f * (w * y - z * x);
        if (t2 >= 1.0f)
        {
            t2 = 1.0f;
        }
        else if (t2 < -1.0f)
        {
            t2 = -1.0f;
        }
        angleY = Mathf.Asin(t2);

        float t3 = 2.0f * (w * z + x * y);
        float t4 = 1.0f - 2.0f * (y * y + z * z);
        angleZ = Mathf.Atan2(t3, t4);

        return new Vector3(angleX * 180.0f / Mathf.PI, angleY * 180.0f / Mathf.PI, angleZ * 180.0f / Mathf.PI);
    }
}
