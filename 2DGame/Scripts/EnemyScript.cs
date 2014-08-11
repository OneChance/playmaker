using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

		private WeaponScript[] weapons;	
		// Use this for initialization
		void Awake ()
		{
				weapons = GetComponentsInChildren<WeaponScript> ();
		}

		void Start ()
		{
				//如果敌人初始化出现的位置在相机之外，需要禁用敌人，防止没有渲染就被消灭或提前攻击
//				collider2D.enabled = false;
//				for (int i=0; i<weapons.Length; i++) {
//						weapons [i].enabled = false;		
//				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (transform.renderer.isCamVisible (Camera.main)) {

						//启用敌人脚本

						if (weapons != null) {
								for (int i=0; i<=weapons.GetUpperBound(0); i++) {
										weapons [i].Attack (true);
								}							
						}
				} else {
						if (transform.position.x < Camera.main.transform.position.x) {
								Destroy (gameObject);
						}					
				}	
		}
}
