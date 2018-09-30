using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WispState { WHITE, FIRE, WATER, ELECTRIC };

public class WispTriggers : MonoBehaviour {
    //white, fire, electric, water 
    public WispState curState;
    
    private SpriteRenderer wispAura;
    private Animator anim;
    private CircleCollider2D circ;
    private bool test = true;
    public bool fireHandler = false;

    Color m_NewColor;

    //for sound
    public GameObject toFireSound;
    public GameObject toElectricSound;
    public GameObject fireOutSound;

    // Use this for initialization
    void Start ()
    {
        circ = GetComponent<CircleCollider2D>();
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

    //void OnCollisionStay(Collision2D collision)
    //{
    //    Debug.Log(Input.GetAxis("Mouse Y"));
    //    Vector3 pos = transform.position;
    //    if (circ.enabled)
    //    {
    //        if (Input.GetAxis("Mouse Y") < 50)
    //            pos.y = 50;
    //    }
    //}

    // Update is called once per frame
    void Update ()
    {
        if(curState == WispState.FIRE)
            circ.enabled = true;
        else
            circ.enabled = false;

        if (circ.enabled && test && fireHandler)
        {
            //catches on fire, cannot go to the bottom of the screen
            Debug.Log(Input.GetAxis("Mouse Y"));
            Vector3 pos = transform.localPosition;
            if (pos.y<= 0.15f)
                pos.y = 0.2f;
            transform.localPosition = pos;
        }


        if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("Dest"));
			if (hit.collider != null)
			{
				//Debug.Log(hit.collider.gameObject.name);
				if (curState == WispState.FIRE && hit.collider.CompareTag("destFire"))
				{
					hit.collider.gameObject.GetComponent<Box>().BurnBox();
				}
				else if (curState == WispState.ELECTRIC && hit.collider.CompareTag("destElectric"))
				{
                    hit.collider.gameObject.GetComponent<Fuseboc>().flipping = ! hit.collider.gameObject.GetComponent<Fuseboc>().flipping;
				}
				else if (curState == WispState.FIRE && hit.collider.CompareTag("destCandle"))
				{
					hit.collider.gameObject.GetComponent<Candle>().TryActivate();
				}
			}
			SetWispStateToWhite();
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
                if(curState != WispState.FIRE)
                {
                   GameObject instanceSound = Instantiate(toFireSound, transform.position, Quaternion.identity);
                   Destroy(instanceSound, 3.0f);
                }
                curState = WispState.FIRE;
                wispAura.color = Color.yellow;
                anim.SetBool("Electricity", false);
                anim.SetBool("Fire", true);
				//wispAura.enabled = false;
				if (FindObjectOfType<SpriteMask>())
				{
					FindObjectOfType<SpriteMask>().enabled = false;
				}
                break;
            case "srcElectric":
                if (curState != WispState.ELECTRIC)
                {
                    GameObject instanceSound = Instantiate(toElectricSound, transform.position, Quaternion.identity);
                    Destroy(instanceSound, 3.0f);
                }
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
			case "destFire":
				if (curState == WispState.FIRE)
				{
                    
                    GameObject instanceSound = Instantiate(fireOutSound, transform.position, Quaternion.identity);
                    
                    curState = WispState.WHITE;
					other.GetComponent<Box>().BurnBox();
                    SetWispStateToWhite();
				}
				break;
			case "destElectric":
                if (curState == WispState.ELECTRIC)
                {
                    other.gameObject.GetComponent<Fuseboc>().flipping=true;
                    SetWispStateToWhite();
                    test = false;
                }
                break;
                //add more test cases here
			/*case "destCandle":
				if (curState == WispState.FIRE)
				{
					other.GetComponent<Candle>().TryActivate();
				}
				break;*/
        }
    }
	void SetWispStateToWhite()
	{
		curState = WispState.WHITE;
		wispAura.color = Color.white;
		anim.SetBool("Fire", false);
		anim.SetBool("Electricity", false);
		wispAura.enabled = true;
		if (FindObjectOfType<SpriteMask>())
			FindObjectOfType<SpriteMask>().enabled = true;
	}
}
