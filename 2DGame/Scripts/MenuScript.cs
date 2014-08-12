using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{

		// Use this for initialization
		int buttonWidth = 84;
		int buttonHeight = 40;

		void OnGUI ()
		{
				if (GUI.Button (new Rect (Screen.width * 2 / 3 - buttonWidth / 2, Screen.height * 2 / 3 - buttonHeight / 2, buttonWidth, buttonHeight), "START")) {
						Application.LoadLevel ("stage1");
				}
		}
	
}
