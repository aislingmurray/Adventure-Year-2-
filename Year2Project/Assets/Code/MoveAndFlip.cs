using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndFlip : MonoBehaviour
{

    [Header("Is your character facing right before runtime? If yes, check box")]
    public bool facingRight;

    public float horizontalValue;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        move();

        // use this for the wrong way
        //wrongWayToFlip();

        // use this for a better way
        properFlip();
    }

    void move()
    {
        horizontalValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.Translate(new Vector3()
    }

    void properFlip()
    {
        if ((horizontalValue < 0 && facingRight) || (horizontalValue > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    void wrongWayToFlip()
    {
        if ((horizontalValue < 0 && facingRight) || (horizontalValue > 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}