using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour {
	GameObject world;
	public Text transcript;

	void Start(){
		world = GameObject.Find ("Plane");
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {
			Debug.Log ("YOU WON!");
			world.SetActive (false);
			transcript.fontSize = 20;
			transcript.rectTransform.localPosition = new Vector3(20,60,0);
			transcript.color = Color.green;
			transcript.text = "You completed!";
		}
	}
}
