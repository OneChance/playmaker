using UnityEngine;
using System.Collections;

public class AutoMoveScripts : MonoBehaviour {

	public Vector2 speed = new Vector2(10,10);
	public Vector2 direction = new Vector2(-1,0);
	private Vector3 movement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector3 (direction.x*speed.x,direction.y*speed.y,0);
	}

	void FixedUpdate(){
		rigidbody2D.velocity = movement;
	}
}
