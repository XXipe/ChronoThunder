using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDesacelerador : MonoBehaviour
{
    private Desacelerador DesaceleradorScript;

    public Text timerUI;

    void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();
    }

    
    void Update()
    {
        if (DesaceleradorScript.ItemTimer > 0)
        {
            timerUI.gameObject.SetActive(true);
            timerUI.text = "Desacelerador: " + DesaceleradorScript.ItemTimer.ToString("F1");
        }
        else
        {
            timerUI.gameObject.SetActive(false);
        }
    }
}
