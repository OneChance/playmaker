using UnityEngine;
using System.Collections;

public static class RendererEx{
	public static bool isCamVisible(this Renderer renderer,Camera cam){
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes (cam);
		return GeometryUtility.TestPlanesAABB (planes, renderer.bounds);
	}

}
