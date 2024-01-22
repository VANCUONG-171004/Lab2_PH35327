using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    private Rigidbody2D rb;
    private float horizontal;

    private Animator animator;

    bool isflaysingRight = false;
    float jumpoer = 5f;

    public int vang = 0;
    public TextMeshProUGUI vangtext;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        animator.SetFloat("xveclocry", Mathf.Abs(horizontal));
        Quaydau();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2( rb.velocity.x , jumpoer );
        }

    }

    void Quaydau()
    {
        if (horizontal < 0f && !isflaysingRight || horizontal > 0f && isflaysingRight)
        {
            isflaysingRight = !isflaysingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            vang++;
            vangtext.SetText(vang.ToString());
            Destroy(other.gameObject);
        }
        

    }
}
