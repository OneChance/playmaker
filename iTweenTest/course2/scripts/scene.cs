using UnityEngine;
using System.Collections;

public class scene : MonoBehaviour
{

		private int size = 9;
		public GameObject grid;

		// Use this for initialization
		void Start ()
		{
				createPlane ();
		}

		void createPlane ()
		{
				for (int i=0; i<size; i++) {
						for (int j=0; j<size; j++) {
								Instantiate (grid, new Vector3 (i, 0, j), Quaternion.identity);
						}
				}	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
