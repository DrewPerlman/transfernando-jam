using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMovement : MonoBehaviour  {

    public float maxSpeed = 10.0f;
    public bool facingRight = true;
    Rigidbody2D rb;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    private void Update()
    {
        //Delte this and test it
        if (!Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
            anim.SetFloat("Speed", 0.0f);
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
