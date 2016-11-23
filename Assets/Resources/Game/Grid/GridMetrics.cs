using UnityEngine;
using System.Collections;

public static class GridMetrics {

	public const float outerRadius = 1.4142135623731f/2f; //innerRadius * SQRT(2)
	public const float innerRadius = 1f/2f;
	public static Vector3[] points = {
		new Vector3(0f, 0f, innerRadius), //N
		new Vector3(innerRadius, 0f, innerRadius), //NE
		new Vector3(innerRadius, 0f, 0f), //E
		new Vector3(innerRadius, 0f, -innerRadius), //SE
		new Vector3(0f, 0f, -innerRadius), //S
		new Vector3(-innerRadius, 0f, -innerRadius), //SW
		new Vector3(-innerRadius, 0f, 0f), //W
		new Vector3(-innerRadius, 0f, innerRadius) //NW
	};
	public static Vector3 GetPoint(GridDirection direction){
		return points [(int)direction];
	}
}
