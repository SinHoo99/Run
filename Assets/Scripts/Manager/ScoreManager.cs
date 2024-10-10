using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private Timer _timer;

    private void Start()
    {
        if (Timer.Instance != null)
        {
            Timer.Instance.OnTimeElapsed += IncreaseScore;
        }
    }

    private void IncreaseScore()
    {
        _score++;
        Debug.Log("Score increased: " + _score);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: "+ _score.ToString();
        }
    }
}
