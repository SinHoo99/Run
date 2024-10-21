using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]private PlayerController _controller;

    private bool moveLeft = true;

    private void OnMouseDown()
    {
        if (moveLeft)
        {
            _controller.MoveLeft();
        }
        else
        {
            _controller.MoveRight();
        }

        moveLeft = !moveLeft;
    }
}
