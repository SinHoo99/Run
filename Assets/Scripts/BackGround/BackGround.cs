using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;

    private bool moveLeft = true;

    private void OnMouseDown()
    {
        if (moveLeft)
        {
            GM.Player.MoveLeft();
        }
        else
        {
            GM.Player.MoveRight();
        }

        moveLeft = !moveLeft;
    }
}
