using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WispState { WHITE, FIRE, WATER, ELECTRIC ,desFIRE};

public class WispTriggers : MonoBehaviour {
    //white, fire, electric, water 
    public WispState curState;
    
    private SpriteRenderer wispCenter;
    private SpriteRenderer wispAura;
    private Animator anim;

    Color m_NewColor;

    // Use this for initialization
    void Start ()
    {
        curState = WispState.WHITE;
        Cursor.visible = false;
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
        if(Input.GetMouseButton(0))
            curState = WispState.WHITE;
        if (curState == WispState.WHITE)
        {
            wispAura.color = Color.white;
            anim.SetBool("Fire", false);
            anim.SetBool("Electricity", false);
        }
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y), Vector2.zero, 0);
        if(hit)
        {
        }
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
                anim.SetBool("Electricity", false);
                anim.SetBool("Fire", true);
                break;
            case "srcElectric":
                curState = WispState.ELECTRIC;
                wispAura.color = Color.cyan;
                anim.SetBool("Electricity", true);
                anim.SetBool("Fire", false);
                break;
            case "srcWater":
                curState = WispState.WATER;
                wispAura.color = Color.blue;
                break;
            case "destFire":
                if (curState == WispState.FIRE)
                {
                    Destroy(other.gameObject);
                    Debug.Log("destroy");
                    curState = WispState.WHITE;
                }
                break;
            case "destWater":
                if (curState == WispState.WATER)
                {
                    Debug.Log("destroy");
                    Destroy(other.gameObject);
                    curState = WispState.ELECTRIC;
                }
                break;
            case "destElectic":
                if (curState == WispState.WATER)
                {
                    Debug.Log("destroy");
                    Destroy(other.gameObject);
                    curState = WispState.ELECTRIC;
                }
                break;
                //add more test cases here
        }

    }
}
