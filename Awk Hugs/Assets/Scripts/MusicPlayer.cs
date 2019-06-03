using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer singletonInstance;

    private void Awake()
    {
        if(singletonInstance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            singletonInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
