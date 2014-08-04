using UnityEngine;
using System.Collections;

public class moveCube : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.R)) {
						gameObject.renderer.material.color = Color.red;	
				}
				if (Input.GetKeyDown (KeyCode.B)) {
						gameObject.renderer.material.color = Color.blue;		
				}
				if (Input.GetKeyDown (KeyCode.G)) {
						gameObject.renderer.material.color = Color.green;		
				}
		}

		void OnMouseDown ()
		{
				Debug.Log ("mouse down");
				rigidbody.AddForce (transform.forward * 100);
		}
}
