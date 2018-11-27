using UnityEngine;
using System.Collections;

public class ControleDaCamera : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	private Transform transformCamera;
	private Vector3 positionCamera;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		transformCamera = GetComponent<Transform> ();
		positionCamera = transformCamera.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > 0.0f) {
			positionCamera.y = player.transform.position.y + offset.y;			
		} else {
			positionCamera.y = 0.0f + offset.y;
		}

		transformCamera.position = positionCamera;

	}
		
}
