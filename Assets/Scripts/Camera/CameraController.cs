using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform flag;
    [SerializeField] private Transform Comeco;

    void Update()
    {
        if (player.transform.position.x <= Comeco.transform.position.x + 10f)
        {
            transform.position = new Vector3(Comeco.transform.position.x + 10f, player.transform.position.y + 0.5f, transform.position.z);
        }
        else if (player.transform.position.x >= flag.transform.position.x - 5.5f)
        {
            transform.position = new Vector3(flag.transform.position.x - 5.5f, player.transform.position.y + 0.5f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 0.5f, transform.position.z);
        }
    }
}
