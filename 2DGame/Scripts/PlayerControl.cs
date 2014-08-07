using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

		public Vector2 speed = new Vector2 (15, 15);
		private Vector3 movement;
		private WeaponScript weapon;

		// Use this for initialization
		void Start ()
		{
				weapon = GetComponent<WeaponScript> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				float inputX = Input.GetAxis ("Horizontal");
				float inputY = Input.GetAxis ("Vertical");

				movement = new Vector3 (inputX * speed.x, inputY * speed.y, 0);
//		movement *= Time.deltaTime;
//		transform.Translate (movement);

				bool shoot = Input.GetButtonDown ("Fire1");

				if (shoot && weapon != null) {
						weapon.Attack (false);
				}

		}

		void FixedUpdate ()
		{
				rigidbody2D.velocity = movement;
		}
}
