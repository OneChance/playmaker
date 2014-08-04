using UnityEngine;
using System.Collections;

public class SingleInstance : MonoBehaviour
{

		private static SingleInstance instance;

		public SingleInstance getInstance ()
		{
				if (instance == null) {
						instance = new GameObject ("GameManager").AddComponent<SingleInstance> ();		
				}	
				return instance;
		}

		// Use this for initialization
		void Awake ()
		{
				if (instance == null) {
						instance = this;
				} 
				DontDestroyOnLoad (gameObject);	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
