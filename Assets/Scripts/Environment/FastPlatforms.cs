using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 7f;

    private Desacelerador DesaceleradorScript;

    void Start()
    {
        DesaceleradorScript = GameObject.Find("Player").GetComponent<Desacelerador>();
    }

    // Update is called once per frame
    void Update()
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
            speed = 3f;
        }
        else
        {
            speed = 7f;
        }
    }
}
