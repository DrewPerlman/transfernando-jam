using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAuraScale : MonoBehaviour {

    public float radius = 128f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            radius += 0.01f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            radius -= 0.01f;
        }


        Vector3 auraScale = transform.localScale;
        auraScale.x = radius * 2;
        auraScale.y = radius * 2;
        transform.localScale = auraScale;

    }
}
