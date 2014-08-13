using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;
	public bool isEnemy = false;

	// Use this for initialization
	void Start () {
		gameObject.hideFlags = HideFlags.HideInHierarchy;
	}
	
	// Update is called once per frame
	void Update () {
		if(!renderer.isCamVisible(Camera.main)){
			Destroy(gameObject);
		}
	}

}
