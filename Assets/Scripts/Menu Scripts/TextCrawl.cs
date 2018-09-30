using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextCrawl : MonoBehaviour {

	public string textToWrite = "";
	public Text textLocation;
	string truText = "";
	int index = 0;
	float maxTimer = 0.05f;
	float timer = 0.05f;

	// Use this for initialization
	void Start () {
		timer = maxTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0){
			timer -= Time.deltaTime;
		}

		if(truText != textToWrite && timer <= 0f && index <= textToWrite.Length){
			truText += textToWrite[index];
			index += 1;
			timer = maxTimer;
		}

		if(truText != textToWrite && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))){
			truText = textToWrite;
			timer = maxTimer;
		}

		if(index == textToWrite.Length){
			truText = textToWrite;
			timer = maxTimer;
			index+=1;
		}

		textLocation.text = truText;

		if(truText == textToWrite && timer <= 0f &&(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))){
			SceneManager.LoadScene("01Entrance");
		}
	}
}
