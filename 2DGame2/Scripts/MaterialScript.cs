using UnityEngine;
using System.Collections;

public class MaterialScript : MonoBehaviour
{

		public int col = 5;
		public int row = 3;
		public float colOffset = 0;
		public float rowOffset = 0;
		public int pos = 0;

		// Use this for initialization
		void Start ()
		{
				setMaterial ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		[ContextMenu("setMaterial")]
		public void setMaterial ()
		{
				float offsetX = (pos % col * 1f) / col;
				float offsetY = 1f - (pos / col + 1f) / row;

				float tilingX = 1f / col;
				float tilingY = 1f / row;

				renderer.sharedMaterial.SetTextureScale ("_MainTex", new Vector2 (tilingX, tilingY));
				renderer.sharedMaterial.SetTextureOffset ("_MainTex", new Vector2 (offsetX, offsetY));
		}
}
