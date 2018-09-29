using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WispController : MonoBehaviour {

    public Transform cursor;
    public float moveSpeed = 0.05f;
    private bool facingLeft = true;
    Animator anim;
	// Use this for initialization
	void Start ()
    {
		
	}
    
    // Update is called once per frame
    void Update () {
        FollowCursor();
        float x = Input.mousePosition.x;
        float halfOfScreen = Screen.width / 2;
        if (x > halfOfScreen && facingLeft)
            Flip();
        else if (x < halfOfScreen && !facingLeft)
            Flip();
    }


    void FollowCursor()
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0.0f;
        transform.position = Vector3.Lerp(transform.position, mouseWorld, moveSpeed);
    }

    void Flip()
    {
        facingLeft= !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
