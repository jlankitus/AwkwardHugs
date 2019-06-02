using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Phases of the game
/// Tension phase is used when the player has to reduce the tension of the opponent
/// Hug phase is when the player is attempting to hug the player
/// </summary>
public enum GamePhase { TensionPhase, HugPhase}

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The main game manager in the current scene (Singleton)
    /// </summary>
    public static GameManager mainGameManager;


    GamePhase currentPhase;

    /// <summary>
    /// Current phase of the scene
    /// </summary>
    public GamePhase CurrentGamePhase
    {
        get
        {
            return currentPhase;
        }
    }


    private void Awake()
    {
        // If the main game manager is null, then assign this instance as the main game manager
        if(mainGameManager == null)
        {
            mainGameManager = this;
        }
        else // Otherwise destroy this instance if a main game manager already exists
        {
            Destroy(this.gameObject);
            currentPhase = GamePhase.TensionPhase;
        }
    }
    
    

}
