using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuseboc : MonoBehaviour {

	public GameObject flipper;
	public bool flipping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(flipping){
				flipper.SetActive(true);
			} else{
				flipper.SetActive(false);
			}
	}
}
