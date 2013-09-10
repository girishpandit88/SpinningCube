using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float speed = 100f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Time.deltaTime%10==0)
			transform.Rotate(Vector3.up,speed*Time.deltaTime);
		else 
			transform.Rotate(Vector3.down,speed*Time.deltaTime);
	}
}
