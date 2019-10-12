using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI gameOver;
    [SerializeField] private float timeLeft;
    [SerializeField] private AudioSource youFailedSource;

    private bool isGameActive = true;
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
