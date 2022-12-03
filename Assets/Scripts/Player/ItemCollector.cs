using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Pontos = 0;

    [SerializeField] private Text PontosText;

    [SerializeField] private AudioSource CollectionSoundEffect;

    private Desacelerador DesaceleradorScript;
    public GameObject DesaceleradorButton;

    private void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Pontos += 100;
            PontosText.text = "Pontuação: " + Pontos;
        }

        if (collision.gameObject.CompareTag("Strawberry"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Pontos += 500;
            PontosText.text = "Pontuação: " + Pontos;
        }

        if (collision.gameObject.CompareTag("Desacelerador"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            DesaceleradorScript.enabled = true;
            DesaceleradorButton.SetActive(true);
        }
    }
}
