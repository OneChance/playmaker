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
	
		// Update is called once per frame
		void Update ()
		{
				if (weapons != null) {
						for (int i=0; i<=weapons.GetUpperBound(0); i++) {
								weapons [i].Attack (true);
						}							
				}
		}
}
