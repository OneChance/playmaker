using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{

		private Animator animator;
		private AutoMoveScripts moveScript;
		private Vector2 dest;
		private WeaponScript[] weapons;
		private float minAttackCooldown = 0.5f;
		private float maxAttackCooldown = 2.0f;
		private float attackCooldown;
		private bool attacking;
		public Transform body;

		void Awake ()
		{
				animator = GetComponent<Animator> ();
				moveScript = GetComponent<AutoMoveScripts> ();
				dest = Vector2.zero;
				weapons = GetComponentsInChildren<WeaponScript> ();
		}

		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (body.renderer.isCamVisible (Camera.main)) {
						attackCooldown -= Time.deltaTime;

						if (attackCooldown <= 0) {
								attacking = !attacking;
								attackCooldown = Random.Range (minAttackCooldown, maxAttackCooldown);
								animator.SetBool ("Attack", attacking);
						}


						if (attacking) {
								moveScript.direction = Vector2.zero;
								Attack ();
						} else {
								Move ();
						}
				}
		}

		void Move ()
		{
				if (dest == Vector2.zero) {
						Vector2 randomPos = new Vector2 (Random.Range (0f, 1f), Random.Range (0f, 1f));
						dest = Camera.main.ViewportToWorldPoint (randomPos);
				}
				if (collider2D.OverlapPoint (dest)) { //生成的随机点被当前boss位置覆盖,无效
						dest = Vector2.zero;
				}
				Vector2 direction = dest - (Vector2)transform.position;
				moveScript.direction = direction.normalized;
		}

		void Attack ()
		{
				if (weapons != null) {
						for (int i=0; i<=weapons.GetUpperBound(0); i++) {
								weapons [i].Attack (true);
						}							
				}
		}
}
