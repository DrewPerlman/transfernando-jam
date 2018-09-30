using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WispState { WHITE, FIRE, WATER, ELECTRIC };

public class WispTriggers : MonoBehaviour {
    //white, fire, electric, water 
    public WispState curState;
    Color m_NewColor;
    private SpriteRenderer wispCenter;
    private SpriteRenderer wispAura;

	// Use this for initialization
	void Start () {
        curState = WispState.WHITE;
        //Set the GameObjects's Color quickly to a set Color(blue)
        SpriteRenderer[] child_sprite = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in child_sprite)
        {
            if(sr.tag == "wispCenter")
            {
                wispCenter = sr;
            }
            else if(sr.tag == "wispAura")
            {
                wispAura = sr;
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
        //if colliding with the candle
        switch (other.tag)
        {
            case "srcFire":
                curState = WispState.FIRE;
                wispCenter.color = Color.red;
                wispAura.color = Color.red;
                break;
            case "srcElectric":
                curState = WispState.ELECTRIC;
                wispCenter.color = Color.cyan;
                wispAura.color = Color.cyan;
                break;
            case "srcWater":
                curState = WispState.WATER;
                wispCenter.color = Color.blue;
                wispAura.color = Color.blue;
                break;
            case "destFire":
                if (curState == WispState.FIRE)
                {
                    Debug.Log("destroy");
                    Destroy(other.gameObject);
                }
                break;
			case "destCandle":
				if (curState == WispState.FIRE)
				{
					other.GetComponent<Candle>().TryActivate();
				}
				break;
            //add more test cases here
        }

    }
}
