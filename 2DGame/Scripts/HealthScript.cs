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

						//当目标HP与当前HP之间的差距小于0.01时,不再缓动
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
								//子弹造成伤害
								OnDamage (shot.damage);
								//删除子弹
								Destroy (shot.gameObject);
						}	
				}
		}

		public void OnDamage (int damage)
		{
				
				hp -= damage;

				if (hp <= 0) {
						//播放爆炸粒子动画
						ParticalScript.instance.Explosion (transform.position);
						//播放爆炸声音
						SoundScript.instance.ExplosionSound ();

						//删除死亡对象	
						Destroy (gameObject);	
						//造成死亡的攻击，血条不使用缓动效果
						UpdateHpBar (false);				
				} else {
						//生命大于0的情况，血条使用缓动效果
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
