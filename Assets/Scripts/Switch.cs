using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    
    private SpriteRenderer button;

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

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Pressed button");
        
        if (collision.gameObject.tag == "Player")
        {

            button.transform.Translate(0, -0.3f, 0);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("out of button");
        if (collision.gameObject.tag == "Player")
        {
            button.transform.Translate(0, 0.3f, 0);
        }
    }


}
