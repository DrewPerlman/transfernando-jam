using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuitter : MonoBehaviour {

	float maxTimer = 1.5f;
	float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!Input.GetKey(KeyCode.Escape)){
				timer = 0f;
			} else{
				timer += Time.deltaTime;
			}

		if(timer >= maxTimer){
			Application.Quit();
		}

		GetComponent<Image>().fillAmount = timer/maxTimer;
	}
}
