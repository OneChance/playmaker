using UnityEngine;
using System.Collections;

public class moveCube : MonoBehaviour
{
		
		private float moveSpeed = 5f;
		private float rotateSpeed = 100;
		private float h;
		private float v;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
//				if (Input.GetKeyDown (KeyCode.R)) {
//						gameObject.renderer.material.color = Color.red;	
//				}
//				if (Input.GetKeyDown (KeyCode.B)) {
//						gameObject.renderer.material.color = Color.blue;		
//				}
//				if (Input.GetKeyDown (KeyCode.G)) {
//						gameObject.renderer.material.color = Color.green;		
//				}

				h = Input.GetAxis ("Horizontal");
				v = Input.GetAxis ("Vertical");
				
//				if (Input.GetKey (KeyCode.W)) {
//						transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
//				} else if (Input.GetKey (KeyCode.S)) {
//						transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
//				} else if (Input.GetKey (KeyCode.A)) {
//						transform.Rotate (Vector3.up, -rotateSpeed * Time.deltaTime);
//				} else if (Input.GetKey (KeyCode.D)) {
//						transform.Rotate (Vector3.up, rotateSpeed * Time.deltaTime);
//				}

				if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) {
						transform.Translate (Vector3.forward * v * moveSpeed * Time.deltaTime);
				} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
						transform.Rotate (Vector3.up, h * rotateSpeed * Time.deltaTime);
				}
				
				
					
				

		}

		void OnMouseDown ()
		{
//				Debug.Log ("mouse down");
//				rigidbody.AddForce (transform.forward * 100);
		}
}
