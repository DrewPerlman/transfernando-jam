using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlipper : MonoBehaviour {

	public GameObject lightbulb;
	public GameObject fireLantern;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find(fireLantern.name)){
			lightbulb.SetActive(false);
		} else{
			lightbulb.SetActive(true);
		}
	}
}
