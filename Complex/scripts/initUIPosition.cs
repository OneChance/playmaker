using UnityEngine;
using System.Collections;

public class initUIPosition : MonoBehaviour {

	private float targetX;  
	private float targetY;  
	
	public Camera uiCam;

	// Use this for initialization
	void Start () { 

		targetX = transform.localScale.x /2;

		targetY = 20;

		setScreenPosition(targetX, uiCam.pixelHeight-targetY);  
	}
	
	void setScreenPosition(float x,float y)  
	{  
		Vector3 targetPos = uiCam.ScreenToWorldPoint(new Vector3(x, y, transform.position.z));  
		Vector3 dir = targetPos - transform.position;  
		transform.Translate(dir);  
	}   
}
