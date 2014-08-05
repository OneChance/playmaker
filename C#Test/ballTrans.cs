using UnityEngine;
using System.Collections;

public class ballTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Time.time);
		transform.position = new Vector3 (transform.position.x,Mathf.PingPong(Time.time,2),transform.position.z);
		transform.Rotate (0,90*Time.deltaTime,0);
		transform.localScale = new Vector3(Mathf.PingPong(Time.time,2),Mathf.PingPong(Time.time,2),Mathf.PingPong(Time.time,2));
	}
}
