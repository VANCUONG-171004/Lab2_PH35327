using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Player6 : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;

    public GameObject panel;

    public GameObject wingame;

    public GameObject weapon;

    float Horizontal;

    public float cheri = 0;

    public float maxcheri = 4;

    public TextMeshProUGUI loseCheri;

    public TextMeshProUGUI cheritext;

    Animator animator;

    bool isfashingRight = false;

    public GameObject effects ;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Instantiate(effects,gameObject.transform);

    }

    // Update is called once per frame
    void Update()
    {

        if (cheri >= maxcheri)
        {
            wingame.SetActive(true);
        }


        if(rb.velocity.x < 0f){
            animator.SetBool("isruning",true);
        }else if(rb.velocity.x >0f)
        {
            animator.SetBool("isruning",true);
        }else
        {
            animator.SetBool("isruning",false);
        }

        QuayDau();
    }

    public void QuayDau()
    {
        if(rb.velocity.x <0f && !isfashingRight || rb.velocity.x >0f && isfashingRight)
        {
            isfashingRight = !isfashingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;

        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
    }

    public void Left()
    {

        rb.AddForce(Vector2.left * 2, ForceMode2D.Impulse);
        
    }


    public void Right()
    {
        rb.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
    }

    public void LoadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "trap")
        {
            panel.SetActive(true);
            loseCheri.SetText(cheri.ToString());
        }
    }


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "cheri")
        {
            cheri++;
            cheritext.SetText(cheri.ToString());
            Destroy(collider2D.gameObject);
        }
    }
}
