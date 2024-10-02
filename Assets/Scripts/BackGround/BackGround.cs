using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                GM.Player.Jump();
            }
        }

        // PC 환경에서 테스트할 경우 마우스 클릭으로도 점프를 테스트할 수 있도록 추가:
        if (Input.GetMouseButtonDown(0))
        {
            GM.Player.Jump();
        }
    }
}
