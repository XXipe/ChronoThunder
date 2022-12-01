using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksand : MonoBehaviour
{
    public GameObject Player;

    public float XR1, XL1, YU1, YD1, XR2, XL2, YU2, YD2;

    private PlayerMovement PlayerMoveScript;

    void Start()
    {
        PlayerMoveScript = Player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        CheckColliderBox();
        CheckColliderBoxHit();
    }
    void CheckColliderBox()
    {
        //Areia
        XR1 = transform.position.x + 3;
        XL1 = transform.position.x - 3;
        YU1 = transform.position.y + 3;
        YD1 = transform.position.y - 3;

        //Player
        XR2 = Player.transform.position.x + 2;
        XL2 = Player.transform.position.x - 2;
        YU2 = Player.transform.position.y + 2;
        YD2 = Player.transform.position.y - 2;
    }

    void CheckColliderBoxHit()
    {
        if (XL2 <= XR1 && XR2 >= XL1)
        {
            if (YD2 <= YU1 && YU2 >= YD1)
            {
                //VelocidadeSquare = new Vector3(0, 0, 0);
                PlayerMoveScript.moveSpeed = 3.5f;
            }
            else
            {
                PlayerMoveScript.moveSpeed = 7f;
            }
        }
        else
        {
            PlayerMoveScript.moveSpeed = 7f;
        }
    }

}
