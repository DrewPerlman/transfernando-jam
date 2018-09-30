using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WispState { WHITE, FIRE, WATER, ELECTRIC };

public class WispTriggers : MonoBehaviour {
    //white, fire, electric, water 
    public WispState curState;
    
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
            if(sr.tag == "wispAura")
                wispAura = sr;
        }
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update ()
    {
        if(Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("Dest"));
			if (hit.collider != null)
			{
				Debug.Log(hit.collider.gameObject.name);
				print("HERE2");
				if (curState == WispState.FIRE && hit.collider.CompareTag("destFire"))
				{
					print("HERE");
					hit.collider.gameObject.GetComponent<Box>().BurnBox();
				}
				else if (curState == WispState.ELECTRIC)
				{

				}
			}
			curState = WispState.WHITE;
		}

		if (curState == WispState.WHITE)
        {
            wispAura.color = Color.white;
            anim.SetBool("Fire", false);
            anim.SetBool("Electricity", false);
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
			/*case "srcWater":
                curState = WispState.WATER;
                wispAura.color = Color.blue;
                break;*/
			/*case "destWater":
                if (curState == WispState.WATER)
                {
                    Debug.Log("destroy");
                    Destroy(other.gameObject);
                    curState = WispState.ELECTRIC;
                }
                break;*/
			/*case "destFire":
				if (curState == WispState.FIRE)
				{
					curState = WispState.WHITE;
					other.GetComponent<Box>().BurnBox();
				}
				break;*/
			case "destElectric":
                if (curState == WispState.ELECTRIC)
                {
                    curState = WispState.ELECTRIC;
                }
                break;
                //add more test cases here
			case "destCandle":
				if (curState == WispState.FIRE)
				{
					other.GetComponent<Candle>().TryActivate();
				}
				break;
        }

    }
}
