using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    public Projectile LaunchProjectile;
    public Transform LaunchOffset;

    private void Start()
    {
        //Grabby Hands
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Character flip
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
            

        //Animator parameters 
        anim.SetBool("running", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(LaunchProjectile, LaunchOffset.position, transform.rotation);
        }
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 13);
        anim.SetTrigger("jump");
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = true;
    }
} 
