using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

		// Use this for initialization
		int buttonWidth = 84;
		int buttonHeight = 40;

		void OnGUI ()
		{
				if (GUI.Button (new Rect (Screen.width * 1 / 3 - buttonWidth / 2, Screen.height / 2 - buttonHeight / 2, buttonWidth, buttonHeight), "RETRY")) {
						EnemyManager.isGameOver = false;				
						Application.LoadLevel ("stage1");
				}

				if (GUI.Button (new Rect (Screen.width * 2 / 3 - buttonWidth / 2, Screen.height / 2 - buttonHeight / 2, buttonWidth, buttonHeight), "MENU")) {
						EnemyManager.isGameOver = false;	
						Application.LoadLevel ("start");
				}
		}
	
}
