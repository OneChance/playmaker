
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{


		
		public GameObject leftRoot;
		public Camera camera;
		public UILabel label;
		public UIButton button;
		public GameObject ball;
		public static bool kick;
		private Animator animator;
		private bool kickable;
		private int ballPos;
		private int ballMovement;
		private float animPos = -2.5f;
		private float stopSpeed = 1.5f;
		private float ballCamDistance;
			

		// Use this for initialization
		void Start ()
		{
				animator = GameObject.FindGameObjectWithTag ("Monkey").GetComponent<Animator> ();
				kickable = true;
				ballCamDistance = camera.transform.position.x - ball.transform.position.x;
				ballPos = (int)ball.transform.position.x;
				button.gameObject.SetActive (false);
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{		

				if (Input.GetMouseButtonDown (0) && !kick) {
						

						//计算踢球时腿部的旋转角度
						var x = Mathf.Abs (ball.transform.position.x - leftRoot.transform.position.x);
						var y = Mathf.Abs (ball.transform.position.y - leftRoot.transform.position.y);

						float rotation = Mathf.Atan (y / x) * 180f / Mathf.PI;

						if (ball.transform.position.y < leftRoot.transform.position.y) {
								//90-
								rotation = 90 - rotation;
						} else {
								//90+
								rotation = 90 + rotation;
						}
					
						//设置状态为踢球
						kick = true;
						button.gameObject.SetActive (true);

						leftRoot.transform.Rotate (Vector3.forward, rotation);	

						
						//从踢球腿根部向球心发射一条射线
						Vector2 direction = (Vector2)(ball.transform.position - leftRoot.transform.position).normalized;
						
						RaycastHit2D[] hits = Physics2D.RaycastAll ((Vector2)leftRoot.transform.position, direction);
						
						//确定踢球施力点(射线触球点)
						for (int i=0; i<hits.Length; i++) {
								if (hits [i].collider.gameObject.name == "Ball") {
										ball.rigidbody2D.AddForceAtPosition (direction * 2500f, hits [i].point);
								}
						}
				}

				
				if (!kickable) {
						//当球开始上升时，设置可以播放颠球动画
						if (ball.rigidbody2D.velocity.y > 0) {
								kickable = true;
						}
				}

				//满足条件，播放颠球动画
				//1.球位置低于指定数值
				//2.球正下落
				//3.可播放颠球动画
				//4.没有踢出
				if ((ball.transform.position.y < animPos) && (ball.rigidbody2D.velocity.y < 0) && kickable && !kick) {

						kickable = false;

						if (Random.Range (0f, 1f) < 0.5f) {
								animator.SetTrigger ("LeftKick");
						} else {
								animator.SetTrigger ("RightKick");
						}
						
				}

				//相机在水平位置跟随球
				camera.transform.position = new Vector3 (ball.transform.position.x + ballCamDistance, 0, camera.transform.position.z);

				//球移动距离
				if (kick) {
						ballMovement = (int)ball.transform.position.x - ballPos;
						label.text = ballMovement + "";
				}

				//球踢出后，移动速度小于指定数值时，静止
				if (ballMovement > 50 && ball.rigidbody2D.velocity.x < stopSpeed && kick) {
						ball.rigidbody2D.velocity = new Vector2 (0, 0);
				}
		}
		
		public void Retry ()
		{
				kick = false;	
				Application.LoadLevel (0);	
		}
}