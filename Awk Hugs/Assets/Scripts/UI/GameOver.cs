using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private AudioSource youFailedSource;
        public TextMeshProUGUI winOrLose;
        public Timer timer;
        public DisplayHug displayHug;

        private void Start()
        {
            timer.OnGameEnded += GameOverDetermination;
        }
    
        private void GameOverDetermination()
        {
            if ( displayHug.hugCount >= 15)
            {
                winOrLose.text = "You Win!";
            }
            else if ( displayHug.hugCount < 15)
            {
                winOrLose.text = "You Lose";
                youFailedSource.PlayOneShot(youFailedSource.clip);
            }
            winOrLose.gameObject.SetActive(true);
        }
    
    }
}
