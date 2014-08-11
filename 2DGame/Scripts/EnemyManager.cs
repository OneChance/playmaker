using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{

		private List<Transform> enemyList = new List<Transform> ();
		public float generateInterval = 3; //敌人生成时间间隔
		private float pastTime = 0;
		private Camera mainCam;
		public GameObject[] enemyObjs; //敌人总类列表
		private int enemySorts; //敌人种类数
		private int offSetX = 5; //产生敌人时，距离相机水平偏移量
		private int offSetY = 2; //产生敌人时，距离相机垂直偏移量	

		public int maxNum = 4; //一次生产最大敌人数量

		private int maxDistanceY = 6; //敌人最大垂直距离
		private int minDistanceY = 2; //敌人最小垂直距离

		private int maxDistanceX = 4; //敌人最大水平距离
		private int minDistanceX = 0; //敌人最小水平距离

		public Transform enemyLayer;

		// Use this for initialization
		void Start ()
		{
				mainCam = Camera.main;
				enemySorts = enemyObjs.Length;
		}
	
		// Update is called once per frame
		void Update ()
		{
				pastTime += Time.deltaTime;
				if (pastTime > generateInterval) {
						pastTime = 0;
						//generate enemy
						GenerateEnemy ();
				}
		}

		void GenerateEnemy ()
		{
				float posX = mainCam.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x + offSetX;

				int enemyNum = (int)(Random.value * maxNum) + 1;
				
				//第一个敌人位置
				float lastPos = FirstPos (enemyNum);

				for (int i=0; i<enemyNum; i++) {				

						int enemySort = (int)(Random.value * enemySorts);
						GameObject go = enemyObjs [enemySort];
						
						GameObject goIns = Instantiate (go, new Vector3 (posX + Random.Range (minDistanceX, maxDistanceX), lastPos, enemyLayer.position.z), Quaternion.identity) as GameObject; 
						goIns.transform.parent = enemyLayer;	
					
						lastPos -= Random.Range (minDistanceY, maxDistanceY);

				}
		}
		
		//根据敌人数量,决定第一个敌人的位置
		float FirstPos (int enemyNum)
		{
				float range_min = mainCam.ViewportToWorldPoint (new Vector3 (0, 0, 0)).y + offSetY;
				float range_max = mainCam.ViewportToWorldPoint (new Vector3 (0, 1, 0)).y - offSetY;

				float height = range_max - range_min;
				
				range_min = range_min + (Mathf.Pow (2, enemyNum) - 1) / Mathf.Pow (2, enemyNum) * height;

				return Random.Range (range_min, range_max);
		}
		
}
