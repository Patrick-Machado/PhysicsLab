using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoBox : MonoBehaviour {

	public GameObject ponto;
	public List< GameObject> box;

	public Material red;
	public Material green;

	void FixedUpdate () {
        foreach(GameObject boxG in box)
        {
		    if (CheckCollision (ponto, boxG)) {
			    ponto.GetComponent<MeshRenderer> ().material = red;
			    boxG.GetComponent<MeshRenderer> ().material = red;
                GetComponent<Pipe_Spawner>().GameOver();
		    } else {
			    //ponto.GetComponent<MeshRenderer> ().material = green;
			    boxG.GetComponent<MeshRenderer> ().material = green;
		    }
        }
	}

	bool CheckCollision(GameObject p, GameObject b)  {

		bool collisionX = p.transform.position.x >= b.transform.position.x - b.transform.localScale.x/2.0f && 
			b.transform.position.x + b.transform.localScale.x/2.0f >= p.transform.position.x;

		bool collisionY = p.transform.position.y >= b.transform.position.y  - b.transform.localScale.y/2.0f&& 
			b.transform.position.y + b.transform.localScale.y/2.0f >= p.transform.position.y;

		bool collisionZ = p.transform.position.z >= b.transform.position.z  - b.transform.localScale.z/2.0f&& 
			b.transform.position.z + b.transform.localScale.z/2.0f >= p.transform.position.z;

		return collisionX && collisionY && collisionZ;
	} 

}
