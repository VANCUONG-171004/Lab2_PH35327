using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Playermoment : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;

    Animator animator;

    float horizontal;
    bool isfasingRight = true;
    float speed_jump = 7;
    bool isjumpimg = false;

    public float coin = 0;
    public TextMeshProUGUI Cointext;


    // máu
    public int heath;
    public int numofhearts;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHears;

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
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
        animator.SetFloat("xvelocry", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yvelocry", rb.velocity.y);
        //quay đầu
        Quaydau();


        //nhảy
        if (Input.GetKeyDown(KeyCode.Space) && isjumpimg)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed_jump);
            isjumpimg = false;

        }

        animator.SetBool("isjump", !isjumpimg);

        if (!isjumpimg && Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
        }


        //Sử lý máu

        if (heath > numofhearts)
        {
            heath = numofhearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < heath)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyHears;
            }

            if (i < numofhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

    private void Quaydau()
    {
        if (horizontal < 0f && !isfasingRight || horizontal > 0f && isfasingRight)
        {
            isfasingRight = !isfasingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("va cham vao " + collider.gameObject.tag);
        isjumpimg = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "coin")
        {
            coin++;
            Cointext.SetText(coin.ToString());
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "nam")
        {
            heath--;
        }
    }
}
