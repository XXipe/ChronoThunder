using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private GameObject Player;
    private Animator anim;

    [SerializeField] private bool ativado = false;

    [SerializeField] private AudioSource ActivateSoundEffect;

    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetTrigger("Activate");
            ActivateSoundEffect.Play();
        }
    }

    private void ActivateFire()
    {
        anim.SetTrigger("Activated");
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.tag = "FireAtivado";
    }
}
