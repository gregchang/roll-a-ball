﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// For following cameras, procedural animation, and gathering last known states use LateUpdate, runs after Update
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
