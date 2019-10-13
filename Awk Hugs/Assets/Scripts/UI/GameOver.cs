using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI winOrLose;
    public Timer timer;
    public DisplayHug displayHug;

    private void Start()
    {
        timer.OnGameEnded += GameOverDetermination;
    }
    
    public void GameOverDetermination()
    {
        if ( displayHug.hugCount >= 15)
        {
            winOrLose.text = "You Win!";
        }
        else if ( displayHug.hugCount > 15)
        {
            winOrLose.text = "You Lose";
        }
        winOrLose.gameObject.SetActive(true);
    }
    
}
