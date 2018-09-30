using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxChecker : MonoBehaviour {

	public GameObject box1;
	public GameObject box2;
	public GameObject door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


		if(box1.GetComponent<BoxCollider2D>().enabled == false && box2.GetComponent<BoxCollider2D>().enabled == false){
			door.GetComponent<DoorSideBehavior>().doorOpen = true;
		}
	}
}
