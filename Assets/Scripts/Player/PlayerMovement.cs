using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float directionX = 0f;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { Idle, Running, Jumping, Falling }

    [SerializeField] private AudioSource JumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Jump();
        Horizontal();

        UpdateAnimationState();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpSoundEffect.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }   

    private void Horizontal()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
    }

    private void UpdateAnimationState()
    {
        MovementState State;

        if (directionX > 0f)
        {
            State = MovementState.Running;
            sprite.flipX = false;
        }
        else if (directionX < 0f)
        {
            State = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            State = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            State = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.Falling;
        }

        anim.SetInteger("State", (int)State);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}