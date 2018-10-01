using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDimr : MonoBehaviour {

		public GameObject musicObj; 
		public bool active = true;

	// Use this for initialization
	void Start () {
		musicObj = GameObject.Find("MusicManager");
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
		musicObj.GetComponent<AudioSource>().volume -= (Time.deltaTime)/3f;
	}
	}
}
