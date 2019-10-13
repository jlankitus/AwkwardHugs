using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    private NavMeshAgent enemyBoi;

    public GameObject bearBoi;

    public float enemyBoiDistanceRun = 8.0f;

    AudioSource enemyBoi_AudioSource;

    private bool isPlaying;

    public AudioClip chaseMusic;

    private bool musicFadeOutEnabled = false;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyBoi = GetComponent<NavMeshAgent>();

        //Fetch the AudioSource from the GameObject
        enemyBoi_AudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, bearBoi.transform.position);
        // Run towards player

        if (distance < enemyBoiDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - bearBoi.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            //playEnemy = true;

            enemyBoi.SetDestination(newPos);

            PlaySound();

        }
        else
        {
            if(enemyBoi_AudioSource.isPlaying)
            musicFadeOutEnabled = true;
            //enemyBoi_AudioSource.Stop();
        }


        if (musicFadeOutEnabled)
        {
            if (enemyBoi_AudioSource.volume <= 0.1f)
            {
                enemyBoi_AudioSource.Stop();
                musicFadeOutEnabled = false;
            }
            else
            {
                float newVolume = enemyBoi_AudioSource.volume - (3f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
                if (newVolume < 0f)
                {
                    newVolume = 0f;
                }
                enemyBoi_AudioSource.volume = newVolume;

            }
        }

        //LEVEL TRANSITION TO GAME OVER SCREEN

        if(distance <= 2.2)
        {
            Destroy(bearBoi);
            Destroy(enemy);

        }


    }


    private void PlaySound()
    {
        //if (playEnemy == false)
        //{
        //    //Play the audio you attach to the AudioSource component
        //    if(!enemyBoi_AudioSource.isPlaying)
        //        enemyBoi_AudioSource.Play();
        //}

        if (!enemyBoi_AudioSource.isPlaying)
            GetComponent<AudioSource>().PlayOneShot(chaseMusic);

        musicFadeOutEnabled = false;
       enemyBoi_AudioSource.volume = 1f;
       //enemyBoi_AudioSource.Play();
      

    }
}
