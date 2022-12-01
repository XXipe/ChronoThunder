using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasDiatomicas : MonoBehaviour
{
    public GameObject Plataforma2;

    public Vector3 forcehook1, forcehook2;

    public float spring1, mass1, mass2;

    public Vector3 accelerationVector1, accelerationVector2;

    public Vector3 velocityVector1, velocityVector2;

    public Vector3 BV, Forca;

    public Vector3 BV2, Forca2;

    private Desacelerador DesaceleradorScript;

    void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();

        spring1 = 20.0f;

        mass1 = 5;
        mass2 = 5;

        velocityVector1 = new Vector3(5.0f, 0, 0);
        accelerationVector1 = new Vector3(1.0f, 0, 0);

        velocityVector2 = new Vector3(-5.0f, 0, 0);
        accelerationVector2 = new Vector3(1.0f, 0, 0);
    }

    void FixedUpdate()
    {
        Desacelerado();

        forcehook1 = spring1 * new Vector3(Mathf.Abs(transform.position.x - Plataforma2.transform.position.x) - 10.0f, 0.0f, 0.0f);
        forcehook2 = -forcehook1;

        accelerationVector1 = forcehook1 / mass1; // 10 = massa da plataforma 1
        accelerationVector2 = forcehook2 / mass2; // 10 = massa da plataforma 2

        UpdateVelocity();

        transform.position += velocityVector1 * Time.deltaTime;
        Plataforma2.transform.position += velocityVector2 * Time.deltaTime;
    }

    void UpdateVelocity()
    {
        velocityVector1 += accelerationVector1 * Time.deltaTime;
        velocityVector2 += accelerationVector2 * Time.deltaTime;
    }

    void Desacelerado()
    {
        if (DesaceleradorScript.DesaceleradorAtivado)
        {
            spring1 = 5.0f;
            mass1 = 20;
            mass2 = 20;
        }
        else
        {
            spring1 = 20.0f;
            mass1 = 5;
            mass2 = 5;
        }
    }
}
