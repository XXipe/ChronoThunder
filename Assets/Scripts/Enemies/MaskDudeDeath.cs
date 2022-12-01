using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDudeDeath : MonoBehaviour
{
    private GameObject Player;

    [SerializeField] private float velocityY = 8f;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(Player.GetComponent<Rigidbody2D>().velocity.x, velocityY);
        }
    }
}
