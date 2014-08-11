using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScreenScroll : MonoBehaviour
{

		public Vector2 speed = new Vector2 (2, 2);
		public Vector2 direction = new Vector2 (-1, 0);
		public bool linkedToCamera = false;
		public bool isLoop = false;
		private List<Transform> backgrounds;
		public int offset = 0;

		// Use this for initialization
		void Start ()
		{
				if (isLoop) {
						backgrounds = new List<Transform> ();

						for (int i=0; i<transform.childCount; i++) {

								Transform t = transform.GetChild (i);

								if (t.renderer != null) {
										backgrounds.Add (transform.GetChild (i));	
								}
						}

						backgrounds = backgrounds.OrderBy (one => one.position.x).ToList ();	
				}
		}

			
	
		// Update is called once per frame
		void Update ()
		{
				Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
				movement *= Time.deltaTime;
				transform.Translate (movement);
				if (linkedToCamera) {
						Camera.main.transform.Translate (movement);		
				}
				if (isLoop) {
	
						Transform first = backgrounds.FirstOrDefault ();
						if (first != null) {

								if (first.position.x < Camera.main.transform.position.x) {
										if (!first.renderer.isCamVisible (Camera.main)) {

												//move to tail
												Transform last = backgrounds.LastOrDefault ();

												float lastSize = (last.renderer.bounds.max - last.renderer.bounds.min).x;
												float firstSize = (first.renderer.bounds.max - first.renderer.bounds.min).x; 
												first.position = new Vector3 (last.position.x + (lastSize / 2 + firstSize / 2) + offset, first.position.y, first.position.z);
												backgrounds.Remove (first);
												backgrounds.Add (first);
										}
								}
						}
				}
		}
}
