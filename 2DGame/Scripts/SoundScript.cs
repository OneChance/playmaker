using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour
{

		public static SoundScript instance;
		public AudioClip explosion;
		public AudioClip shot_player;
		public AudioClip shot_enemy;

		void Awake ()
		{
				if (instance == null) {
						instance = this;
				}
		}

		public void ExplosionSound ()
		{
				PlaySound (explosion);
		}

		public void ShotSound (bool isEnemy)
		{
				if (isEnemy) {
						PlaySound (shot_enemy);
				} else {
						PlaySound (shot_player);
				}
				
		}

		private void PlaySound (AudioClip audio)
		{
				AudioSource.PlayClipAtPoint (audio, Vector3.zero);
		}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
