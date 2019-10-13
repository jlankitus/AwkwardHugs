﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeLeft;
    [SerializeField] private AudioSource youFailedSource;

    [SerializeField] private GameOver gameOver;

    private bool isGameActive = true;
    
    public delegate void GameHasEnded();
    public event GameHasEnded OnGameEnded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString();
            if ( timeLeft < 0 )
            {
                GameOver();
                OnGameEnded?.Invoke();
            }
        }
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOver.gameObject.SetActive(true);
        timeLeft = 0;
        timerText.text = "You failed you little bitch!";
        youFailedSource.PlayOneShot(youFailedSource.clip);
    }
}
