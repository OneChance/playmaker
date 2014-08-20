using UnityEngine;
using System.Collections;

public class ColorSomething : MonoBehaviour {

	public void setRed(){
		this.GetComponent<UIWidget>().color = Color.red;
	}

	public void setBlue(){
		this.GetComponent<UIWidget>().color = Color.blue;
	}
}
