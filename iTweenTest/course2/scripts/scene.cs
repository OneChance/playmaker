using UnityEngine;
using System.Collections;

public class scene : MonoBehaviour
{

		private int size = 9;
		public GameObject grid;
		private GameObject preGrid;
		private GameObject ballGrid;
		public GameObject ball;
		Vector3[] pathPoints;
		int pointIndex;
		Hashtable getState = new Hashtable ();

		// Use this for initialization
		void Start ()
		{
				createPlane ();
				pathPoints = new Vector3[2];
				
				ballGrid = GameObject.FindGameObjectsWithTag ("grid") [0];
				setGridDisable (ballGrid);
		}

		void createPlane ()
		{
				for (int i=0; i<size; i++) {
						for (int j=0; j<size; j++) {
								GameObject go = (GameObject)Instantiate (grid, new Vector3 (i, 0, j), Quaternion.identity);
								if ((i + j) % 2 == 0) {
										iTween.ColorTo (go, Color.black, 0f);
								}			
						}
				}	
		}

		void gridStateBack (GameObject go)
		{
				if ((go.transform.position.x + go.transform.position.z) % 2 == 0) {
						iTween.ColorTo (go, Color.black, 0.2f);
				} else {
						iTween.ColorTo (go, Color.white, 0.2f);
				}
		
				iTween.MoveTo (go, new Vector3 (go.transform.position.x, 0f, go.transform.position.z), 0.2f);	
		}

		void gridUp (GameObject go)
		{			
				if (preGrid != null && preGrid != go && ballGrid != preGrid) {
						gridStateBack (preGrid);
				} 
			
				if (go.transform.position.y == 0) {					
						if (ballGrid == null || ballGrid != go) {	
								iTween.ColorTo (go, Color.green, 0.2f);
								iTween.MoveTo (go, new Vector3 (go.transform.position.x, 0.5f, go.transform.position.z), 0.2f);		
								preGrid = go;
						}
				}
		}

		void setGridDisable (GameObject go)
		{
				iTween.ColorTo (go, Color.red, 0.01f);
				if (go.transform.position.y != 0) {
						iTween.MoveTo (go, new Vector3 (go.transform.position.x, 0f, go.transform.position.z), 0.2f);		
				}
		}

		void moveToPoint ()
		{	
				if (pointIndex < 2) {
						iTween.MoveTo (ball, iTween.Hash ("position", pathPoints [pointIndex], "speed", 10f, "easetype", "linear", "oncomplete", "moveToPoint", "oncompletetarget", this.gameObject));					
						pointIndex++;		
				}
		}

		// Update is called once per frame
		void Update ()
		{
				Ray ray = camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
						if (hit.transform.tag == "grid") {	

								gridUp (hit.transform.gameObject);	
	
								if (Input.GetMouseButtonDown (0)) {

										if (ballGrid != null) {
												gridStateBack (ballGrid);
										}
						
										pointIndex = 0;
										pathPoints [0] = new Vector3 (hit.transform.position.x, ball.transform.position.y, ball.transform.position.z);
										pathPoints [1] = new Vector3 (hit.transform.position.x, ball.transform.position.y, hit.transform.position.z);
										moveToPoint ();
										ballGrid = hit.transform.gameObject;	
										setGridDisable (ballGrid);
								}											
						}
				} else {
						if (preGrid != null) {
								gridStateBack (preGrid);
						}		
				}
		}
}
