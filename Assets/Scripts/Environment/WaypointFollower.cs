using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private int[] Height;
    [SerializeField] private float speed;
    [SerializeField] private float speedY;

    private Desacelerador DesaceleradorScript;

    private void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();

        for (int i = 0; i <= Height.Length; i++)
        {
            speed = i;
            speedY = i;
        }
    }

    private void Update()
    {

        if (Vector2.Distance(Waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= Waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        // Item Desacelerador
        if (DesaceleradorScript.DesaceleradorAtivado)
        {
            speed = speedY * 0.5f;
        }
        else
        {
            speed = speedY;
        }
    }
}
