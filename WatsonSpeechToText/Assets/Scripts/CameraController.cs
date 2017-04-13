using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
	GameObject cube;
	GameObject ball;
	public Vector3 posOffset;
	public Vector3 rotOffset;

	void Start (){
		cube = GameObject.Find ("Cube");
		ball = GameObject.Find ("Ball");
		posOffset = new Vector3(0,3,-5);
		rotOffset = new Vector3 (10, 0, 0);
	}

	void LateUpdate (){
		if (cube.activeInHierarchy) {
			transform.position = cube.transform.position + posOffset;
			transform.rotation = Quaternion.Euler(rotOffset);
		}

		if (ball.activeInHierarchy) {
			transform.position = ball.transform.position + posOffset;
		}
	}
}
