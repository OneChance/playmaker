using UnityEngine;
using System.Collections;

public class ratControl : MonoBehaviour
{

		private Vector3[] paths = new Vector3[3];
		int jumbable = 1;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetMouseButtonDown (0) && jumbable == 1) {
						paths [0] = transform.position;
						paths [2] = new Vector3 (transform.position.x + 2f, transform.position.y, 0);
						paths [1] = new Vector3 ((paths [0].x + paths [2].x) / 2, transform.position.y + 3f, 0);
						iTween.MoveTo (gameObject, iTween.Hash ("path", paths, "movetopath", true, "orienttopath", true, "time", 2, "easetype", iTween.EaseType.linear, "lookahead", 0, "onstart", "IsStart", "onstarttarget", gameObject, "oncomplete", "IsComplete", "oncompletetarget", gameObject));
				}
		}

		void IsStart ()
		{
				jumbable = 0;
		}

		void IsComplete ()
		{
				jumbable = 1;
		}

		void OnCollisionEnter2D (Collision2D c)
		{
				Debug.Log (c.gameObject.name);
				if (c.gameObject.name == "box") {
						iTween.Pause (gameObject);	
						IsComplete ();
				}
		}
}
