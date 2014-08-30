using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BgScroll : MonoBehaviour
{

		private List<Transform> backgrounds;

		// Use this for initialization
		void Start ()
		{
				
				//将两个背景图加入LIST，用于滚动播放
				backgrounds = new List<Transform> ();
		
				for (int i=0; i<transform.childCount; i++) {
			
						Transform t = transform.GetChild (i);
			
						if (t.renderer != null) {
								backgrounds.Add (transform.GetChild (i));	
						}
				}
				
				//按X轴位置排序
				backgrounds = backgrounds.OrderBy (one => one.position.x).ToList ();
		}

			
	
		// Update is called once per frame
		void Update ()
		{
				Transform first = backgrounds.FirstOrDefault ();
				if (first != null) {
						//当背景位置小于相机位置
						if (first.position.x < Camera.main.transform.position.x) {
								//当背景不再存在于相机渲染范围之内
								if (!first.renderer.isCamVisible (Camera.main)) {
										//移动到List尾部
										Transform last = backgrounds.LastOrDefault ();

										float lastSize = (last.renderer.bounds.max - last.renderer.bounds.min).x;
										float firstSize = (first.renderer.bounds.max - first.renderer.bounds.min).x; 
										first.position = new Vector3 (last.position.x + (lastSize / 2 + firstSize / 2), first.position.y, first.position.z);
										backgrounds.Remove (first);
										backgrounds.Add (first);
								}
						}
				}
		}
}
