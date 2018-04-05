using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{

    public float health = 250f;		//	Our characters health
    public float maxVel = 5f;
    public float yJumpForce = 300f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 jumpForce;
    private bool isJumping = false;
    private bool movingRight = true;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        jumpForce = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //We update horizontal speed
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rb.velocity.y); //Warrior_CHF

        v *= maxVel;

        vel.x = v; //Vector speed Hor

        rb.velocity = vel;

        //We change animations if needed
        if (v != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        //if the player jumps
        if (Input.GetAxis("Jump") > 0.01f)
        {
            if (!isJumping)
            {
                if (rb.velocity.y == 0)
                {
                    isJumping = true;
                    anim.SetBool("IsJump", true);
                    jumpForce.x = 0f;
                    jumpForce.y = yJumpForce;
                    rb.AddForce(jumpForce);
                }
            }
        }
        else
        {
            isJumping = false;
            anim.SetBool("IsJump", false);
        }

        if (movingRight && v < 0)
        {
            movingRight = false;
            Flip();
        }
        else if (!movingRight && v > 0)
        {
            movingRight = true;
            Flip();
        }

        if (Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("IsDuck", true);
        }
        if (Input.GetButtonUp("Vertical"))
        {
            anim.SetBool("IsDuck", false);
        }
    }


    private void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    //	Called everytime our object collides with a trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        //	We try to identify the object that collided with us as a projectile (laser beam).
        Enemy tope= collider.gameObject.GetComponent<Enemy>();

        //	If our ship collided with a laser beam, we decrease our ship's health in the amount
        //	of damage set by the projectile.  If the ship's health is zero or less, then we destroy
        //	our ship.
        if (tope)
        {
            health -= tope.getDamage();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.LoadLevel("Lose");
        Destroy(gameObject);
    }
}
