using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

		public Vector2 speed = new Vector2 (15, 15);
		private Vector3 movement;
		private WeaponScript weapon;
		private Transform trans;
		private Vector3 mousePoint;

		// Use this for initialization
		void Start ()
		{
				weapon = GetComponentInChildren<WeaponScript> ();
				trans = transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Debug.Log ("update");	
				float inputX = Input.GetAxis ("Horizontal");
				float inputY = Input.GetAxis ("Vertical");

				movement = new Vector3 (inputX * speed.x, inputY * speed.y, 0);
				//		movement *= Time.deltaTime;
				//		transform.Translate (movement);

				bool shoot = Input.GetButtonDown ("Fire1");

				if (shoot && weapon != null) {
						weapon.Attack (false);
				}

				//鼠标控制-------------------------------------------------------------
				mousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);

				Vector3 pos = trans.position;
				pos = Vector3.Lerp (pos, mousePoint, 1f);
				pos.z = trans.position.z;
				trans.position = pos;
	
		}

		void LateUpdate ()
		{			
				//Debug.Log ("late");	
				moveRestrict ();
		}

		void FixedUpdate ()
		{
				//Debug.Log ("fixed");	
				//键盘控制-------------------------------------------------------------
				rigidbody2D.velocity = movement;
		}

		void OnCollisionEnter2D (Collision2D collison)
		{
				
				HealthScript enemy = collison.gameObject.GetComponent<HealthScript> ();

				if (enemy != null) {

						int enemyHp = enemy.hp;
						
						if (collison.gameObject.GetComponent<BossScript> () == null) {
								enemy.OnDamage (enemyHp);
						}

						HealthScript playerHealth = GetComponent<HealthScript> ();

						playerHealth.OnDamage (enemyHp);	
				}
		}

		void moveRestrict ()
		{
				float dist = transform.position.z - Camera.main.transform.position.z;
				float left = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
				float right = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
				float bottom = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
				float top = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;

				trans.position = new Vector3 (Mathf.Clamp (trans.position.x, left, right), Mathf.Clamp (trans.position.y, bottom, top), trans.position.z);
		}

		void OnDestroy ()
		{
				EnemyManager.isGameOver = true;	
				if (GameObject.Find ("GUI") != null) {
						GameObject.Find ("GUI").AddComponent<GameOver> ();
				}
		}
}
