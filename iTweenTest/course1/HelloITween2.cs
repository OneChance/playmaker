using UnityEngine;
using System.Collections;

public class HelloITween2 : MonoBehaviour
{

		Hashtable t = new Hashtable ();

		// Use this for initialization
		void Start ()
		{
				t.Add ("x", 3);
				t.Add ("time", 2);
				t.Add ("delay", 1);
				t.Add ("looptype", iTween.LoopType.pingPong);

				iTween.MoveTo (this.gameObject, t);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
