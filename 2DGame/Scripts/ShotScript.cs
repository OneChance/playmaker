using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;
	public bool isEnemy = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject,GetDestroyTime());
	}
	
	// Update is called once per frame
	void Update () {

	}

	float GetDestroyTime(){
		return 45 / GetComponent<AutoMoveScripts> ().speed.x;
	}
}
