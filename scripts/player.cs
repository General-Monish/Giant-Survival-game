using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject losePanel;
    public Text healthdisplay;
    public float speed;
    private float input;

    Rigidbody2D rb;
    Animator anim;
    AudioSource source;

    public int health;

    public float startDashTime;
    private float dashtime;
    public float extrapeed;
    private bool isDashing;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthdisplay.text = health.ToString();

    }
    private void Update()
    {

        // storing players input
        if (input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space)&& isDashing == false)
        {
            speed += extrapeed;
            isDashing = true;
            dashtime = startDashTime;
        }
        if (dashtime <= 0 && isDashing == true)
        {
            isDashing = false;
            speed -= extrapeed;
        }
        else
        {
            dashtime -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");

        //moving player 
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

    }

    public void TakeDamage(int damageAmount)
    {
        source.Play();
        health -= damageAmount;
        healthdisplay.text = health.ToString();
        if (health <= 0)
        {
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
