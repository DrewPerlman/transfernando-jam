using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScr : MonoBehaviour {

	float vol = 0f;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(vol < 1f){
			vol += Time.deltaTime/3f;
			GetComponent<AudioSource>().volume = vol;
		}
	}
}
