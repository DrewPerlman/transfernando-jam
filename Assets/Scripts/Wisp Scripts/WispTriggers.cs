using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WispState { WHITE, FIRE, WATER, ELECTRIC };

public class WispTriggers : MonoBehaviour {
    //white, fire, electric, water 
    public WispState curState;
    
    private SpriteRenderer wispCenter;
    private SpriteRenderer wispAura;
    private Animator anim;

    Color m_NewColor;

    // Use this for initialization
    void Start () {
        curState = WispState.WHITE;
        //Set the GameObjects's Color quickly to a set Color(blue)
        SpriteRenderer[] child_sprite = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in child_sprite)
        {
            if(sr.tag == "wispCenter")
                wispCenter = sr;
            else if(sr.tag == "wispAura")
                wispAura = sr;
        }
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (curState == WispState.FIRE)
            anim.SetBool("Fire", true);
        else if (curState == WispState.WHITE)
            anim.SetBool("Fire", false);

        //else if (curState == WispState.WATER)
        //    anim.SetBool("Water", true);
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
                wispAura.color = Color.yellow;
                break;
            case "srcElectric":
                curState = WispState.ELECTRIC;
                wispAura.color = Color.cyan;
                break;
            case "srcWater":
                curState = WispState.WATER;
                wispAura.color = Color.blue;
                break;
            case "destFire":
                if (curState == WispState.FIRE)
                {
                    Debug.Log("destroy");
                    Destroy(other.gameObject);
                    curState = WispState.WHITE;
                }
                break;
            case "destWater":
                if (curState == WispState.WATER)
                {
                    Debug.Log("destroy");
                    Destroy(other.gameObject);
                    curState = WispState.WHITE;
                }
                break;
            //add more test cases here
        }

    }
}
