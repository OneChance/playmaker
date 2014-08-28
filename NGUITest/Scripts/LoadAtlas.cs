using UnityEngine;
using System.Collections;

public class LoadAtlas : MonoBehaviour {

	public UIAtlas referance;
	public string sdAtlas = "SD";
	public string hdAtlas = "HD";
	public bool loadHD = false;

	void Awake(){
		GameObject go = Resources.Load(loadHD?hdAtlas:sdAtlas,typeof(GameObject)) as GameObject;
		referance.replacement = go.GetComponent<UIAtlas>();
	}
}
