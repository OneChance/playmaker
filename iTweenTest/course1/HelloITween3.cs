using UnityEngine;
using System.Collections;

public class HelloITween3 : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
			if(Input.GetMouseButtonDown(0))
				iTween.MoveTo (this.gameObject, iTween.Hash("x",3,"time",2,"delay",1,"looptype",iTween.LoopType.pingPong));
		}
}
