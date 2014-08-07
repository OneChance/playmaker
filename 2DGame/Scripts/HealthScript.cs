using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{

		public int hp = 1;
		public bool isEnemy = true;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter2D (Collider2D collider)
		{

				ShotScript shot = collider.gameObject.GetComponent<ShotScript> ();

				if (shot != null) {
						if (shot.isEnemy != isEnemy) {
								OnDamage (shot.damage);
								Destroy (shot.gameObject);
						}	
				}
		}

		void OnDamage (int damage)
		{
				hp -= damage;
				if (hp <= 0) {
						Destroy (gameObject);	
				}
		}
}
