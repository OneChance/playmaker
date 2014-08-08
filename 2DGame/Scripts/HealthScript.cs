using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{

		public int hp = 1;
		public bool isEnemy = true;
		public UISlider hpBar;
		private int maxHp;
		private float desHp = 1;

		// Use this for initialization
		void Start ()
		{
				maxHp = hp;
				UpdateHpBar (false);
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}

		void LateUpdate ()
		{
				if (hpBar != null && hpBar.value != desHp) {
						hpBar.value = Mathf.Lerp (hpBar.value, desHp, Time.deltaTime);
						if (Mathf.Abs (hpBar.value - desHp) < 0.01f) {
								hpBar.value = desHp;
						}
				}
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

		public void OnDamage (int damage)
		{
				
				hp -= damage;

				if (hp <= 0) {
						Destroy (gameObject);	
						UpdateHpBar (false);
				} else {
						UpdateHpBar (true);		
				}
				
		}

		void UpdateHpBar (bool needTween)
		{
				if (hpBar != null) {
						if (needTween) {
								desHp = (float)hp / maxHp;
						} else {
								hpBar.value = (float)hp / maxHp;
						}							
				}		

		}

		public void UpdateHpBarText ()
		{
				hpBar.GetComponentInChildren<UILabel> ().text = hp + "/" + maxHp;
		}
}
