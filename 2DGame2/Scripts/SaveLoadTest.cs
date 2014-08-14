using UnityEngine;
using System.Collections;

public class SaveLoadTest : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
			Load ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void Save ()
		{

				Object[] msArray = Resources.FindObjectsOfTypeAll (typeof(MaterialScript));
				for (int i=0; i<msArray.Length; i++) {
						MaterialScript ms = msArray [i] as MaterialScript;
						if (ms.gameObject.activeInHierarchy) {

								//Debug.Log ("save:" + ms.transform.position.x + "   " + ms.pos);

								ES2.Save (ms.transform, "file.txt?tag=transform" + i);
								ES2.Save (ms.pos, "file.txt?tag=pos" + i);
						}
				}	
		}

		void Load ()
		{
				int i = 0;
				int pos = 0;
				while (ES2.Exists("file.txt?tag=transform"+i)) {
						GameObject quad = GameObject.CreatePrimitive (PrimitiveType.Quad);
						ES2.Load<Transform> ("file.txt?tag=transform" + i, quad.transform);
						pos = ES2.Load<int> ("file.txt?tag=pos" + i);
						Debug.Log ("load:" + quad.transform.position.x + "------------" + pos);
						i++;
				}

		}
}
