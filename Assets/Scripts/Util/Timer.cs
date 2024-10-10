using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : Singleton<Timer>
{
    public float interval = 1f;
    public event System.Action OnTimeElapsed;

    private float timeElapsed = 0f;
    private bool isTimerActive = true;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (!isTimerActive) return;

        timeElapsed += Time.deltaTime;

        if(timeElapsed >= interval)
        {
            OnTimeElapsed?.Invoke();
            timeElapsed = 0f;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainScene")
        {
            isTimerActive = true;
        }
        else
        {
            isTimerActive= false;
        }
    }
}
