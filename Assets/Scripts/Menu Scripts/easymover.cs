using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class easymover : MonoBehaviour {

	public string sceneName = "";

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			SceneManager.LoadScene(sceneName);
		}
	}
}
