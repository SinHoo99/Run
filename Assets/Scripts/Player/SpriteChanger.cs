using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;

    public void ChangeSprite()
    {
        // 자식 Image 컴포넌트를 가져와서 스프라이트를 변경할 대상을 설정
        Image[] _childImages = GetComponentsInChildren<Image>();
        Image targetImage = _childImages.Length > 1 ? _childImages[1] : null;

        // GameManager에서 Player의 SpriteRenderer 가져오기
        SpriteRenderer playerSpriteRenderer = GM.Player.GetComponentInChildren<SpriteRenderer>();

        if (targetImage != null && playerSpriteRenderer != null)
        {
            // 스프라이트 변경
            playerSpriteRenderer.sprite = targetImage.sprite;

            // GameData 업데이트 및 저장
            GM.gameData.playerSpriteName = targetImage.sprite.name;
            GM.gameData.playerSpritePath = "Sprites/Bike"; // 실제 아틀라스 경로 입력
            GM.saveManager.SaveGameData(GM.gameData);

            Debug.Log("Player 스프라이트가 변경되었습니다: " + targetImage.sprite.name);
        }
        else
        {
            Debug.LogWarning("스프라이트를 변경할 수 없습니다. 타겟 이미지 또는 플레이어 스프라이트 렌더러가 없습니다.");
        }
    }
}
