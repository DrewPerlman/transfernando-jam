using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { WHITE, FIRE, WATER, ELECTRIC };

public class WispTriggers : MonoBehaviour {


    //white, fire, electric, water 
    public State curState;
    Color m_NewColor;
    private SpriteRenderer center;
    private SpriteRenderer aura;

	// Use this for initialization
	void Start () {
        curState = State.WHITE;
        //Set the GameObjects's Color quickly to a set Color(blue)
        SpriteRenderer[] child_sprite = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in child_sprite)
        {
            if(sr.tag == "center")
            {
                Debug.Log("center");
                center = sr;
            }
            else if(sr.tag == "aura")
            {
                Debug.Log("aura");
                aura = sr;
            }
        }

	}
	// Update is called once per frame
	void Update () {
		
	}

    //for the wisp
    //other is the candle
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered" + other.tag);
        //if colliding with the candle
        switch (other.tag)
        {

            case "candle":
                curState = State.FIRE;
                center.color = Color.red;
                aura.color = Color.red;
                break;
            case "electric":
                curState = State.ELECTRIC;
                center.color = Color.cyan;
                aura.color = Color.cyan;
                break;
            case "water":
                curState = State.WATER;
                center.color = Color.blue;
                aura.color = Color.blue;
                break;
            case "flammable":
                if (curState == State.FIRE)
                {
                    Debug.Log("destroy");
                    Destroy(other.gameObject);
                }
                break;
            //add more test cases here
        }

    }
}
