using UnityEngine;
using System.Collections;

public class ParticalScript : MonoBehaviour
{

		public static ParticalScript instance;
		public ParticleSystem smokeEffect;
		public ParticleSystem fireEffect;

		void Awake ()
		{
				if (instance == null) {
						instance = this;		
				}
		}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void Explosion (Vector3 position)
		{
				createPS (smokeEffect, position);
				createPS (fireEffect, position);
		}

		private ParticleSystem createPS (ParticleSystem prefab, Vector3 position)
		{
				ParticleSystem ps = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
				Destroy (ps.gameObject, ps.startLifetime);
				return ps;
		}
}
