using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

		private WeaponScript weapon;	

		// Use this for initialization
		void Awake ()
		{
				weapon = GetComponent<WeaponScript> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (weapon != null) {
						weapon.Attack (true);		
				}
		}
}
