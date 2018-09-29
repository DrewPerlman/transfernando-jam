using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritController : MonoBehaviour {

    public float moveSpeed = 0.05f;

	// Use this for initialization
	void Start () {
		
	}

    void FollowCursor () {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0.0f;

        transform.position = Vector3.Lerp(transform.position, mouseWorld, moveSpeed);
    }

    // Update is called once per frame
    void Update () {
        FollowCursor();
    }
}
