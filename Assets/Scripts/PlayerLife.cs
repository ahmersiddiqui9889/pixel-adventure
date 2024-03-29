using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;





    [SerializeField] private AudioSource deathSoundEffect;

    private void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Trap")) {
            Die();
        }
    }

    private void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSoundEffect.Play();
    }

    private void Respawn() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
