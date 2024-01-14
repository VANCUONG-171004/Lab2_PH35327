using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playermoment : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;

    Animator animator;

    float horizontal;
    bool isfasingRight = true;
    float speed_jump= 5;
    bool isjumpimg = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //di chuyển
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * Speed,rb.velocity.y);
        animator.SetFloat("runplayer",Mathf.Abs(horizontal));
        //quay đầu
        Quaydau();

        //nhảy
        if(Input.GetKeyDown(KeyCode.Space) && !isjumpimg)
        {
            rb.velocity = new Vector2(rb.velocity.x,speed_jump);
            isjumpimg = true;
            
        }

        animator.SetBool("isjump",isjumpimg);
    
    }

    private void Quaydau()
    {
        if(horizontal <0f && !isfasingRight || horizontal>0f && isfasingRight)
        {
            isfasingRight = !isfasingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("va cham vao "+ collider.gameObject.tag);
        isjumpimg = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "coin")
        {
            Destroy(collider.gameObject);
        }
    }
}
