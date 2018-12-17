using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecam : MonoBehaviour {

	// Use this for initialization
	public Transform lookAt;
	public Vector3 startOffset;
	public Vector3 camera;
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag("Player").transform;
		startOffset = transform.position - lookAt.position;
		// startOffset.y = 0;
		// startOffset.x = 0;

	}

	// Update is called once per frame
	void Update () {
        // GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, movechar.forwardVel + GM.difficulty);
			camera.x = transform.position.x;
			camera.y = transform.position.y;
			camera.z = lookAt.position.z + startOffset.z ;
			transform.position = camera;
		}

}
