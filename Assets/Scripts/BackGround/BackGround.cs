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

        // PC ȯ�濡�� �׽�Ʈ�� ��� ���콺 Ŭ�����ε� ������ �׽�Ʈ�� �� �ֵ��� �߰�:
        if (Input.GetMouseButtonDown(0))
        {
            GM.Player.Jump();
        }
    }
}
