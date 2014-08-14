using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MaterialScript))]
public class MaterialAnimation : MonoBehaviour {

	public int min = 0;
	public int max = 0;

	public int fps = 5;

	private float timer;

	private MaterialScript ms;

	// Use this for initialization
	void Start () {
		resetTimer();
		ms = GetComponent<MaterialScript>();
		ms.pos = min;
		ms.setMaterial();
	}
	
	// Update is called once per frame
	void Update () {
		if(ms){
			timer -= Time.deltaTime;
			if(timer<0){
				resetTimer();
				ms.pos++;

				if(ms.pos>max){
					ms.pos = min;
				}

				ms.setMaterial();
			}
		}
	}

	void resetTimer(){
		timer = 1f/fps;
	}
}
