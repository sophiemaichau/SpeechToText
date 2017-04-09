using IBM.Watson.DeveloperCloud.DataTypes;
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
	float height = 0.5f;
	float walkSpeed = 0.0008f;
	float jumpSpeed = 90f;

	GameObject ball;
	GameObject cube;
	GameObject obj;

	List<string> commandoList = new List<string>() {"okay", "blue", "yellow", "green", "jump", "left", "right", "rotate",
		"forward", "back", "cube+?", "ball+?", "plane+?", "floor+="};

	void Start(){
		inputString = m_SpeechToTextWidget.outputString;
		ball = GameObject.Find ("Ball");
		cube = GameObject.Find ("Cube");
		ball.SetActive (false);
		cube.SetActive (false);
		this.gameObject.GetComponent<Renderer> ().enabled = false;
	}

	void Update(){
		inputString = m_SpeechToTextWidget.outputString;
		if (inputString != null){
			Debug.Log (inputString);
			foreach(string commando in commandoList){
				// if the commando is a part of the phrase
				if (new Regex(commando, RegexOptions.IgnoreCase).Match(inputString).Success) {

					if (commando.Equals ("plane+?") || commando.Equals ("floor+?"))
						this.gameObject.GetComponent<Renderer> ().enabled = true;

					if (commando.Equals ("ball+?")) {
						ball.SetActive (true);
						cube.SetActive (false);
						obj = ball;
					}

					if (commando.Equals ("cube+?")) {
						ball.SetActive (false);
						cube.SetActive (true);
						obj = cube;
					}

					if (commando.Equals ("rotate"))
						obj.transform.rotation = Quaternion.Euler(new Vector3(0, rotationSpeed * Time.time, 0));

					if(commando.Equals("blue"))
						obj.GetComponent<Renderer> ().material.color = Color.blue;

					if(commando.Equals("yellow"))
						obj.GetComponent<Renderer> ().material.color = Color.yellow;

					if(commando.Equals("green"))
						obj.GetComponent<Renderer> ().material.color = Color.green;

					if (commando.Equals ("left"))
						obj.transform.position -= new Vector3 (walkSpeed * Time.time, 0, 0);
					
					if (commando.Equals ("right"))
						obj.transform.position += new Vector3 (walkSpeed * Time.time, 0, 0);

					if (commando.Equals ("forward"))
						obj.transform.position += new Vector3 (0, 0, walkSpeed * Time.time);

					if (commando.Equals ("back"))
						obj.transform.position -= new Vector3 (0, 0, walkSpeed * Time.time);
						
				}
			}
		}
	}
}