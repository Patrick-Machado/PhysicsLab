using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject Q, P;
    public float speed = 100, rotationSpeed = 100;
    public GameObject BulletPrefab;
    Vector3 DirectionToShoot;
    public float shootForce = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirectionToShoot = P.transform.position - Q.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject prefBullet = Instantiate(BulletPrefab, /*DirectionToShoot*/P.transform.position, Quaternion.identity) as GameObject;
            prefBullet.GetComponent<MRUA_my>().AddForce(DirectionToShoot * shootForce);
            //prefBullet.GetComponent<RigidBody>().AddForce(DirectionToShoot, shootForce);
        }
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0,0, rotation);
    }
}
