using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDude : MonoBehaviour
{
    // Componentes
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    // Movimento
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private GameObject[] Waypoints;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 9f;

    private int currentWaypointIndex = 0;

    public float JumpTimer = -4f;

    // Animações
    private enum MovementState { Idle, Running, Jumping, Falling }

    // Interacao com itens
    private Desacelerador DesaceleradorScript;

    // Gravidade/Fisica
    public Vector3 Velocidade, V2;
    public Vector3 AG, G, P2, Fr, Afr, FrAg;

    public float Area = 7.2435376f;
    public float Cx = 0.47f;
    public float P = 1.225f;

    void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        // Gravidade
        G = new Vector3(0, 9.81f, 0);
    }

    void Update()
    {
        Timer();
        Walk();
        Desacelerado();

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState State;

        if (currentWaypointIndex == 1)
        {
            State = MovementState.Running;
            sprite.flipX = false;
        }
        else if (currentWaypointIndex == 0)
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

    void Walk()
    {
        if (rb.velocity.y != 0 || JumpCooldown() != true)
        {
            Jump();
        }
        else
        {
            if (Vector2.Distance(Waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= Waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, Waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }

    void Jump()
    {
        if (JumpCooldown() != true && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
        }
        else
        {

        }
    }

    void Timer()
    {
        if (JumpTimer > -4f)
        {
            JumpTimer -= Time.deltaTime;
        }
        else
        {
            JumpTimer = 2f;
        }
    }

    bool JumpCooldown()
    {
        if (JumpTimer > -4f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Desacelerado()
    {
        if (DesaceleradorScript.DesaceleradorAtivado)
        {
            speed = 1.5f;
            jumpForce = 6f;
            rb.gravityScale = 1;
        }
        else
        {
            speed = 3f;
            jumpForce = 9f;
            rb.gravityScale = 3;
        }
    }
}
