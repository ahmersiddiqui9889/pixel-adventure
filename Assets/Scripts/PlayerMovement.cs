using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    private enum MovementState {idle, running, jumping, falling};
    private MovementState state = MovementState.idle;

    // Sound Effects
    [SerializeField] private AudioSource runningSoundEffect;
    [SerializeField] private AudioSource jumpSoundEffect;



    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    // Start is called before the first frame update

    
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.bodyType == RigidbodyType2D.Static) {
            return;
        }
        // Horizontal Movement of Player
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);
        


        // Jumping of Player
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    

    private void UpdateAnimationState() {

        if (dirX > 0f) {
            state=MovementState.running;
            sprite.flipX = false;
        } else if (dirX < 0f){
            state=MovementState.running;
            sprite.flipX = true;
        }  else {
            state=MovementState.idle;
        }
        
        if (rb.velocity.y > 0.1f) {
            state=MovementState.jumping;
        } else if (rb.velocity.y < -0.1f) {
            state=MovementState.falling;
        }

        if(!runningSoundEffect.isPlaying && state==MovementState.running) {
            runningSoundEffect.Play();
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
