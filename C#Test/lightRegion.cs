using UnityEngine;
using System.Collections;

public class lightRegion : MonoBehaviour {

	private float intensity;
	private float spotAngle;

	// Use this for initialization
	void Start () {
		intensity = light.intensity;
		spotAngle = light.spotAngle;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeIntensity ();
	}

	void ChangeIntensity(){
		float intensityStart = 0.5f;
		float intensityEnd = 5f;

		float spotAngleStart = 30;
		float spotAngleEnd = 100;


		if(Input.GetKeyDown(KeyCode.A)){
			intensity = intensityStart;
			spotAngle = spotAngleStart;
		}
		if(Input.GetKeyDown(KeyCode.D)){
			intensity = intensityEnd;
			spotAngle = spotAngleEnd;
		}

		light.intensity = Mathf.Lerp(light.intensity,intensity,Time.deltaTime);
		light.spotAngle = Mathf.Lerp(light.spotAngle,spotAngle,Time.deltaTime);
		//light.spotAngle = Mathf.LerpAngle(light.spotAngle,spotAngle,Time.deltaTime);
	}
}
