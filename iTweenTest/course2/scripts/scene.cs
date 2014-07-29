using UnityEngine;
using System.Collections;

public class scene : MonoBehaviour
{

		private int size = 9;
		public GameObject grid;
		private GameObject preGrid;

		// Use this for initialization
		void Start ()
		{
				createPlane ();
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

		void gridUp (GameObject go)
		{
				
				if (preGrid != null && preGrid != go) {

						if(preGrid.transform)

						iTween.ColorTo (preGrid, Color.red, 0.5f);
						iTween.MoveTo (preGrid, new Vector3 (preGrid.transform.position.x, 0f, preGrid.transform.position.z), 0.5f);	
				} 
			

				iTween.ColorTo (go, Color.green, 0.5f);
				iTween.MoveTo (go, new Vector3 (go.transform.position.x, 0.5f, go.transform.position.z), 0.5f);

				preGrid = go;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				Ray ray = camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
						if (hit.transform.tag == "grid") {
								gridUp (hit.transform.gameObject);
						}
				}
		}
}
