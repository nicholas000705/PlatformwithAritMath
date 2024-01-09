using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpGround;

    private float horizontalMove;
    private bool runLeft;
    private bool runRight;
    private bool jump;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;


    private enum CharacterAnimatorState { idle, run, jump, fall };
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        runLeft = false;
        runRight = false;
        jump = false;
    }

    private void Update()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
            AudioManager.instance.PlayEffectSound("Jump");
        }
        UpdateAnimation();  
    }

    public void PointerDownRunLeft()
    {
        runLeft = true;
    }

    public void PointerUpRunLeft()
    {
        runLeft = false;
    }

    public void PointerDownRunRight() 
    { 
        runRight = true;
    }

    public void PointerUpRunRight()
    {
        runRight = false;
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            jump = true;
        }
    }

    private void UpdateAnimation()
    {
        CharacterAnimatorState characterState;

        if (runRight)
        {
            horizontalMove = moveSpeed;
            characterState = CharacterAnimatorState.run;
            sprite.flipX = false;
        }
        else if (runLeft)
        {
            horizontalMove = -moveSpeed;
            characterState = CharacterAnimatorState.run;
            sprite.flipX = true;
        }
        else
        {
            horizontalMove = 0;
            characterState = CharacterAnimatorState.idle;
        }

        if (rb.velocity.y > 0.1f) 
        {
            characterState = CharacterAnimatorState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            characterState = CharacterAnimatorState.fall;
        }

        animator.SetInteger("characterState", (int)characterState);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }
}
