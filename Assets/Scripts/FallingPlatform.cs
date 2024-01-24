using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private LayerMask objectOnPlatform;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerOnPlatform()) {
            Invoke("setDynamic", fallDelay);
            anim.SetTrigger("falling");
        }
    }

    private void setDynamic() {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    private bool PlayerOnPlatform() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, 0.1f, objectOnPlatform);

    }
}
