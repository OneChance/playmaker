using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		//播放颠球动画时，腿触球后，添加向上的力
		if (other.gameObject.tag == "Leg" && ! GameManager.kick) {
			float force = Random.Range (200f, 450f);
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.AddForce (Vector2.up * force);
			
		}
	}
}
