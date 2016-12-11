using System;
using UnityEngine;


[AddComponentMenu("Custom/Cameras/CameraFollow")]
public class CameraFollow : MonoBehaviour
{
	public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.
	public float zMargin = 1f; // Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
	public float zSmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndZ; // The maximum x and y coordinates the camera can have.
	public Vector2 minXAndZ; // The minimum x and y coordinates the camera can have.

	public Transform m_Player; // Reference to the player's transform.
	private float z_offset = 0;

	private void Awake()
	{
		// Setting up the reference.
		//m_Player = GameObject.FindGameObjectWithTag("Player").transform;

		//Set up offset
		z_offset = Mathf.Abs(m_Player.position.z - transform.position.z);

	}


	private float CheckXMargin(float buffer)
	{
		float toreturn = 0;
		float delta = Mathf.Abs (transform.position.x - m_Player.position.x);
		if (delta > xMargin) {
			toreturn = 1f;
		} else if (delta > xMargin * buffer) {
			toreturn = 0f;
		} else {
			toreturn = (delta - (xMargin * buffer)) / (xMargin * buffer);
		}
		return toreturn;

		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		//return Mathf.Abs(transform.position.x - m_Player.position.x) * buffer > xMargin;
	}


	private float CheckZMargin(float buffer)
	{
		float toreturn = 0;
		float delta = Mathf.Abs (transform.position.z - m_Player.position.z - m_Player.position.z);
		if (delta > zMargin) {
			toreturn = 1f;
		} else if (delta > zMargin * buffer) {
			toreturn = 0f;
		} else {
			toreturn = (delta - (zMargin * buffer)) / (zMargin * buffer);
		}
		return toreturn;
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		// return Mathf.Abs(transform.position.z - m_Player.position.z - z_offset) * buffer > zMargin;
	}


	private void Update()
	{
		TrackPlayer();
	}



	private void TrackPlayer()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetZ = transform.position.z;

		// If the player has moved beyond the x margin...
		//        if (CheckXMargin(0.5f))
		//        {
		//            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
		//            targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth*Time.deltaTime);
		//        }



		// If the player has moved beyond the y margin...
//		if (CheckZMargin(0.5f))
//		{
//			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
//			targetZ = Mathf.Lerp(transform.position.z, m_Player.position.z - z_offset, zSmooth*Time.deltaTime);
//		}

		float xSpeedAdjust = CheckXMargin (0.5f);
		targetX = Mathf.SmoothStep(transform.position.x, m_Player.position.x, xSmooth*Time.deltaTime*xSpeedAdjust);
		float zSpeedAdjust = CheckZMargin (0.5f);
		targetZ = Mathf.SmoothStep(transform.position.z, m_Player.position.z - z_offset, zSmooth*Time.deltaTime*zSpeedAdjust);



		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndZ.x, maxXAndZ.x);
		targetZ = Mathf.Clamp(targetZ, minXAndZ.y, maxXAndZ.y);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, transform.position.y, targetZ);
	}
}

