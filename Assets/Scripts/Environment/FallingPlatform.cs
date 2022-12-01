using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float PlatTimer = 0.2f;

    private Desacelerador DesaceleradorScript;

    //Fisica

    public float Area, Cx, P;

    public Vector3 Velocidade, V2;

    public Vector3 AG, G, P2;

    public Vector3 Fr, Afr;

    public Vector2 PosicaoInicial;

    void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();

        //Fisica

        Velocidade = new Vector3(0, 0, 0);
        G = new Vector3(0, 9.81f, 0);

        Cx = 1f;
        P = 1.225f;
        Area = 7.2435376f;

        PosicaoInicial = new Vector2(transform.position.x, transform.position.y);
    }

    
    void FixedUpdate()
    {
        Falling();
        Desacelerado();
        UpdateVelocity();

        if (transform.position.y <= -35f)
        {
            PlatTimer = 0.3f;
            transform.position = PosicaoInicial;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlatTimer -= Time.deltaTime;
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlatTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }

        if (collision.gameObject.name == "Player" && PlatTimer > 0)
        {
            PlatTimer = 0.2f;
        }
    }

    private bool TimerLessThanZero()
    {
        if (PlatTimer <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Falling()
    {
        if (TimerLessThanZero())
        {
            transform.position += Velocidade * Time.deltaTime;
        }
    }

    void Desacelerado()
    {
        if (DesaceleradorScript.DesaceleradorAtivado)
        {
            Cx = 4f;
        }
        else
        {
            Cx = 1f;
        }
    }

    // Fisica

    void UpdateGravidade()
    {
        P2 = 10 * -G;
        AG = P2 / 10;
    }

    void ForcaResistencia()
    {
        // Velocidade ao quadrado
        V2 = Vector3.Scale(Velocidade, Velocidade);

        // Força resistente
        Fr = (Cx * P * Area * (V2)) / 2;

        // Aceleração = Força resistente / massa
        Afr = Fr / 10;
    }

    void UpdateVelocity()
    {
        UpdateGravidade();
        ForcaResistencia();

        Velocidade += AG * Time.deltaTime + Afr * Time.deltaTime;
    }
}
