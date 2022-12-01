using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private Desacelerador DesaceleradorScript;

    private void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();
    }

    void Update()
    {
        if (DesaceleradorScript.DesaceleradorAtivado)
        {
            speed = 0.75f;
        }
        else
        {
            speed = 1.5f;
        }
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
