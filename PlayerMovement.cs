using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Setup Variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    //Jumping Variables
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpOffset = .2f;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 14f;
    private bool doubleJump;

    //Audio Sources
    [SerializeField] private AudioSource jumpSoundEffect;
    //Movement State Changer
    private enum MovementState { idle, running, jumping, falling }
    [SerializeField] public Transform eyes;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Movement
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //doubleJump Reset
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        //Jumping & DoubleJumping
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }
        //Jump Variability
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        UpdateAnimations();
    }

    public void UpdateAnimations()
    {
        MovementState state;

        state = MovementState.idle;

        //Running
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            eyes.transform.localPosition = new Vector3(1.1f, -1.5f, 0);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            eyes.transform.localPosition = new Vector3(.4f, -1.5f, 0);
        }

        //Jumping
        if (rb.velocity.y > .1f || !IsGrounded())
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    //Checks to see if the player is on jumpable ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, jumpOffset, jumpableGround);
    }
}
