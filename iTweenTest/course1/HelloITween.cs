using UnityEngine;
using System.Collections;

public class HelloITween : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			iTween.MoveTo(this.gameObject,new Vector3(3,3,3),5f);		
		}
	}
}
