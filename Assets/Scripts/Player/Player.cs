using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D; // 스프라이트 아틀라스 관련 네임스페이스

public class Player : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetPlayer(this);
        }
    }

    public void ApplySprite(string atlasPath)
    {
        if (!string.IsNullOrEmpty(atlasPath))
        {
            // 스프라이트 아틀라스를 로드합니다.
            SpriteAtlas atlas = Resources.Load<SpriteAtlas>(atlasPath);

            if (atlas != null)
            {
                // GameManager에서 동적으로 가져온 스프라이트 이름 사용
                string targetSpriteName = GM.gameData.playerSpriteName;

                // 아틀라스에서 스프라이트를 직접 검색합니다.
                Sprite targetSprite = atlas.GetSprite(targetSpriteName);

                if (targetSprite != null)
                {
                    _spriteRenderer.sprite = targetSprite;
                    Debug.Log("Player 스프라이트가 로드되었습니다: " + targetSprite.name);
                }
                else
                {
                    Debug.LogWarning("스프라이트 '" + targetSpriteName + "'을(를) 찾을 수 없습니다.");
                }
            }
            else
            {
                Debug.LogWarning("스프라이트 아틀라스를 찾을 수 없습니다: " + atlasPath);
            }
        }
    }
}
