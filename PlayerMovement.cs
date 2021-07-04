using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 7;
    public int jumpForce = 250;
    public float moveX;
    public bool isGround;
    private Animator anim;
    private Rigidbody2D rb;
    private bool mirrered;
    private AudioSource au;
    public AudioClip jumpClip;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        //กระโดด
        if (Input.GetButtonDown("Jump") && isGround==true)
        {
            Jump();
        }
        if (!isGround)
        {
            anim.SetBool("isJump",true);
        }
        //เคลื่อนที่
         if (moveX!=0 && isGround)
        {
            anim.SetBool("isRunning",true);
        }
        else
        {
            anim.SetBool("isRunning",false);
        }
        //มุมmirrired
        if (moveX < 0.0f && mirrered==false)
        {
            FlipPlayer();
        }else if (moveX > 0.0f && mirrered == true)
        {
            FlipPlayer();
        }
        rb.velocity = new Vector2(moveX*speed,gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void FlipPlayer()
    {
        mirrered = !mirrered;
        Vector2 local=gameObject.transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up*jumpForce);
        isGround = false;
        au.clip = jumpClip;
        au.Play();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="ground")
        {
            isGround = true;
            anim.SetBool("isjump", false);
        }
        if (other.gameObject.tag == "EndLevel")
        {
            Application.LoadLevel("Win");
        }
        if (other.gameObject.tag == "next1")
        {
            Application.LoadLevel("MAIN");
        }
    }
}
