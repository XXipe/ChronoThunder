using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private GameObject Player;
    private Animator anim;

    [SerializeField] private int[] Height;
    [SerializeField] private float velocityY = 0;

    [SerializeField] private AudioSource TrampolineSoundEffect;

    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        for (int i = 0; i <= Height.Length; i++)
        {
            velocityY = i;
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            TrampolineSoundEffect.Play();
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2 (Player.GetComponent<Rigidbody2D>().velocity.x, velocityY);
            anim.SetTrigger("Jump");
        }
    }
}
