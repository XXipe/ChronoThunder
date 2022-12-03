using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    public GameObject player; 
    [SerializeField] private float waitTime, normalState;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

    }

    private void Update()
    {
        if (player.GetComponent<PlayerMovement>().joystick.Vertical > -0.35)
        {
            waitTime = 0.2f;
        }

        if (player.GetComponent<PlayerMovement>().joystick.Vertical <= -0.35)
        {
            if (waitTime <= 0)
            {
                effector.surfaceArc = 0f;
                waitTime = 0.2f;
                normalState = -0.2f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (normalState >= 0)
        {
            effector.surfaceArc = 100f;
        }

        if (normalState < 0)
        {
            normalState += Time.deltaTime;
            gameObject.layer = 7;
        }
        else
        {
            gameObject.layer = 6;
        }
    }
}
