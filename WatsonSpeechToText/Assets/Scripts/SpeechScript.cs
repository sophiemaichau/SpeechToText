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
	float walkSpeed = 0.001f;
	float jumpSpeed = 90f;
	Rigidbody rb;
	List<string> commandoList = new List<string>() {"okay", "blue", "jump", "left", "right", "rotate", "yellow", "stop",
													"forward", "back"};

	void Start(){
		rb = GetComponent<Rigidbody> ();
		inputString = m_SpeechToTextWidget.outputString;
	}

	void Update(){
		inputString = m_SpeechToTextWidget.outputString;

		if (inputString != null){
			foreach(string commando in commandoList){
				// if the commando is a part of the phrase
				if (new Regex(commando, RegexOptions.IgnoreCase).Match(inputString).Success) {

					if (commando.Equals ("rotate"))
						transform.rotation = Quaternion.Euler(new Vector3(0, rotationSpeed * Time.time, 0));

					if (commando.Equals ("stop")) {
						transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z));
						transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
					}

					if(commando.Equals("blue"))
						GetComponent<Renderer> ().material.color = Color.blue;

					if(commando.Equals("yellow"))
						GetComponent<Renderer> ().material.color = Color.yellow;

					if (commando.Equals ("left"))
						transform.position -= new Vector3 (walkSpeed * Time.time, 0, 0);
					
					if (commando.Equals ("right"))
						transform.position += new Vector3 (walkSpeed * Time.time, 0, 0);

					if (commando.Equals ("forward"))
						transform.position += new Vector3 (0, 0, walkSpeed * Time.time);

					if (commando.Equals ("back"))
						transform.position -= new Vector3 (0, 0, walkSpeed * Time.time);
				}
			}
		}
	}
}