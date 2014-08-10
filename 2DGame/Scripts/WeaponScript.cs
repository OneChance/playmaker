using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{

		public Transform shotPrefab;
		public float shotRate = 0.25f;
		private float shotCooldown;

		private bool canAttack {
				get {
						return shotCooldown <= 0;
				}
		} 

		// Use this for initialization
		void Start ()
		{
				shotCooldown = Random.Range (0, shotRate);
		}
	
		// Update is called once per frame
		void Update ()
		{
				shotCooldown -= Time.deltaTime;
		}

		public void Attack (bool isEnemy)
		{
				if (canAttack) {
						shotCooldown = shotRate;
						Transform shot = Instantiate (shotPrefab) as Transform;	
						shot.position = transform.position;
						ShotScript initS = shot.GetComponent<ShotScript> ();
						if (initS != null) {
								initS.isEnemy = isEnemy;
						}
						AutoMoveScripts initM = shot.GetComponent<AutoMoveScripts> ();
						if (initM != null) {
								initM.direction = transform.right;
						}
				}
		}
}
