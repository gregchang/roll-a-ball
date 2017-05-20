using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// action needs to be smooth and frame rate independent
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
