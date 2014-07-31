using UnityEngine;
using System.Collections;

public class moveSight : MonoBehaviour
{

		public GameObject target;
		private Vector3[] paths = new Vector3[3];
		public GameObject ball;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				Ray ray = camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
						if (hit.transform.gameObject.tag == "grid") {
								iTween.MoveUpdate (target, new Vector3 (hit.point.x, target.transform.position.y, hit.point.z), .1f);
								if (Input.GetMouseButtonDown (0)) {
										GameObject oneBall = (GameObject)Instantiate (ball, new Vector3 (0, 0, 0), Quaternion.identity);
										paths [0] = new Vector3 (0, 0, 0);
										paths [2] = hit.point;
										paths [1] = new Vector3 (paths [1].x / 2, 3, paths [2].z / 2);
										iTween.MoveTo (oneBall, iTween.Hash ("path", paths, "movetopath", true, "orienttopath", true, "time", 1, "easetype", iTween.EaseType.linear));
										Destroy (oneBall, 2f);				
								}			
						}		
				}
		}
}
