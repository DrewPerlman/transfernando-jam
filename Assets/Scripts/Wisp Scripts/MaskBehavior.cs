using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehavior : MonoBehaviour {

    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("wispAura").transform;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = target.position;
        gameObject.transform.localScale = target.GetComponent<WispAuraScale>().auraScale*5f;
	}
}
