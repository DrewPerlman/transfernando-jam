﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    
    private SpriteRenderer button;
    public GameObject flipObject;
	public bool isFirePlaceSwitch;
    public float plateOffset = 0.2f;
    public GameObject firePlaceSound;
    private GameObject sound;

	// Use this for initialization
	void Start () {

        SpriteRenderer[] list = (GetComponentsInChildren<SpriteRenderer>());
        foreach(SpriteRenderer sr in list)
        {
            if(sr.tag == "button")
            {
                button = sr;
            }
        }

        flipObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Pressed button");
        
        if (collision.gameObject.tag == "Player")
        {

            button.transform.Translate(0, -plateOffset, 0);
            flipObject.SetActive(true);
			if (isFirePlaceSwitch)
			{
                sound = Instantiate(firePlaceSound, transform.position, Quaternion.identity); ;
			}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("out of button");
        if (collision.gameObject.tag == "Player")
        {
            button.transform.Translate(0, plateOffset, 0);
             flipObject.SetActive(false);
        }
        if (isFirePlaceSwitch)
        {
            Destroy(sound);
        }
    }


}
