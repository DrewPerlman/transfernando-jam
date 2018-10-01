using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
	Animator burnBoxAnimator;
	public GameObject burnboxSound;

	// Use this for initialization
	void Start () {
		burnBoxAnimator = GetComponentInChildren<Animator>();
		burnBoxAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	public void BurnBox()
	{
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<BoxCollider2D>().enabled = false;
		burnBoxAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		burnBoxAnimator.SetTrigger("Burn");
		Instantiate(burnboxSound,transform.position,Quaternion.identity);
	}
}
