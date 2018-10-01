using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehavior : MonoBehaviour {

    private Transform target;
	public bool hasFernandoed = false;
	public bool hasHugged = false;
	float scale;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("wispAura").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasFernandoed && !hasHugged)
		{
			gameObject.transform.position = target.position;
			gameObject.transform.localScale = target.GetComponent<WispAuraScale>().auraScale * 5f;
		}
		else if (hasFernandoed)
		{
			gameObject.transform.localScale = new Vector3(0, 0, 0);
		}
		else if (hasHugged)
		{
			scale += 5f * Time.deltaTime;
			gameObject.transform.position = new Vector3 (0.25f,0.85f,0);
			gameObject.transform.localScale = new Vector3(scale, scale, 0);
		}
	}
}
