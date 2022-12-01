using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D bc;

    [SerializeField] private AudioSource DeathnSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            bc.enabled = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            bc.enabled = false;
        }
        if (collision.gameObject.CompareTag("FireAtivado"))
        {
            Die();
            bc.enabled = false;
        }

    }

    private void Die()
    {
        DeathnSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");   
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
