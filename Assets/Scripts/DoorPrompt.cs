using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrompt : MonoBehaviour {

    private SpriteRenderer promptWKey;

	// Use this for initialization
	void Start () {
        promptWKey = gameObject.GetComponent<SpriteRenderer>();
        promptWKey.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            promptWKey.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("exited");
            promptWKey.enabled = false;
        }
    }
}
