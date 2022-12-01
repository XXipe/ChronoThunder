using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desacelerador : MonoBehaviour
{
    public bool DesaceleradorAtivado = false;

    public float ItemTimer = -5f;

    public GameObject terrain;

    [SerializeField] private AudioSource TimeStopEffect;

    void Start()
    {
        
    }
    
    void Update()
    {
        Ativar();
        Desativar();
        Timer();
    }

    void Ativar()
    {
        if (Cooldown() != true)
        {
            if (Input.GetKeyDown("z"))
            {
                DesaceleradorAtivado = true;
                ItemTimer = 3f;
                TimeStopEffect.Play();
            }
        }
    }

    void Timer()
    {
        // Dizendo que se o timer estiver acima de 0, diminuir até chegar em 0
        if (ItemTimer > 0f)
        {
            ItemTimer -= Time.deltaTime;
        }
    }

    void Desativar()
    {
        // Dizendo que se o timer for menor que 0, o Desacelerador é desativado
        if (ItemTimer <= 0)
        {
            DesaceleradorAtivado = false;
        }
    }

    bool Cooldown()
    {
        // Dizendo se o Desacelerador esta ativado ou desativado
        if (ItemTimer > -5f && ItemTimer <= 0)
        {
            ItemTimer -= Time.deltaTime;
            return true;
        }
        else if (ItemTimer <= -5f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
