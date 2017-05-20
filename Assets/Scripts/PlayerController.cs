using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	private GameObject[] pickups;
	private int pickupsCount;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		pickups = GameObject.FindGameObjectsWithTag ("Pick Up");
		pickupsCount = pickups.Length;
	}
	
	// Update is called once per frame, before a frame
	void Update ()
	{
		
	}

	// FixedUpdate is called once per frame, before performing any physics calculations
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

	// Called when then collider enters the trigger
	// Need to set colliders to 'is trigger'
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= pickupsCount) {
			winText.text = "You Win!";
		}
	}

	// Static colliders usually non-moving objects
	// Dynamic colliders are usually things that move
	// In collisions static objects are not affected

	// For performance, static collider volumes are stored in cache
	// Moving, rotating, or scaling static colliders
	// results in recaching of static collider volumes

	// Any gameobject with a collider and a rigid body is considered dynamic
	// Any gameobject with a collider and no rigid body is considered static

	// Kinematic rigid bodies will not react to physics forces,
	// can be animated and moved by transform

	// Standard rigid bodies are moved using physics forces.
	// Kinematic rigid bodies are moved using
	// their transform.

	// All UI elements must be a child of a Canvas to behave correctly
	// UI elements have Rect Transform
	// Details about the UI toolset are held in namespace
}
