using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;

    public void ChangeSprite()
    {
        Image[] _chlidImage = GetComponentsInChildren<Image>();

        Image targetImage = _chlidImage.Length > 1 ? _chlidImage[1] : null;

        SpriteRenderer playerSpriteRenderer = GM.Player.GetComponentInChildren<SpriteRenderer>();

        if (_chlidImage != null && playerSpriteRenderer != null)
        {
            playerSpriteRenderer.sprite = targetImage.sprite;       
        }
    }
}