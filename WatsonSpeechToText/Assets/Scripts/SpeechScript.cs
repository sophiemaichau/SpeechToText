﻿using IBM.Watson.DeveloperCloud.DataTypes;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using UnityEngine;
using UnityEngine.UI;
using IBM.Watson.DeveloperCloud.Widgets;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class SpeechScript : MonoBehaviour {

	public string inputString;
	public SpeechToTextWidget m_SpeechToTextWidget;
	float rotationSpeed = 30f;
	float height = 0.05f;
	float walkSpeed = 0.0008f;
	float jumpSpeed = 7f;

	GameObject ball;
	GameObject cube;
	public static GameObject obj;
	Rigidbody rb;

	List<string> createList = new List<string>() {"cube+?", "ball+?", "plane+?", "floor+?", "playground+", "blue", "yellow", "green", "red"};
	List<string> commandoList = new List<string> () {"jump", "left", "right", "rotate", "forward", "back"};
	List<string> lastCommand = new List<string> () {"", ""};

	void Start(){
		ball = GameObject.Find ("Ball");
		cube = GameObject.Find ("Cube");
		ball.SetActive (false);
		cube.SetActive (false);
		this.gameObject.GetComponent<Renderer> ().enabled = false;
	}

	void Update(){
		//inputString = m_SpeechToTextWidget.outputString;
		if (inputString != null){
			//Debug.Log (inputString);
			createWorld ();
		}

		// this list has always length 2 
		if (lastCommand.Count > 2) {
			lastCommand.RemoveRange (0, lastCommand.Count-2);
		}
	}

	void createWorld(){
		foreach (string commando in createList) {
			if (new Regex (commando, RegexOptions.IgnoreCase).Match (inputString).Success) {
				lastCommand.Add (commando);

				if (commando.Equals ("plane+?") || commando.Equals ("floor+?"))
					this.gameObject.GetComponent<Renderer> ().enabled = true;

				if (commando.Equals ("ball+?")) {
					ball.SetActive (true);
					cube.SetActive (false);
					obj = ball;
					rb = ball.GetComponent<Rigidbody> ();
				}

				if (commando.Equals ("cube+?")) {
					ball.SetActive (false);
					cube.SetActive (true);
					obj = cube;
					rb = cube.GetComponent<Rigidbody> ();
				}

				if (commando.Equals ("blue"))
					obj.GetComponent<Renderer> ().material.color = Color.blue;

				if(commando.Equals("yellow"))
					obj.GetComponent<Renderer> ().material.color = Color.yellow;

				if(commando.Equals("green"))
					obj.GetComponent<Renderer> ().material.color = Color.green;
				
				if(commando.Equals("red"))
					obj.GetComponent<Renderer> ().material.color = Color.red;
			}
		}
		playerMove ();
	}

	void playerMove(){

		foreach(string commando in commandoList){
			if (new Regex(commando, RegexOptions.IgnoreCase).Match(inputString).Success) {
				lastCommand.Add (commando);

				if (commando.Equals ("rotate"))
					obj.transform.rotation = Quaternion.Euler(new Vector3(0, rotationSpeed * Time.time, 0));

				if (commando.Equals ("left"))
					obj.transform.position -= new Vector3 (walkSpeed * Time.time, 0, 0);

				if (commando.Equals ("right"))
					obj.transform.position += new Vector3 (walkSpeed * Time.time, 0, 0);

				if (commando.Equals ("forward"))
					obj.transform.position += new Vector3 (0, 0, walkSpeed * Time.time);

				if (commando.Equals ("back"))
					obj.transform.position -= new Vector3 (0, 0, walkSpeed * Time.time);

				if (commando.Equals ("jump") && !lastCommand [lastCommand.Count - 2].Equals ("jump")) {
					rb.velocity += new Vector3(0, jumpSpeed, 0);
					if (obj.transform.position.y > 0.25f){
						// stop adding speed on the y-axis
					}
				}
			}
		}
	}
}